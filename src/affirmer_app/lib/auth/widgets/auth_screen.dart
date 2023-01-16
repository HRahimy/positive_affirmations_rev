import 'package:affirmer_app/auth/widgets/auth_scaffold.dart';
import 'package:flutter/material.dart';

class AuthScreen extends StatelessWidget {
  const AuthScreen({Key? key}) : super(key: key);
  static const String routeName = 'auth';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: AuthScaffold(),
    );
  }
}
