import 'package:affirmer_app/login/widgets/login_screen.dart';
import 'package:flutter/widgets.dart';

Map<String, Widget Function(BuildContext context)> namedRoutes(
    BuildContext context) {
  return {
    LoginScreen.routeName: (context) => const LoginScreen(),
  };
}
