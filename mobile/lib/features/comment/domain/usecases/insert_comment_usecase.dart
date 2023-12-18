import 'package:dartz/dartz.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/features/comment/domain/entities/comment.dart';
import 'package:mobile/features/comment/domain/repositories/comment_repository.dart';

class InsertCommentUsecase extends UseCase<Comment,CommentParameter>{


final CommentRepository commentRepository;

InsertCommentUsecase({required this.commentRepository});

  @override
  Future<Either<Failure, Comment>> call(CommentParameter params) {
    

    return commentRepository.insertComment(questionId: params.questionId, uId: params.uId, commentContent: params.commentContent);
  }
}

class CommentParameter{

   final String? id;
  final String? uId;
  final String questionId;
  final String commentContent;

  const CommentParameter(
      {
        this.id ,
        this.uId,
        required this.commentContent,
        required this.questionId
      });
}