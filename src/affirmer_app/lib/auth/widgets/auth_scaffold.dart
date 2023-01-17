import 'package:affirmer_app/auth/bloc/auth_cubit.dart';
import 'package:affirmer_app/common/widgets/common_form_padding.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class AuthScaffold extends StatelessWidget {
  const AuthScaffold({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: const [_AuthRedirectButton()],
        ),
      ),
    );
  }
}

class _AuthRedirectButton extends StatelessWidget {
  const _AuthRedirectButton({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return CommonFormPadding(
      child: ElevatedButton(
        onPressed: () => context.read<AuthCubit>().tryAuth(),
        child: const Text('LOG IN/SIGN UP'),
      ),
    );
  }
}
