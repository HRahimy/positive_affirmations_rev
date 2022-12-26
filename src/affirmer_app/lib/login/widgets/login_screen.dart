import 'package:affirmer_app/login/bloc/login_cubit.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({Key? key}) : super(key: key);
  static const String routeName = 'login';

  @override
  Widget build(BuildContext context) {
    return BlocProvider<LoginCubit>(
      create: (_) => LoginCubit(),
      child: Scaffold(
        appBar: AppBar(title: const Text('Login')),
        body: const Padding(
          padding: EdgeInsets.all(8),
          child: Center(
            child: Text('Login screen'),
          ),
        ),
      ),
    );
  }
}
