import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:mobile/core/constants/constants.dart';
import 'package:mobile/features/question/presentation/bloc/bloc.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/question/presentation/pages/edit_question.dart';

class CreateQuestionPage extends StatefulWidget {
  const CreateQuestionPage({super.key});

  @override
  State<CreateQuestionPage> createState() => _CreateQuestionPageState();
}

class _CreateQuestionPageState extends State<CreateQuestionPage> {
  TextEditingController titleController = TextEditingController();
  TextEditingController contentController = TextEditingController();

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return BlocListener<QuestionBloc, QuestionState>(
      listener: (context, state) {

        if (state is QuestionInserted){
          Navigator.pushReplacement(context,  MaterialPageRoute(
                builder: (context) => EditQuestionPage(question: state.question),
              ),);
        }

        else if(state is QuestionError){
           final snackBar = SnackBar(content: Text(state.message));
          ScaffoldMessenger.of(context).showSnackBar(snackBar);
       
        }
        else if(state is QuestionLoading){
            const snackBar = SnackBar(content: Text("Posting"));
          ScaffoldMessenger.of(context).showSnackBar(snackBar);
       
        }
       
      },
      child: Scaffold(
          appBar: AppBar(
            backgroundColor: primary,
            leading: IconButton(
              icon: SvgPicture.asset('assets/icons/back_icon.svg'),
              onPressed: () async {
                showDialog(
                  context: context,
                  builder: (BuildContext context) {
                    return AlertDialog(
                      content: const Text('Discard draft?'),
                      actions: [
                        TextButton(
                          child: const Text('Yes'),
                          onPressed: () async {
                            Navigator.pop(context); // Close the AlertDialog
                            Navigator.pop(
                                context); // This will go back to the previous screen
                          },
                        ),
                        TextButton(
                          child: const Text('No'),
                          onPressed: () {
                            Navigator.pop(context); // Close the AlertDialog
                          },
                        ),
                      ],
                    );
                  },
                );
              },
            ),
            centerTitle: true,
            title: Text(
              'Post A Question',
              style: mainFont.copyWith(color: Colors.white),
            ),
          ),
          body: Container(
            margin: const EdgeInsets.all(16),
            child: Column(children: [
              Flexible(
                  child: TextField(
                controller: titleController,
                decoration: inputDecoration.copyWith(
                    hintText: "Topic",
                    hintStyle: mainFont.copyWith(color: Colors.black)),
              )),
              const SizedBox(
                height: 16,
              ),
              Flexible(
                  flex: 2,
                  child: TextField(
                    controller: contentController,
                    maxLines: 8,
                    keyboardType: TextInputType.multiline,
                    decoration: inputDecoration.copyWith(
                        hintText: "Content",
                        hintStyle: mainFont.copyWith(color: Colors.black)),
                  )),
              const SizedBox(
                height: 20,
              ),
              Align(
                alignment: Alignment.bottomRight,
                child: TextButton(
                  onPressed: () {
                    BlocProvider.of<QuestionBloc>(context).add(
                        QuestionPostEvent(
                            uId: "uId",
                            title: titleController.text,
                            content: contentController.text));
                  },
                  style: const ButtonStyle(
                    backgroundColor:
                        MaterialStatePropertyAll(Color(0xFF005FEE)),
                    padding: MaterialStatePropertyAll(
                        EdgeInsets.symmetric(vertical: 20, horizontal: 20)),
                  ),
                  child: Text(
                    "POST",
                    style: mainFont.copyWith(color: Colors.white),
                  ),
                ),
              )
            ]),
          )),
    );
  }
}
