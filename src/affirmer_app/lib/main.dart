import 'package:affirmer_app/app.dart';
import 'package:affirmer_app/app_observer.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter/material.dart';

void main() {
  Bloc.observer = AppObserver();
  runApp(const App());
}
