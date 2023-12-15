import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/core/utils/functions.dart';
import 'package:mobile/features/question/domain/domain.dart';

part 'question_event.dart';
part 'question_state.dart';

class QuestionBloc extends Bloc<QuestionEvent, QuestionState> {
  final GetQuestionUsecase getQuestionUsecase;
  final UpdateQuestionUsecase updateQuestionUsecase;
  final DeleteQuestionUsecase deleteQuestionUsecase;
  final InsertQuestionUsecase insertQuestionUsecase;

  QuestionBloc({
    required this.getQuestionUsecase,
    required this.insertQuestionUsecase,
    required this.deleteQuestionUsecase,
    required this.updateQuestionUsecase,
  }) : super(QuestionInitial()) {
    on<QuestionEvent>((event, emit) async {
      if (event is GetQuestionEvent) {
        final failureOrQuestion = await getQuestionUsecase.call(event.id);
        failureOrQuestion.fold((failure) {
          emit(QuestionError(message: mapFailerToMessage(failure)));
        }, (question) {
          emit(QuestionLoaded(question: question));
        });
      } else if (event is QuestionPostEvent) {
        final failureOrQuestion = await insertQuestionUsecase.call(
            QuestionParameter(
                uId: event.uId, title: event.title, content: event.content));
        failureOrQuestion.fold((failure) {
          emit(QuestionError(message: mapFailerToMessage(failure)));
        }, (question) {
          emit(QuestionInserted(question: question,message: "Question Inserted Successfully"));
        });
      } else if (event is QuestionUpdateEvent) {
        final failureOrQuestion = await updateQuestionUsecase.call(
            UpdateQuestionParameter(
                id: event.id,
                uId: event.uId,
                title: event.title,
                content: event.content));
        failureOrQuestion.fold((failure) {

          emit(QuestionError(message: mapFailerToMessage(failure)));
        }, (question) {
          emit(QuestionUpdated(question: question,message: "Question Updated Successfully"));
        });
      } else if (event is QuestionDeleteEvent) {
        final failureOrQuestion = await deleteQuestionUsecase.call(event.id);
        failureOrQuestion.fold((failure) {
          emit(QuestionError(message: mapFailerToMessage(failure)));
        }, (question) {

          emit(QuestionDeleted(message: "Question Deleted Successfully"));
        });
      }
    });
  }
}
