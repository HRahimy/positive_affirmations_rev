import 'package:dio/dio.dart';
import 'package:repositories/api/models/affirmation_list_item_dto.dart';

class AffirmerApi {
  final String baseUrl;
  final Dio _dio;

  AffirmerApi._({required this.baseUrl})
      : _dio = Dio(BaseOptions(baseUrl: baseUrl));

  AffirmerApi.create({required String baseUrl}) : this._(baseUrl: baseUrl);

  Future<List<AffirmationListItem>> getAffirmations() async {
    try {
      var response = await _dio.request(
        '/affirmations',
        options: Options(method: 'GET')
      );
      return [];
    } catch (e) {
      return [];
    }
  }
}
