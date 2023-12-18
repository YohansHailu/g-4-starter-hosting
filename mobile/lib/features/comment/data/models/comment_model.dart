import 'package:mobile/features/comment/domain/entities/comment.dart';

class CommentModel extends Comment{
  
    
    CommentModel({required super.id,required super.uId, required super.commentContent, required super.questionId});
  
    factory CommentModel.fromJson(Map<String, dynamic> json) {
      
      
      return CommentModel(
        id: json['_id'],
        uId: json['_uId'],
        commentContent: json['commentContent'] ?? '', 
        questionId: json['commentContent'] ?? '',
        
      );
    }
  
      Map<String, dynamic> toJson() {
      return {
        'id':id,
        'uId':uId,
        'commentContent': commentContent,
        'questionId':questionId
    
      };
    }


      static List<CommentModel> commentList(List data) {
    List<CommentModel> ans = data.map((comment) {
      return CommentModel.fromJson(comment);
    }).toList();

    return ans;
  }
}