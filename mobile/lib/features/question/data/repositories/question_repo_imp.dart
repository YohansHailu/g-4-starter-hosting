import 'package:dartz/dartz.dart';
import 'package:mobile/features/question/data/datasources/question_remote_datasource.dart';
import 'package:mobile/features/question/data/models/question_model.dart';
import 'package:mobile/features/question/domain/domain.dart';

import '../../../../core/core.dart';

class QuestionRepositoryImp implements QuestionRepository{
  final RemoteQuestionDataSource remoteQuestionDataSource;

  QuestionRepositoryImp({required this.remoteQuestionDataSource});
  @override
  Future<Either<Failure, QuestionModel>> insertQuestion({required String content, required String title, required dynamic uId}) async{


 try {
   final remotedata= await remoteQuestionDataSource.insertQuestion(title: title, content: content,uId: uId);
     
      return Right(remotedata);
    } on ServerException {
      return Left(ServerFailure());
    }
   
  }
  
 
  @override
  Future<Either<Failure, bool>> deleteQuestion(String id) {
   
   
    throw UnimplementedError();
  }
  
  @override
  Future<Either<Failure, Question>> getQuestion(String id) {


   
    throw UnimplementedError();
  }
  
  @override
  Future<Either<Failure, Question>> updateQuestion(Question question) async{
   
   try {
       final remotedata= await remoteQuestionDataSource.updateQuestion(id: question.id,uId: question.uId, title: question.title, content: question.content);
     
      return Right(remotedata);
    } on ServerException {
      return Left(ServerFailure());
    }

    
  }
  
  @override
  Future<Either<Failure, List<Question>>> getQuestions() {
    // TODO: implement getQuestions
    throw UnimplementedError();
  }
}
