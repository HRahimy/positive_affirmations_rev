import 'package:affirmer_app/app.dart';
import 'package:affirmer_app/app_observer.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter/material.dart';
import 'package:repositories/api/affirmer_api.dart';

void main() {
  Bloc.observer = AppObserver();
  final AffirmerApi api =
      AffirmerApi.create(baseUrl: 'https://6e73-46-106-112-221.eu.ngrok.io/api');
  runApp(App(api: api));
}
