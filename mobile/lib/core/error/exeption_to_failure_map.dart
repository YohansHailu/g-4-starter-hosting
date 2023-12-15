import 'exception.dart';
import 'failure.dart';

Failure mapExceptionToFailure(dynamic e) {
  if (e is ServerException) {
    return ServerFailure();
  } else if (e is UnauthorizedRequestException) {
    return UnauthorizedRequestFailure();
  } else if (e is CacheException) {
    return CacheFailure();
  } else {
    return AnonymousFailure();
  }
}
