
import 'package:dartz/dartz.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/comment/comment.dart';
import 'package:mobile/features/comment/domain/entities/comment.dart';
import 'package:mobile/features/comment/domain/repositories/comment_repository.dart';

class CommentRepositoryImp implements CommentRepository{

  RemoteCommentDatasource remoteCommentDatasource;
  CommentRepositoryImp({required this.remoteCommentDatasource});
  @override
  Future<Either<Failure, bool>> deleteComment({required String id})async {
    try{
    final remotedata= await remoteCommentDatasource.deleteComment(id: id);

     return Right(remotedata);
}on ServerException {
      return Left(ServerFailure());
    }
   
  }

  @override
  Future<Either<Failure, Comment>> getComment({required String id}) async{
   try{
    final remotedata= await remoteCommentDatasource.getComment(id: id);

     return Right(remotedata);
}on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, List<Comment>>> getComments({required String questionId})async {
    
    try{
    final remotedata= await remoteCommentDatasource.getComments(questionId: questionId);

     return Right(remotedata);
}on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, Comment>> insertComment({required questionId, required uId, required String commentContent})async {
    
  try{
    final remotedata= await remoteCommentDatasource.insertComment(questionId: questionId, uId: uId, commentContent: commentContent);

     return Right(remotedata);
}on ServerException {
      return Left(ServerFailure());
    }
  }

}