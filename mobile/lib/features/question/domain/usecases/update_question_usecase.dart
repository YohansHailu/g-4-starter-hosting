

import 'package:dartz/dartz.dart';
import 'package:mobile/features/question/domain/entities/question.dart';
import 'package:mobile/features/question/domain/repositories/repositories.dart';
import '../../../../core/core.dart';


class UpdateQuestionUsecase extends UseCase<void,UpdateQuestionParameter>{
     final QuestionRepository questionRepository;

  UpdateQuestionUsecase({required this.questionRepository});
  @override
  Future<Either<Failure, Question>> call(UpdateQuestionParameter params) async{

    return await questionRepository.updateQuestion(Question( id: params.id,    uId:   params.uId, title: params.title,content: params.content));


  }

}


class UpdateQuestionParameter{
  String title;
  String content;
  final String? id;
  final String uId;

  UpdateQuestionParameter({
     this.id,
    required this.uId,
    required this.title,
    required this.content,
  });
      

}