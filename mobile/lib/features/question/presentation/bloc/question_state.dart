part of 'question_bloc.dart';

@immutable
sealed class QuestionState {}

final class QuestionInitial extends QuestionState {}

final class QuestionLoading extends QuestionState {}

final class ListQuestionLoading extends QuestionState {}

final class QuestionLoaded extends QuestionState {
  final Question question;

   QuestionLoaded({required this.question});
}




final class QuestionInserted extends QuestionState{
final Question question;
final String message;


   QuestionInserted({required this.question,required this.message});

}



final class QuestionUpdated extends QuestionState{
final Question question;
final String message;

   QuestionUpdated({required this.question,required this.message});
}




final class QuestionDeleted extends QuestionState{
    final String message;

  QuestionDeleted({required this.message});
}


final class QuestionError extends QuestionState{
   final String message;

  QuestionError({required this.message});
}


