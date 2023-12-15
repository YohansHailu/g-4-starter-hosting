import 'package:get_it/get_it.dart';
import 'package:mobile/core/core.dart';
import 'package:mobile/features/question/data/data.dart';
import 'package:mobile/features/question/domain/domain.dart';
import 'package:mobile/features/question/presentation/bloc/bloc.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';

final sq=GetIt.instance;

Future <void> init()async{




// ! Features

// * First let's register the bloc
sq.registerFactory(() => QuestionBloc(getQuestionUsecase: sq(), insertQuestionUsecase: sq(), deleteQuestionUsecase: sq(), updateQuestionUsecase: sq()));



// * Then let's register Usecases


// ? And remember to to use registerFactory() for bloc register only , but for the rest let's try to use just registerLazySingleton() or registerSingleton();
sq.registerLazySingleton(() => GetQuestionUsecase(questionRepository: sq()));
sq.registerLazySingleton(() => InsertQuestionUsecase(questionRepository: sq()));
sq.registerLazySingleton(() => UpdateQuestionUsecase(questionRepository: sq()));
sq.registerLazySingleton(() => DeleteQuestionUsecase(questionRepository: sq()));


// * Repository 


sq.registerLazySingleton<QuestionRepository>(() =>QuestionRepositoryImp(remoteQuestionDataSource: sq()) );


// * Data sources

sq.registerLazySingleton<RemoteQuestionDataSource>(() => RemoteQuestionDataSourceImp(client: sq()));

// ! Core
// * Network
// sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));
sq.registerLazySingleton<NetworkInfo>(() =>  NetworkInfoImpl(internetConnectionChecker: sq()));

// ! External (Packages)

  sq.registerLazySingleton(() => http.Client());
  sq.registerLazySingleton(() => InternetConnectionChecker());
}