import 'package:affirmer_app/affirmations/widgets/affirmation_list.dart';
import 'package:flutter/material.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({Key? key}) : super(key: key);
  static const String routeName = '/home';

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      body: AffirmationList(),
    );
  }
}
