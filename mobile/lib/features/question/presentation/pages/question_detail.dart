import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:mobile/core/constants/app_colors.dart';
import 'package:mobile/core/constants/app_style.dart';

class QuestionDetailPage extends StatefulWidget {
  const QuestionDetailPage({super.key});

  @override
  State<QuestionDetailPage> createState() => _QuestionDetailPageState();
}

class _QuestionDetailPageState extends State<QuestionDetailPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Stack(
      children: [
        CustomScrollView(
          slivers: [
            SliverAppBar(
              backgroundColor: primary,
              leading: IconButton(
                icon: SvgPicture.asset('assets/icons/back_icon.svg'),
                onPressed: () {
                  Navigator.pop(
                      context); // This will go back to the previous screen
                },
              ),
              actions: [
                IconButton(
                  icon: const Icon(Icons.edit, color: Colors.white),
                  onPressed: () {
                    // This will go to the bookmarked screen
                  },
                ),
                IconButton(
                  icon: const Icon(
                    Icons.delete,
                    color: Colors.white,
                  ),
                  onPressed: () {
                    // This will go to the share screen
                  },
                ),
              ],
            ),
            SliverList(
              delegate: SliverChildListDelegate([
                Container(
                  margin: const EdgeInsets.only(top: 15),
                  child: Text(
                    "What is the best way to manage state in flutter?",
                    style: mainFont.copyWith(
                      fontWeight: FontWeight.bold,
                      fontSize: 24,
                    ),
                    textAlign: TextAlign.center,
                  ),
                ),
                Container(
                  margin: EdgeInsets.all(15),
                  child:  Text(
                    """Lorem ipsum dolor sit amet, consectetur adipiscing elit. Massa in nibh nunc a, ac risus, molestie. Sit scelerisque leo egestas nunc, morbi vel platea justo, ut. Odio integer quis diam purus felis, fermentum, consectetur. Nascetur purus pretium hendrerit velit neque enim. Mauris eget sem mattis elementum leo eget. Ipsum massa metus, imperdiet diam pellentesque ut. 
                    Turpis consectetur elementum a quis et venenatis blandit viverra. Pretium fusce faucibus tortor, amet, tellus senectus gravida nulla. Adipiscing ridiculus elementum amet, at pharetra ac. Arcu augue in amet elementum euismod elementum sit et urna. Neque, feugiat leo viverra cursus condimentum blandit. Volutpat tellus tristique sit sit lobortis feugiat egestas faucibus. Nibh potenti in morbi morbi non.
                    Turpis consectetur elementum a quis et venenatis blandit viverra. Pretium fusce faucibus tortor, amet, tellus senectus gravida nulla. Adipiscing ridiculus elementum amet, at pharetra ac. Arcu augue in amet elementum euismod elementum sit et urna. Neque, feugiat leo viverra cursus condimentum blandit. Volutpat tellus tristique sit sit lobortis feugiat egestas faucibus. Nibh potenti in morbi morbi non.
                     Non quam elit scelerisque dictum tristique vivamus aenean. Id velit dui sit et quam condimentum mi. Sit diam tempor magna sem amet, orci. Volutpat diam nibh faucibus semper sit. Phasellus amet ullamcorper euismod nunc. Iaculis massa habitasse nisi, quam montes. Hac nisl, augue donec ornare sed viverra eleifend non. Pharetra ipsum dapibus integer odio leo semper eleifend. Nunc senectus tortor dignissim auctor dui. Cursus ut convallis enim nunc lorem rhoncus, fames id quis. Vel ullamcorper quis dolor sem morbi orci. Volutpat dignissim felis commodo urna dis. A, felis et scelerisque neque, tellus viverra pellentesque. Morbi fermentum venenatis egestas pulvinar purus velit. Turpis tellus gravida facilisi leo eleifend dictum nec eget. Bibendum auctor purus cras eget vitae fames elementum. Nunc, tellus eget eget nec at fringilla tempus. Aliquet urna pretium tortor cras donec.""",
                    style: mainFont,
                    textAlign: TextAlign.justify,
                  ),
                ),
                Container(
                  margin:const  EdgeInsets.all(15),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      Text(
                        'Sort by ',
                        style: mainFont,
                      ),
                     const  SizedBox(
                        width: 8,
                      ),
                      DropdownButton<String>(
                        value: 'Rating',
                        onChanged: (String? newValue) {},
                        items:
                            <String>['Rating', 'Recency'].map((String value) {
                          return DropdownMenuItem<String>(
                            value: value,
                            child: Text(value),
                          );
                        }).toList(),
                      ),
                    ],
                  ),
                ),
              ]),
            ),
            // SliverList(
            //   delegate: SliverChildBuilderDelegate(
            //     (BuildContext context, int index) {
            //       return Container(
            //         decoration: BoxDecoration(
            //           borderRadius: BorderRadius.circular(4),
            //           border: Border.all(
            //             color: Color.fromRGBO(0, 0, 0, 0.12),
            //             width: 1,
            //           ),
            //           color: Colors.white,
            //         ),
            //         child: Column(
            //           children: [
            //             Row(
            //               children: [
            //                 ClipOval(
            //                   child: Image.asset('assets/image/image_1.png'),
            //                 ),
            //                 Text(
            //                   'Emre Varol',
            //                   style: mainFont.copyWith(fontSize: 12),
            //                 )
            //               ],
            //             ),
            //             // ... Add other child widgets as needed
            //           ],
            //         ),
            //       );
            //     },
            //     childCount: 3,
            //   ),
            // ),
        
          ],
        ),
        Positioned(
            bottom: 1,
            right: 1,
            child: GestureDetector(
                onTap: () {},
                child:  Container(
                  padding: const EdgeInsets.symmetric(vertical: 12, horizontal: 6),
                  decoration: const BoxDecoration(
                      color: primary,
                      borderRadius:
                          BorderRadius.only(topLeft: Radius.circular(20))),
                  child: Text(
                    "Comment",
                    style: mainFont.copyWith(color: Colors.white),
                  ),
                )))
      ],
    )
    
    );

   
  }
}
