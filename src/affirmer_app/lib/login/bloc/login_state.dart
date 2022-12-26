import 'package:affirmer_app/common/models/form_fields/email_field.dart';
import 'package:affirmer_app/common/models/form_fields/password_field.dart';
import 'package:equatable/equatable.dart';
import 'package:formz/formz.dart';

class LoginState extends Equatable {
  const LoginState({
    this.email = const EmailField.pure(),
    this.password = const PasswordField.pure(),
    this.status = FormzStatus.pure,
    this.errorMessage = '',
  });

  final EmailField email;
  final PasswordField password;
  final FormzStatus status;
  final String errorMessage;

  LoginState copyWith({
    EmailField? email,
    PasswordField? password,
    FormzStatus? status,
    String? errorMessage,
  }) {
    return LoginState(
      email: email ?? this.email,
      password: password ?? this.password,
      status: status ?? this.status,
      errorMessage: errorMessage ?? this.errorMessage,
    );
  }

  @override
  List<Object> get props => [email, password, status, errorMessage];
}
