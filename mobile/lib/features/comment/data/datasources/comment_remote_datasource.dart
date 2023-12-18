
import 'dart:convert';

import 'package:mobile/core/core.dart';
import 'package:mobile/features/comment/data/models/comment_model.dart';
import 'package:mobile/features/comment/domain/entities/comment.dart';
import 'package:http/http.dart' as http;

abstract class RemoteCommentDatasource {
  Future<List<Comment>>getComments({required questionId});
  Future<Comment> getComment({required String id});
  Future<Comment> insertComment({required questionId, required uId, required String commentContent});
  Future<bool> deleteComment({required String id});

}

class RemoteCommentDatasourceImp implements RemoteCommentDatasource{

  late http.Client client; 

  @override
  Future<bool> deleteComment({required String id}) {
  
    String token="";
    return client.delete(Uri.parse('$deleteCommentApiLink/$id'), headers: {
      'Content-Type': 'application/json',
       "Authorization": "Bearer ${token.toString()}"
    }).then((value) {
      if (value.statusCode == 200) {
        final responseJson = json.decode(value.body)['data'];
        if (responseJson['error'] == null) {
          return true;
        }
      }
      
else {
      throw ServerException();
    }
      return false;
    });
    
  
  }

  @override
  Future<Comment> getComment({required String id})async {

    String token="";
    final response =await client.get(Uri.parse('$getCommentApiLink/$id'), headers: {
      'Content-Type': 'application/json',
       "Authorization": "Bearer ${token.toString()}"
    });
    if (response.statusCode == 200) {
      final responseJson = json.decode(response.body)['data'];
      if (responseJson['error'] == null) {
        return CommentModel.fromJson(responseJson);
      }
    }else {
      throw ServerException();
    }
   
    throw UnimplementedError();
  }

  @override
  Future<List<Comment>> getComments({required questionId})async {

     String token = "";// User token
    final response = await client.get(Uri.parse('$getQuestionApiLink/$questionId'), headers: {
      'Content-Type': 'application/json',
       "Authorization": "Bearer ${token.toString()}"
    });
    if (response.statusCode == 200) {
      final responseJson = json.decode(response.body)['data'];
      if (responseJson['error'] == null) {
       final comments = jsonDecode(response.body);
      final temp = [];

      for (var v in comments) {
        temp.add(v);
      }

      return CommentModel.commentList(temp);
      }
    }else {
      throw ServerException();
    }
   
    throw UnimplementedError();
  }

  @override
  Future<CommentModel> insertComment({required questionId, required uId, required String commentContent})async {
    String token = "";// User token
    try {
      Map data;
      data = {'questionId':questionId,'commentContent':commentContent,'uId':uId,};

      var body = json.encode(data);
      final response = await client.post(
        Uri.parse('$insertCommentApiLink'),
        body: body,
        headers: {
          'Content-Type': 'application/json',
           "Authorization": "Bearer ${token.toString()}"
        },
      );

      return CommentModel.fromJson(jsonDecode(response.body));
    } catch (e) {
      throw ServerException();
    }

  }

}