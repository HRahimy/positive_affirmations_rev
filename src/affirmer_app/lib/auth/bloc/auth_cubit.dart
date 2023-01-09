import 'package:affirmer_app/auth/bloc/auth_state.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter_appauth/flutter_appauth.dart';

class AuthCubit extends Cubit<AuthState> {
  AuthCubit() : super(const AuthState());

  Future<void> tryAuth() async {
    FlutterAppAuth appAuth = const FlutterAppAuth();

    final AuthorizationTokenResponse? result =
    await appAuth.authorizeAndExchangeCode(
      AuthorizationTokenRequest(
        'flutter',
        'com.affirmer.app://callback',
        discoveryUrl:
        'https://10.0.2.2:5001/.well-known/openid-configuration',
        scopes: ['openid', 'profile', 'offline_access', 'read:todos'],
      ),
    );

    if (result != null && kDebugMode) {
      print(result.accessTokenExpirationDateTime.toString());
    }
  }
}
