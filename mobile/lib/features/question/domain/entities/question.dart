import 'package:equatable/equatable.dart';

class Question extends Equatable {
  String title;
  String content;
  String id;
  String userId;

  Question(
      {required this.title,
      required this.content,
      required this.id,
      required this.userId});
      

      
        @override
        // TODO: implement props
        List<Object?> get props => throw UnimplementedError();


}
