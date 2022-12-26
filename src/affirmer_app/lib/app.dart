import 'package:affirmer_app/named_routes.dart';
import 'package:flutter/material.dart';

import 'login/widgets/login_screen.dart';

class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Affirmer',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      initialRoute: LoginScreen.routeName,
      routes: namedRoutes(context),
    );
  }
}
