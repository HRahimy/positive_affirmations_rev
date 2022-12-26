import 'package:affirmer_app/common/widgets/form_fields/common_email_form_field.dart';
import 'package:affirmer_app/login/bloc/login_cubit.dart';
import 'package:affirmer_app/login/bloc/login_state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginForm extends StatelessWidget {
  const LoginForm({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: const [
            _EmailField(),
          ],
        ),
      ),
    );
  }
}

class _EmailField extends StatelessWidget {
  const _EmailField({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final cubit = context.read<LoginCubit>();
    return BlocBuilder<LoginCubit, LoginState>(
      buildWhen: (previous, current) => previous.email != current.email,
      builder: (context, state) {
        return CommonEmailFormField(
          key: const Key('__logInForm_emailInput_textField__'),
          email: state.email,
          onChanged: (value) => cubit.updateEmail(value),
        );
      },
    );
  }
}
