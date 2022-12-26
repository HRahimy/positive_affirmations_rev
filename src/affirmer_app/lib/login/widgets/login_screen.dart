import 'package:affirmer_app/login/bloc/login_cubit.dart';
import 'package:affirmer_app/login/widgets/login_form.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({Key? key}) : super(key: key);
  static const String routeName = 'login';

  @override
  Widget build(BuildContext context) {
    return BlocProvider<LoginCubit>(
      create: (_) => LoginCubit(),
      child: const Scaffold(
        body: LoginForm(),
      ),
    );
  }
}
