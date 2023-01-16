import 'package:affirmer_app/auth/bloc/auth_cubit.dart';
import 'package:affirmer_app/common/widgets/common_form_padding.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:repositories/api/affirmer_api.dart';

class AuthScaffold extends StatelessWidget {
  AuthScaffold({Key? key})
      : api = AffirmerApi.create(
            baseUrl: 'https://25d9-176-42-134-191.eu.ngrok.io/api'),
        super(key: key);

  final AffirmerApi api;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            _AuthRedirectButton(),
            CommonFormPadding(
              child: ElevatedButton(
                onPressed: () => api.getAffirmations(),
                child: const Text('LOG IN/SIGN UP'),
              ),
            )
          ],
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
