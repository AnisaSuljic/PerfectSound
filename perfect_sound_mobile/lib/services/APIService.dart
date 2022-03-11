import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:perfect_sound_mobile/models/User/Users.dart';

class APIService{
  static String? username;
  static String? password;
  static Users? usersData;


  String? route;
  //static String? urlApi='http://192.168.0.11:45457/api/';
  static String? urlApi='http://10.0.2.2:5010/api/';

  APIService({this.route });

  static Future<void> SetPatameter(String Username,String Password,Users data) async {
    username=Username;
    password=Password;
    usersData=data;

  }
  //Login metod
  static Future<Users?> Login(bool check, String? pass) async{

    String baseURL=urlApi!+"User/Login";
    final String basicAuth;
    if(!check)
      basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    else
      basicAuth='Basic '+base64Encode(utf8.encode('$username:$pass'));

    final response=await http.get(
      Uri.parse(baseURL),
      headers:{HttpHeaders.authorizationHeader:basicAuth},
    );

    if(response.statusCode==200){
      var result=Users.fromJson(JsonDecoder().convert(response.body));
      return result;
    }
    else{
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
    if (response.statusCode == 200) {
      var result=JsonDecoder().convert(response.body);
      return JsonDecoder().convert(response.body);

    } else {
      var result=JsonDecoder().convert(response.body);
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
      return null;
    }
  }

//Get by ID method

  static Future<dynamic> GetById(String route, dynamic id) async{

    String baseURL=urlApi!+route+'/'+id.toString();

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
  static Future<dynamic> GetRandom() async{

    String baseURL=urlApi!+'QuoteOfTheDay';

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

    if(response.statusCode==200){
      var result=JsonDecoder().convert(response.body);
      return result;
    }
    else{
      var result=JsonDecoder().convert(response.body);
      return null;
    }
  }

  static Future<dynamic> Put(String route, int? id, String body) async {

    String baseURL=urlApi!+route+"/"+id.toString();
    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));

    final response = await http.put(
      Uri.parse(baseURL),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    if(response.statusCode==200){
      var result=JsonDecoder().convert(response.body);
      return result;
    }
    else{
      return null;
    }
  }

}