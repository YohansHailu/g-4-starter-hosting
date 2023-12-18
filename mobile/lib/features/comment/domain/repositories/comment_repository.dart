

import 'package:dartz/dartz.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/features/comment/domain/entities/entities.dart';

abstract class CommentRepository{


    
  Future<Either<Failure, List<Comment>>> getComments({required String questionId});
  Future<Either<Failure, Comment>> getComment({required String id});  
  Future<Either<Failure, Comment>> insertComment({required questionId,required uId,required String commentContent});
  Future<Either<Failure, bool>> deleteComment({required String id});
}