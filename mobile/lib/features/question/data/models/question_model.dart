import 'package:mobile/features/question/domain/domain.dart';

class QuestionModel extends Question{

  
  const QuestionModel({  super.id,super.uId, required super.title, required super.content});


  factory QuestionModel.fromJson(Map<String, dynamic> json) {
    
    
    return QuestionModel(
      id: json['_id'],
      uId: json['_uId'],
      title: json['title'] ?? '',
      content: json['content'] ?? '',
      
    );
  }

    Map<String, dynamic> toJson() {
    return {
      'id':id,
      'uId':uId,
      'title': title,
      'content': content,
   
    };
  }



}