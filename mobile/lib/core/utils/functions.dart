
import '../error/failure.dart';

String mapFailerToMessage(Failure failure){
  switch(failure.runtimeType){
    case ServerFailure:
          return "Server failure message"; 
    case CacheFailure:
          return "Cache faiure";
    default:
      return "Unexpected error";  
         }
}