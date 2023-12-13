import 'package:dartz/dartz.dart';
import 'package:mobile/features/question/domain/domain.dart';

import '../../../../core/core.dart';

class QuestionRepositoryImp implements QuestionRepository{
  @override
  Future<Either<Failure, bool>> insertQuestion(String title, String content) {
     // TODO: implement DeleteQuestion
    throw UnimplementedError();
  }
  
  @override
  Future<Either<Failure, Question>> DeleteQuestion(String id) {
    // TODO: implement DeleteQuestion
    throw UnimplementedError();
  }
  
  @override
  Future<Either<Failure, Question>> EditQuestion(String id) {
    // TODO: implement EditQuestion
    throw UnimplementedError();
  }
  
  @override
  Future<Either<Failure, List<Question>>> getQuestions() {
    // TODO: implement getQuestions
    throw UnimplementedError();
  }
}
