import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;

class APIService{
  static String? username;
  static String? password;
  static int? userID;


  String? route;
  //static String? urlApi='http://10.0.2.2:8000/api';
  static String? urlApi='http://10.0.2.2:5010/api/';

  APIService({this.route });

  Future<void> SetPatameter(String Username,String Password) async {
    username=Username;
    password=Password;

  }

//Get method

  static Future<List<dynamic>?> Get(String route, dynamic object) async{

    String querryString=Uri(queryParameters: object).query;
    print("uri: "+querryString);

    String baseURL=urlApi!+route;
    print("baseURL: "+baseURL);

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
      //print("200 "+result.toString());

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