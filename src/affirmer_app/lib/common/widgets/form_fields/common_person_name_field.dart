import 'package:affirmer_app/common/common_keys.dart';
import 'package:affirmer_app/common/models/form_fields/person_name_field.dart';
import 'package:affirmer_app/common/widgets/common_form_padding.dart';
import 'package:flutter/material.dart';

class CommonPersonNameField extends StatefulWidget {
  const CommonPersonNameField({
    Key? key = CommonKeys.commonPersonNameFormField,
    required this.name,
    this.onChanged,
    this.focusNode,
  }) : super(key: key);
  final PersonNameField name;
  final Function(String)? onChanged;
  final FocusNode? focusNode;

  @override
  State<StatefulWidget> createState() => _CommonPersonNameFieldState();
}

class _CommonPersonNameFieldState extends State<CommonPersonNameField> {
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

  String? get _errorText {
    if (widget.name.error != null && !widget.name.pure && _canShowError) {
      switch (widget.name.error!) {
        case PersonNameFieldValidationError.invalid:
          return 'Name cannot contain any of the following characters: * . ( ) / \\ [ ] { } \$ = - & ^ % # @ ! ~ \' "';
        case PersonNameFieldValidationError.empty:
          return 'Name is required.';
      }
    }
    return null;
  }

  @override
  Widget build(BuildContext context) {
    return CommonFormPadding(
      child: TextFormField(
        focusNode: _focusNode,
        initialValue: widget.name.value,
        onChanged: widget.onChanged,
        decoration: InputDecoration(
          isDense: true,
          filled: true,
          fillColor: Colors.white,
          labelText: 'Name *',
          errorText: _errorText,
        ),
      ),
    );
  }
}
