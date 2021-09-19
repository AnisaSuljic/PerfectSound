import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/News.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  TextEditingController usernameController=new TextEditingController();
  TextEditingController passwordController=new TextEditingController();
  var result;


  void GetData()async{
    result =await APIService.Get('User',null);
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(60),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children:
            [
              Image(
                  width:80,
                  height: 80,
                  image: AssetImage('assets/logo.png')
              ),

              TextField(
                controller: usernameController,
                decoration: InputDecoration(
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(25)
                  ),
                    hintText:'Username'
                ),
              ),
              SizedBox(
                height: 10,
              ),
              TextField(
                controller: passwordController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(25)
                    ),
                    hintText:'Password'

                ),
              ),
              SizedBox(
                height: 10,
              ),
              Container(
                width: 300,
                height: 40,
                decoration:
                BoxDecoration(
                  color: Colors.deepPurpleAccent,
                  borderRadius: BorderRadius.circular(25)
                ),
                child: TextButton(onPressed: (){
                  print(usernameController.text);
                  print(passwordController.text);
                  APIService.username=usernameController.text;
                  APIService.password=passwordController.text;
                  if(result!=''){
                    Navigator.of(context).pushReplacementNamed('/home');
                  }
               },
                  child: Text('Login', style: TextStyle(color: Colors.white,fontSize: 20))),
              ),
            ],
          ),
        )
      ),
    );
  }


}

