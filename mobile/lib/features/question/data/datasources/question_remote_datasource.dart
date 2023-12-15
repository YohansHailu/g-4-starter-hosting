import 'dart:convert';

import 'package:mobile/core/constants/constants.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/features/question/data/models/question_model.dart';
import 'package:mobile/features/question/domain/domain.dart';
import 'package:http/http.dart' as http;

abstract class RemoteQuestionDataSource {
  Future<List<Question>> getQuestions();

  Future<QuestionModel> insertQuestion({required uId,required String title, required String content});
  Future<Question> getQuestion({required String id});
  Future<Question> updateQuestion({required id,required uId,required String title, required String content});
  Future<void> deleteQuestion({required String id});

}

class RemoteQuestionDataSourceImp implements RemoteQuestionDataSource {
  late http.Client client;

  RemoteQuestionDataSourceImp({required this.client});

  @override
  Future<QuestionModel> insertQuestion(
      {required uId,required String title, required String content}) async {
        String token = "";// User token
    try {
      Map data;
      data = {'uId':uId,'title': title, 'content': content};

      var body = json.encode(data);
      final response = await client.post(
        Uri.parse('$insertQuestionApiLink'),
        body: body,
        headers: {
          'Content-Type': 'application/json',
           "Authorization": "Bearer ${token.toString()}"
        },
      );

      return QuestionModel.fromJson(jsonDecode(response.body));
    } catch (e) {
      throw ServerException();
    }
  }

  @override
  Future<Question> getQuestion({required String id}) async {
    String token = "";// User token
    final response = await client.get(Uri.parse('$getQuestionApiLink/$id'), headers: {
      'Content-Type': 'application/json',
       "Authorization": "Bearer ${token.toString()}"
    });
    if (response.statusCode == 200) {
      final responseJson = json.decode(response.body)['data'];
      if (responseJson['error'] == null) {
        return QuestionModel.fromJson(jsonDecode(response.body));
      }
    }
    throw ServerException();
  }



  @override
  Future<Question> updateQuestion({required id, required uId, required String title, required String content})async {
    String token = "";// User token
    try {
      Map data;
      data = {'uId':uId,'title': title, 'content': content};

      var body = json.encode(data);
      final response = await client.put(
        Uri.parse('$updateQuestionApiLink/$id'),
        body: body,
        headers: {
          'Content-Type': 'application/json',
           "Authorization": "Bearer ${token.toString()}"
        },
      );
      return QuestionModel.fromJson(jsonDecode(response.body));

     
    } catch (e) {
      throw ServerException();
    }
  }

  @override
  Future<void> deleteQuestion({required String id})async {
    String token = "";// User token
try {
     final response = await client.delete(
        Uri.parse('$updateQuestionApiLink/$id'),
       
        headers: {
          'Content-Type': 'application/json',
           "Authorization": "Bearer ${token.toString()}"
        },
      );

     
    } catch (e) {
      throw ServerException();
    }

   
  }

  @override
  Future<List<Question>> getQuestions() async {
    // TODO: implement getQuestions
    throw UnimplementedError();
  }
  
}
