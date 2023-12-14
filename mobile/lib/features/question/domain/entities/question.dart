import 'package:equatable/equatable.dart';

class Question extends Equatable {
  String? id;
  String? uId;
  String title;
  String content;


  Question(
      {
        this.id ,
        this.uId,
        required this.title,
      required this.content,
      });
      

      
 @override
 List<Object?> get props => [id,uId,title, content];


}
