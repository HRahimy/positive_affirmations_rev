import 'package:dio/dio.dart';

class AffirmerApi {
  final String baseUrl;
  final Dio _dio;

  AffirmerApi._({required this.baseUrl})
      : _dio = Dio(BaseOptions(baseUrl: baseUrl));

  AffirmerApi.create({required String baseUrl}) : this._(baseUrl: baseUrl);

  void getAffirmations() async {
    try {
      var response = await _dio.request(
        '/affirmations',
        options: Options(method: 'GET')
      );
      print(response);
    } catch (e) {
      print(e);
    }
  }
}
