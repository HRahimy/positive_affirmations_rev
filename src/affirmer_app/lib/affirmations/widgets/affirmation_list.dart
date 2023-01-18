import 'package:affirmer_app/affirmations/bloc/affirmation_list/affirmation_list_cubit.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:repositories/api/affirmer_api.dart';

class AffirmationList extends StatelessWidget {
  const AffirmationList({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => AffirmationListCubit(
        api: RepositoryProvider.of<AffirmerApi>(context),
      )..loadAffirmations(),
      child: _View(),
    );
  }
}

class _View extends StatelessWidget {
  const _View({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<AffirmationListCubit, AffirmationListState>(
      builder: (context, state) {
        return Center(
          child: SingleChildScrollView(
            child: Column(
              children: state.affirmations.map((e) => Text(e.title)).toList(),
            ),
          ),
        );
      },
    );
  }
}
