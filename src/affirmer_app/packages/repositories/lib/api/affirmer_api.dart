import 'package:dio/dio.dart';
import 'package:repositories/api/models/affirmation_list_item_dto.dart';
import 'package:repositories/api/models/paginated_list.dart';

class AffirmerApi {
  final String baseUrl;
  final Dio _dio;

  AffirmerApi._({required this.baseUrl})
      : _dio = Dio(BaseOptions(baseUrl: baseUrl));

  AffirmerApi.create({required String baseUrl}) : this._(baseUrl: baseUrl);

  Future<PaginatedList<AffirmationListItem>> getAffirmations() async {
    var response =
        await _dio.request('/affirmations', options: Options(method: 'GET'));
    print(response);

    final parsedAffirmations = response.data['items'].map((item) {
      return AffirmationListItem.fromJson(item);
    }).toList();

    // Solution converting parsed list into a strongly typed list in dart:
    // https://stackoverflow.com/a/62250584/5472560
    return PaginatedList<AffirmationListItem>(
      items: List<AffirmationListItem>.from(parsedAffirmations),
      pageNumber: response.data['pageNumber'],
      totalPages: response.data['totalPages'],
      hasNextPage: response.data['hasNextPage'],
      hasPreviousPage: response.data['hasPreviousPage'],
      totalCount: response.data['totalCount'],
    );
  }
}
