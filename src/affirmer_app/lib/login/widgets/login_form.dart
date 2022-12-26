import 'package:affirmer_app/common/widgets/common_form_padding.dart';
import 'package:affirmer_app/common/widgets/form_fields/common_email_form_field.dart';
import 'package:affirmer_app/common/widgets/form_fields/common_password_field.dart';
import 'package:affirmer_app/login/bloc/login_cubit.dart';
import 'package:affirmer_app/login/bloc/login_state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:formz/formz.dart';

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
            _PasswordField(),
            _SubmitButton(),
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

class _PasswordField extends StatelessWidget {
  const _PasswordField({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final cubit = context.read<LoginCubit>();
    return BlocBuilder<LoginCubit, LoginState>(
      buildWhen: (previous, current) => previous.password != current.password,
      builder: (context, state) {
        return CommonPasswordField(
          key: const Key('__logInForm_passwordInput_textField__'),
          password: state.password,
          onChanged: (value) => cubit.updatePassword(value),
        );
      },
    );
  }
}

class _SubmitButton extends StatelessWidget {
  const _SubmitButton({Key? key}) : super(key: key);

  Widget get _loadingIndicator {
    return const FittedBox(
      fit: BoxFit.scaleDown,
      child: CircularProgressIndicator(),
    );
  }

  Widget _buildButton(BuildContext context, LoginState state) {
    return ElevatedButton(
      key: const Key('__signUpForm_submit_button__'),
      onPressed: state.status.isValidated
          ? () => context.read<LoginCubit>().submit()
          : null,
      child: const Text(
        'SIGN UP',
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<LoginCubit, LoginState>(
      // buildWhen: (previous, current) => previous.status != current.status,
      builder: (context, state) {
        return CommonFormPadding(
          verticalPadding: 12,
          child: state.status.isSubmissionInProgress
              ? _loadingIndicator
              : _buildButton(context, state),
        );
      },
    );
  }
}
