import 'package:bloc/bloc.dart';

/// {@template app_observer}
/// [BlocObserver] for the counter application which
/// observes all state changes.
/// {@endtemplate}
class AppObserver extends BlocObserver {
  @override
  void onChange(BlocBase<dynamic> bloc, Change<dynamic> change) {
    super.onChange(bloc, change);
    // ignore: avoid_print
    print('${bloc.runtimeType} change');
  }
}
