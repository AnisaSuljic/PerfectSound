import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/User/Users.dart';
import 'package:perfect_sound_mobile/pages/Login&SignUp/SignUp.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import '../Home.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  TextEditingController usernameController=new TextEditingController();
  TextEditingController passwordController=new TextEditingController();
  Users? loggedUser;
  var result;

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size; //total height&width of screen
    return Scaffold(
      body: SingleChildScrollView(
        child: Container(
          height: size.height,
          width: double.infinity,
          child:Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Center(child: Text('LOGIN',style: TextStyle(fontWeight: FontWeight.bold))),
              Image(width: size.width * 0.7, image: AssetImage('assets/images/login.png')),
              TextFieldContainer(hintText: "Your username", icon: Icons.person_outline_outlined,onChanged: (value){},obscureText: false, txtController: usernameController,),
              TextFieldContainer(hintText: "Password", icon: Icons.lock_outline_rounded,onChanged: (value){},suffixIcon: Icons.visibility_outlined,obscureText: true,txtController: passwordController,),
              SizedBox(height: size.height * 0.02),
              RoundedButton(text: "LOGIN", press: () async { await loginPress(context);}),
              SizedBox(height: size.height * 0.01,),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text("Don't have an account ? ", style: TextStyle(color: Colors.black87),),
                  GestureDetector(
                      onTap:() {Navigator.push(context,MaterialPageRoute(builder:(context){return SignUp();}));},
                      child: Text("Sign Up", style: TextStyle(color: PrimaryColor, fontWeight: FontWeight.bold),))
                ],
              )
            ],
          ),
        ),
      ),
    );
  }

  //GET USER METHOD
  Future<void> GetUser()async{
    loggedUser = await APIService.Login();
  }

  //SHOW DIALOG Widget
  Future<void> showDialogWidget(String text) async {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) =>
          AlertDialog(
          contentPadding: EdgeInsets.fromLTRB(0, 40, 0, 0),
          content:Text(text,textAlign: TextAlign.center),
          actions: <Widget> [
            TextButton(
          style: ButtonStyle(
              backgroundColor: MaterialStateProperty.all(PrimaryColor),
          ),
                onPressed: () {
                  Navigator.pop(context, false);
                  usernameController.text='';
                  passwordController.text='';
                },
                child: Text("OK", style: TextStyle(color: Colors.white),)
            )
          ],
      )
    );
  }

  //LOGIN PRESS METHOD
  Future<void> loginPress(BuildContext context) async {

    loggedUser=null;
    APIService.username=usernameController.text;
    APIService.password=passwordController.text;

    await GetUser();

    if(loggedUser!=null){
      if(loggedUser!.userTypeId==2){
        await GetUserID(usernameController.text);
        APIService.usersData=loggedUser;
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => Home()));
      }
      else{
        showDialogWidget("Access is not allowed.");
      }
    }
    else {
      showDialogWidget("Please enter the correct data.");
    }
  }
}
  //LOGIN TEXT FIELDS
  Future<void> GetUserID(String username)async{
  Map<String, String>?queryParams;
  if(username!=''){
    queryParams = {'User': username};
  }
  var result1 = await APIService.Get('User',queryParams);
  APIService.userID= result1!.map((i) => Users.fromJson(i)).toList().first.userId;
}

