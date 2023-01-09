import 'package:affirmer_app/auth/bloc/auth_cubit.dart';
import 'package:affirmer_app/auth/widgets/auth_screen.dart';
import 'package:affirmer_app/named_routes.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';


class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => AuthCubit(),
      child: MaterialApp(
        title: 'Affirmer',
        theme: ThemeData(
          primarySwatch: Colors.blue,
        ),
        initialRoute: AuthScreen.routeName,
        routes: namedRoutes(context),
      ),
    );
  }
}
