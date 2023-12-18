import 'package:dartz/dartz.dart';
import 'package:mobile/features/question/domain/entities/entities.dart';
import 'package:mobile/features/question/domain/repositories/repositories.dart';
import '../../../../core/core.dart';


class GetQuestionUsecase extends UseCase<Question,String>{
     final QuestionRepository questionRepository;

  GetQuestionUsecase({required this.questionRepository});

  @override
  Future<Either<Failure, Question>> call(String  id) async{

    return await questionRepository.getQuestion(id);


  }

}

