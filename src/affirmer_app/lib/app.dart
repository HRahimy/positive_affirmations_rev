import 'package:affirmer_app/auth/bloc/auth_cubit.dart';
import 'package:affirmer_app/home/widgets/home_screen.dart';
import 'package:affirmer_app/named_routes.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:repositories/api/affirmer_api.dart';

class App extends StatelessWidget {
  const App({
    Key? key,
    required AffirmerApi api,
  })  : _api = api,
        super(key: key);

  final AffirmerApi _api;

  @override
  Widget build(BuildContext context) {
    return MultiRepositoryProvider(
      providers: [
        RepositoryProvider<AffirmerApi>.value(value: _api),
      ],
      child: BlocProvider(
        create: (_) => AuthCubit(),
        child: MaterialApp(
          title: 'Affirmer',
          theme: ThemeData(
            primarySwatch: Colors.blue,
          ),
          initialRoute: HomeScreen.routeName,
          routes: namedRoutes(context),
        ),
      ),
    );
  }
}
