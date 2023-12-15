part of 'question_bloc.dart';



abstract class QuestionEvent extends Equatable {
  const QuestionEvent();

  @override
  List<Object> get props => [];
}

class AllQuestionsFetchEvent extends QuestionEvent {}

class GetQuestionEvent extends QuestionEvent{
  final String id;

  const GetQuestionEvent({required this.id});
  
 
}

class QuestionPostEvent extends QuestionEvent{
  final String uId;
  final String title;
  final String content;

  const QuestionPostEvent({required this.uId,required this.title,required this.content});
  

 
}


class EditQuestionEvent extends QuestionEvent{

  final String id;
  const EditQuestionEvent({required this.id});




}


class QuestionUpdateEvent extends QuestionEvent{
  final String id;
  final String uId;
  final String title;
  final String content;

  const QuestionUpdateEvent({required this.id,required this.uId,required this.title,required this.content});
  


}

class QuestionDeleteEvent extends QuestionEvent{
  final String id;

  const QuestionDeleteEvent({required this.id});
 
}




