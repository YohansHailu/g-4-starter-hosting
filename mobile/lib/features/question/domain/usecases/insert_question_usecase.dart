import 'package:dartz/dartz.dart';
import 'package:mobile/features/question/data/models/question_model.dart';
import 'package:mobile/features/question/domain/repositories/repositories.dart';
import '../../../../core/core.dart';

class InsertQuestionUsecase extends UseCase<QuestionModel, QuestionParameter> {
  final QuestionRepository questionRepository;

  InsertQuestionUsecase({required this.questionRepository});
  @override
  Future<Either<Failure, QuestionModel>> call(QuestionParameter params) async {
    return await questionRepository.insertQuestion(     uId:   params.uId, title: params.title,content: params.content);
  }
}

class QuestionParameter {
  String title;
  String content;
  final String? id;
  final String uId;

  QuestionParameter({
    this.id,
    required this.uId,
    required this.title,
    required this.content,
  });
}
