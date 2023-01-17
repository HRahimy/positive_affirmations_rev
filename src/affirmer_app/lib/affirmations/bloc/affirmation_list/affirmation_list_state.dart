part of 'affirmation_list_cubit.dart';

class AffirmationListState extends Equatable {
  const AffirmationListState({
    this.affirmations = const [],
    this.page = 1,
    this.pageSize = 10,
    this.loadingStatus = FormzStatus.pure,
    this.loadingError = '',
  });

  final List<AffirmationListItem> affirmations;
  final int page;
  final int pageSize;
  final FormzStatus loadingStatus;
  final String loadingError;

  AffirmationListState copyWith({
    List<AffirmationListItem>? affirmations,
    int? page,
    FormzStatus? loadingStatus,
    String? loadingError,
  }) {
    return AffirmationListState(
      affirmations: affirmations ?? this.affirmations,
      page: page ?? this.page,
      pageSize: pageSize,
      loadingStatus: loadingStatus ?? this.loadingStatus,
      loadingError: loadingError ?? this.loadingError,
    );
  }

  @override
  List<Object> get props => [
        affirmations,
        page,
        pageSize,
        loadingStatus,
        loadingError,
      ];
}
