import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;
import 'package:perfect_sound_mobile/models/User/Users.dart';

class APIService{
  static String? username;
  static String? password;
  static int? userID;
  static Users? usersData;


  String? route;
  //static String? urlApi='http://10.0.2.2:8000/api';
  static String? urlApi='http://10.0.2.2:5010/api/';

  APIService({this.route });

  Future<void> SetPatameter(String Username,String Password) async {
    username=Username;
    password=Password;

  }
  //Login metod
  static Future<Users?> Login() async{

    String baseURL=urlApi!+"User/Login";

    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response=await http.get(
      Uri.parse(baseURL),
      headers:{HttpHeaders.authorizationHeader:basicAuth},
    );
    if(response.statusCode==200){
      print("200 "+ response.body.toString());
      var result=Users.fromJson(JsonDecoder().convert(response.body));
      print("result "+ result.toString());

      return result;
    }
    else{
      print("gr "+ response.body.toString());

      return null;
    }
  }

  static Future<dynamic> SignUp(String body) async{

    String baseURL=urlApi!+"User/SignUp";

    final response=await http.post(
        Uri.parse(baseURL),
        headers:{
          HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        },
        body: body
    );
    if(response.statusCode==201){
      print("greskaa");
      var result=JsonDecoder().convert(response.body);
      return result;
    }
    else{
      print("greskaa11 "+ response.statusCode.toString());
      var result=JsonDecoder().convert(response.body);
      print("gr "+ result.toString());
      return null;
    }
  }

//Get method

  static Future<List<dynamic>?> Get(String route, dynamic object) async{

    String querryString=Uri(queryParameters: object).query;

    String baseURL=urlApi!+route;
    if(object!=null){
      baseURL=baseURL+'?'+querryString;
    }

    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response=await http.get(
      Uri.parse(baseURL),
      headers:{HttpHeaders.authorizationHeader:basicAuth},
    );

    if(response.statusCode==200){
      var result=JsonDecoder().convert(response.body) as List;

      return result;
    }
    else{
      print("greskica "+response.body.toString());
      return null;
    }
  }

//Get by ID method

  static Future<dynamic> GetById(String route, dynamic id) async{

    String baseURL=urlApi!+route+'/'+id;

    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response=await http.get(
      Uri.parse(baseURL),
      headers:{HttpHeaders.authorizationHeader:basicAuth},
    );
    if(response.statusCode==200){
      var result=JsonDecoder().convert(response.body);
      return result;
    }
    else{
      return null;
    }
  }

  //GetRandom
  static Future<dynamic> GetRandom(String route) async{

    String baseURL=urlApi!+route;

    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response=await http.get(
      Uri.parse(baseURL),
      headers:{HttpHeaders.authorizationHeader:basicAuth},
    );
    if(response.statusCode==200){
      var result=JsonDecoder().convert(response.body);

      return result;
    }
    else{
      return null;
    }
  }

  //Post method

  static Future<dynamic> Post(String route, String body) async{

    String baseURL=urlApi!+route;
    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));

    final response=await http.post(
      Uri.parse(baseURL),
      headers:{
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body
    );
    if(response.statusCode==201){
      print("greskaa");
      var result=JsonDecoder().convert(response.body);
      return result;
    }
    else{
      print("greskaa11 "+ response.statusCode.toString());
      var result=JsonDecoder().convert(response.body);
      print("gr "+ result.toString());
      return null;
    }
  }

  static Future<dynamic> Put(String route, int id, String body) async {

    String baseURL=urlApi!+route;
    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));

    final response = await http.put(
      Uri.parse(baseURL),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    if(response.statusCode==201){
      print("greskaa");
      var result=JsonDecoder().convert(response.body);
      return result;
    }
    else{
      print("greskaa11 "+ response.statusCode.toString());
      var result=JsonDecoder().convert(response.body);
      print("gr "+ result.toString());
      return null;
    }
  }

}