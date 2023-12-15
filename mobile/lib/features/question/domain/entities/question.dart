import 'package:equatable/equatable.dart';

class Question extends Equatable {
  final String? id;
  final String? uId;
  final String title;
  final String content;


  const Question(
      {
        this.id ,
        this.uId,
        required this.title,
      required this.content,
      });
      

      
 @override
 List<Object?> get props => [id,uId,title, content];


}
