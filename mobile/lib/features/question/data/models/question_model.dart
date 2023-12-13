import 'package:mobile/features/question/domain/domain.dart';

class QuestionModel extends Question{
  QuestionModel({required super.title, required super.content, required super.id, required super.userId});


  factory QuestionModel.fromJson(Map<String, dynamic> json) {
    return QuestionModel(
      id: json['_id'] ?? '',
      title: json['title'] ?? '',
      content: json['content'] ?? '',
      userId: json['userId'] ?? '',
    );
  }

    Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'content': content,
      'userId': userId,
    };
  }


}