
import 'package:dartz/dartz.dart';
import 'package:mobile/features/question/domain/repositories/repositories.dart';
import '../../../../core/core.dart';


class InsertQuestionUsecase extends UseCase<bool,QuestionParameter>{
     final QuestionRepository questionRepository;

  InsertQuestionUsecase({required this.questionRepository});
  @override
  Future<Either<Failure, bool>> call(QuestionParameter params) async{

    return await questionRepository.insertQuestion(params.title, params.content);


  }

}


class QuestionParameter{
   String title;
  String content;

  QuestionParameter(
      {required this.title,
      required this.content,
      });
      

}