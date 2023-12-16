

import 'package:dartz/dartz.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/features/comment/domain/repositories/comment_repository.dart';

class DeleteCommentUsecase extends UseCase<bool,String >{

  final CommentRepository commentRepository;

  DeleteCommentUsecase({required this.commentRepository});

  @override
  Future<Either<Failure, bool>> call(String id) async{
    return await commentRepository.deleteComment(id:id);
   
  }

}