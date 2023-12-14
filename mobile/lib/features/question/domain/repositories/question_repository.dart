import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/error.dart';
import 'package:mobile/features/question/data/models/question_model.dart';


import '../entities/question.dart';

abstract class QuestionRepository {
  
  Future<Either<Failure, List<Question>>> getQuestions();
  Future<Either<Failure, Question>> getQuestion(String id);  
  Future<Either<Failure, QuestionModel>> insertQuestion({required uId,required String title,required String content});
  Future<Either<Failure, void>> updateQuestion(Question question);
  Future<Either<Failure, bool>> deleteQuestion(String id);
}
