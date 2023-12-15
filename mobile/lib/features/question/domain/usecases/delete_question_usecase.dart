
import 'package:dartz/dartz.dart';
import 'package:mobile/features/question/domain/repositories/repositories.dart';
import '../../../../core/core.dart';


class DeleteQuestionUsecase extends UseCase<bool,String>{

    final QuestionRepository questionRepository;

  DeleteQuestionUsecase({required this.questionRepository});

  @override
  Future<Either<Failure, bool>> call(String id) async{
    return await questionRepository.deleteQuestion(id);
   
  }

}