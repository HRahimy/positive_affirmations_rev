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

  static const String fieldId = 'id';
  static const String fieldTitle = 'title';
  static const String fieldSubtitle = 'subtitle';

  static AffirmationListItem fromJson(Map<String, dynamic> json) {
    return AffirmationListItem(
      id: json[AffirmationListItem.fieldId],
      title: json[AffirmationListItem.fieldTitle],
      subtitle: json[AffirmationListItem.fieldSubtitle] ?? '',
    );
  }

  @override
  List<Object> get props => [id, title, subtitle];
}
