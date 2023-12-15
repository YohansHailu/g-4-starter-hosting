import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:mobile/core/constants/constants.dart';

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
    // TODO: implement initState
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
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
                  Navigator.pop(context); // This will go back to the previous screen
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
          margin: EdgeInsets.all(16),
          child: Column(children: [
            Flexible(
                child: TextField(
              controller: titleController,
              decoration: inputDecoration.copyWith(
                  hintText: "Topic",
                  hintStyle: mainFont.copyWith(color: Colors.black)),
            )),
            SizedBox(
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
            SizedBox(
              height: 20,
            ),
            Align(
              alignment: Alignment.bottomRight,
              child: TextButton(
                onPressed: () {},
                child: Text(
                  "POST",
                  style: mainFont.copyWith(color: Colors.white),
                ),
                style: const ButtonStyle(
                  backgroundColor: MaterialStatePropertyAll(Color(0xFF005FEE)),
                  padding: MaterialStatePropertyAll(
                      EdgeInsets.symmetric(vertical: 20, horizontal: 20)),
                ),
              ),
            )
          ]),
        ));
  }
}
