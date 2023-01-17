import 'package:affirmer_app/auth/widgets/auth_screen.dart';
import 'package:affirmer_app/home/widgets/home_screen.dart';
import 'package:flutter/widgets.dart';

Map<String, Widget Function(BuildContext context)> namedRoutes(
    BuildContext context) {
  return {
    AuthScreen.routeName: (context) => const AuthScreen(),
    HomeScreen.routeName: (context) => const HomeScreen()
  };
}
