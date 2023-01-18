import 'package:equatable/equatable.dart';

class PaginatedList<T> extends Equatable {
  const PaginatedList({
    this.items = const [],
    this.pageNumber = 0,
    this.totalPages = 0,
    this.totalCount = 0,
    this.hasPreviousPage = false,
    this.hasNextPage = false,
  });

  final List<T> items;
  final int pageNumber;
  final int totalPages;
  final int totalCount;
  final bool hasPreviousPage;
  final bool hasNextPage;

  @override
  List<Object> get props => [
        items,
        pageNumber,
        totalPages,
        totalCount,
        hasPreviousPage,
        hasNextPage,
      ];
}
