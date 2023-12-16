

import 'package:dartz/dartz.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/features/comment/domain/entities/comment.dart';
import 'package:mobile/features/comment/domain/repositories/comment_repository.dart';

class GetCommentUsecase extends UseCase<Comment,String>{

  final CommentRepository commentRepository;

  GetCommentUsecase({required this.commentRepository});


  @override
  Future<Either<Failure, Comment>> call(String id) {

      return commentRepository.getComment(id: id);
   
  }

}