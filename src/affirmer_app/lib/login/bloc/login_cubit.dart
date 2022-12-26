import 'package:affirmer_app/common/models/form_fields/email_field.dart';
import 'package:affirmer_app/common/models/form_fields/password_field.dart';
import 'package:affirmer_app/login/bloc/login_state.dart';
import 'package:bloc/bloc.dart';
import 'package:formz/formz.dart';

class LoginCubit extends Cubit<LoginState> {
  LoginCubit() : super(const LoginState());

  void updateEmail(String input) {
    final email = EmailField.dirty(input);
    emit(state.copyWith(
      email: email,
      password: state.password,
      status: Formz.validate([
        email,
        state.password,
      ]),
    ));
  }

  void updatePassword(String input) {
    final password = PasswordField.dirty(input);
    emit(state.copyWith(
      password: password,
      status: Formz.validate([
        state.email,
        password,
      ]),
    ));
  }

  void submit() {}
}
