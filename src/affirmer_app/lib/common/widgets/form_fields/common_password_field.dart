import 'package:affirmer_app/common/common_keys.dart';
import 'package:affirmer_app/common/models/form_fields/password_field.dart';
import 'package:affirmer_app/common/widgets/common_form_padding.dart';
import 'package:flutter/material.dart';

class CommonPasswordField extends StatefulWidget {
  const CommonPasswordField({
    Key? key = CommonKeys.commonPasswordFormField,
    required this.password,
    this.confirmingPassword,
    this.onChanged,
    this.focusNode,
  }) : super(key: key);
  final PasswordField password;
  final PasswordField? confirmingPassword;
  final Function(String)? onChanged;
  final FocusNode? focusNode;

  @override
  State<StatefulWidget> createState() => _CommonPasswordFieldState();
}

class _CommonPasswordFieldState extends State<CommonPasswordField> {
  late FocusNode _focusNode;
  late bool _canShowError;

  @override
  void initState() {
    _focusNode = widget.focusNode ?? FocusNode();
    _focusNode.addListener(_focusListener);
    _canShowError = !_focusNode.hasFocus;
    super.initState();
  }

  @override
  void dispose() {
    _focusNode.removeListener(_focusListener);
    super.dispose();
  }

  void _focusListener() {
    setState(() {
      _canShowError = !_focusNode.hasFocus;
    });
  }

  bool get _showPasswordsNotMatchingError {
    if (widget.confirmingPassword == null) return false;
    if (!widget.confirmingPassword!.pure &&
        widget.confirmingPassword!.value.isNotEmpty &&
        widget.password.value != widget.confirmingPassword!.value) {
      return true;
    }
    return false;
  }

  String? get _errorText {
    if (widget.password.error != null &&
        !widget.password.pure &&
        _canShowError) {
      switch (widget.password.error) {
        case PasswordFieldValidationError.empty:
          return 'Password is required';
        case PasswordFieldValidationError.invalid:
          return 'Must be at least 8 characters containing letters and numbers';
        default:
          break;
      }
    }

    if (!widget.password.pure &&
        widget.password.value.isNotEmpty &&
        _canShowError &&
        _showPasswordsNotMatchingError) {
      return 'Passwords don\'t match.';
    }

    return null;
  }

  @override
  Widget build(BuildContext context) {
    return CommonFormPadding(
      verticalPadding: 12,
      child: TextFormField(
        focusNode: _focusNode,
        initialValue: widget.password.value,
        onChanged: widget.onChanged,
        obscureText: true,
        decoration: InputDecoration(
          labelText: widget.confirmingPassword != null
              ? 'Confirm password *'
              : 'Password *',
          isDense: true,
          fillColor: Colors.white,
          filled: true,
          errorText: _errorText,
        ),
      ),
    );
  }
}
