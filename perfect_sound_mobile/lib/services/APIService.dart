import 'dart:convert';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class APIService{
  static String? username;
  static String? password;
  String? route;
  // static String? url='https://ebf1-109-175-38-152.ngrok.io';
  static String? urlApi='https://c2e8-77-77-222-152.ngrok.io/api/';

  APIService({this.route});

  void SetPatameter(String Username,String Password){
    username=Username;
    password=Password;
  }

//Get method

  static Future<List<dynamic>?> Get(String route, dynamic object) async{

    String querryString=Uri(queryParameters: object).query;
    String baseURL=urlApi!+route;

    print("querry singer"+querryString);

    if(object!=null){
      baseURL=baseURL+'?'+querryString;
    }

    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response=await http.get(
      Uri.parse(baseURL),
      headers:{HttpHeaders.authorizationHeader:basicAuth},
    );

    if(response.statusCode==200){
      print("uspelo");
      var result=JsonDecoder().convert(response.body) as List;
      //print("result=> "+result.toString());

      return result;
    }
    else{
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

    final response=await http.post(
      Uri.parse(baseURL),
      headers:<String,String>{
        'Content-Type':'application/json; charset=UTF-8',
      },
      body: body
    );
    if(response.statusCode==201){
      var result=JsonDecoder().convert(response.body);
      return result;
    }
    else{
      return null;
    }
  }

}