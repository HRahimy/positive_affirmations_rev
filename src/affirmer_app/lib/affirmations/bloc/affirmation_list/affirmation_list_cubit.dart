import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:formz/formz.dart';
import 'package:repositories/api/affirmer_api.dart';
import 'package:repositories/api/models/affirmation_list_item_dto.dart';

part 'affirmation_list_state.dart';

class AffirmationListCubit extends Cubit<AffirmationListState> {
  AffirmationListCubit({required AffirmerApi api})
      : _api = api,
        super(const AffirmationListState());

  final AffirmerApi _api;

  Future<void> loadAffirmations() async {
    emit(state.copyWith(loadingStatus: FormzStatus.submissionInProgress));
    try {
      final affirmations = await _api.getAffirmations();

      emit(state.copyWith(
        affirmations: affirmations.items,
        page: state.page + 1,
        loadingStatus: FormzStatus.submissionSuccess,
      ));
    } catch (_) {
      emit(state.copyWith(
        loadingStatus: FormzStatus.submissionFailure,
        loadingError: _.toString(),
      ));
    }
  }
}
