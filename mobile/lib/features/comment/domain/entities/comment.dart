
import 'package:equatable/equatable.dart';

class Comment extends Equatable{


  final String? id;
  final String? uId;
  final String questionId;
  final String commentContent;

  const Comment(
      {
        this.id ,
        this.uId,
        required this.commentContent,
        required this.questionId
      });


      
  @override
  List<Object?> get props => [id,uId,questionId,commentContent];

}