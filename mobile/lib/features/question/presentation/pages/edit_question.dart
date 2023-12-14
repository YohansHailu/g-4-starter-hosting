import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:mobile/core/constants/constants.dart';

class EditQuestionPage extends StatelessWidget {
  const EditQuestionPage({super.key});

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
            content: const Text('Discard edit?'),
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
    'Edit',
    style: mainFont.copyWith(color: Colors.white),
  ),
),

        body: Container(
          margin: const EdgeInsets.all(16),
          child: Column(children: [
            Flexible(
                child: TextField(
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
                onPressed: () {},
                child:  Text(
                  "Save",
                  style: mainFont.copyWith(color: Colors.white),
                ),
                style:  mainButton
              ),
            )
          ]),
        ));
  }
}