import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/error.dart';


import '../entities/question.dart';

abstract class QuestionRepository {
  
  Future<Either<Failure, List<Question>>> getQuestions();
  
  Future<Either<Failure, bool>> insertQuestion(String title,String content);
  Future<Either<Failure, Question>> EditQuestion(String id);
  Future<Either<Failure, Question>> DeleteQuestion(String id);
}
