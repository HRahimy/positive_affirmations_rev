import 'package:equatable/equatable.dart';

class AffirmationListItem extends Equatable {
  const AffirmationListItem({
    required this.id,
    required this.title,
    this.subtitle = '',
  });

  final int id;
  final String title;
  final String subtitle;

  @override
  List<Object> get props => [id, title, subtitle];
}
