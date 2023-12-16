// ignore_for_file: public_member_api_docs, sort_constructors_first

import 'package:dartz/dartz.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/features/comment/domain/entities/comment.dart';
import 'package:mobile/features/comment/domain/repositories/comment_repository.dart';

class GetAllCommentsUsecase extends UseCase<List<Comment>, String> {
  CommentRepository commentRepository;
  GetAllCommentsUsecase({
    required this.commentRepository,
  });
  @override
  Future<Either<Failure, List<Comment>>> call(String questionId) {
    return commentRepository.getComments(questionId:  questionId);
  }
}
