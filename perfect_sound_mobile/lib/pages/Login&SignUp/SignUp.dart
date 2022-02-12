import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/Helper/components.dart';
import 'package:perfect_sound_mobile/Helper/constants.dart';
import 'package:perfect_sound_mobile/models/User/UserUpsertRequest.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'Login.dart';

class SignUp extends StatefulWidget {
  const SignUp({Key? key}) : super(key: key);

  @override
  _SignUpState createState() => _SignUpState();
}

class _SignUpState extends State<SignUp> {
  TextEditingController firstnameController=new TextEditingController();
  TextEditingController lastnameController=new TextEditingController();
  TextEditingController usernameController=new TextEditingController();
  TextEditingController passwordController=new TextEditingController();
  TextEditingController confirmpasswordController=new TextEditingController();
  TextEditingController emailController=new TextEditingController();
  TextEditingController phoneController=new TextEditingController();

  UserUpsertRequest newUser=new UserUpsertRequest();
  bool validate=false;
  dynamic userResponse;

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size; //total height&width of screen
    return Scaffold(
      body: SingleChildScrollView(
        child: Container(
          height: size.height,
          width: double.infinity,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Center(child: Text('SIGNUP',style: TextStyle(fontWeight: FontWeight.bold))),
              Image(width: size.width * 0.2, image: AssetImage('assets/images/sign.png')),
              TextFieldContainer(hintText: "First name", icon: Icons.drive_file_rename_outline,onChanged: (value){},obscureText: false, txtController: firstnameController,),
              TextFieldContainer(hintText: "Last name", icon: Icons.drive_file_rename_outline,onChanged: (value){},obscureText: false,txtController: lastnameController,),
              TextFieldContainer(hintText: "Your username", icon: Icons.person_outline,onChanged: (value){},obscureText: false,txtController: usernameController,),
              TextFieldContainer(hintText: "Email", icon: Icons.email_outlined,onChanged: (value){},obscureText: false,txtController: emailController,),
              TextFieldContainer(hintText: "Password", icon: Icons.lock_outline_rounded,onChanged: (value){},suffixIcon: Icons.visibility,obscureText: true,txtController: passwordController,),
              TextFieldContainer(hintText: "Confirm password", icon: Icons.lock_outline_rounded,onChanged: (value){},suffixIcon: Icons.visibility,obscureText: true,txtController: confirmpasswordController,),
              TextFieldContainer(hintText: "Phone", icon: Icons.phone_iphone,onChanged: (value){},obscureText: false,txtController: phoneController,),
              SizedBox(height: size.height * 0.02),
              RoundedButton(text: "SIGNUP", press: (){
                newUser.firstName=firstnameController.text;
                newUser.lastName=lastnameController.text;
                newUser.userName=usernameController.text;
                newUser.email=emailController.text;
                newUser.password=passwordController.text;
                newUser.passwordConfirm=confirmpasswordController.text;
                newUser.phone=phoneController.text;
                newUser.userTypeId=2;

                PostUser(newUser);

                if(userResponse==null)
                  showDialogWidget("An error has occurred, please try again.");
                else if (userResponse!=null)
                  Navigator.push(context,MaterialPageRoute(builder:(context){return Login();}));
                else
                  showDialogWidget(userResponse.toString());
              }),
              SizedBox(height: size.height * 0.01,),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text("Already have an account ? ", style: TextStyle(color: Colors.black87),),
                  GestureDetector(
                      onTap:() {Navigator.push(context,MaterialPageRoute(builder:(context){return Login();}));},
                      child: Text("Log In", style: TextStyle(color: PrimaryColor, fontWeight: FontWeight.bold),))
                ],
              )
            ],
          ),
        ),
      ),
    );
  }

  //POST USER/REGISTRATION METHOD
  Future<void> PostUser(UserUpsertRequest request) async {
    userResponse = await APIService.SignUp(json.encode(request.toJson()));
  }

  //SHOW DIALOG Widget
  Future<void> showDialogWidget(String text) async {
    return showDialog<void>(
        context: context,
        builder: (BuildContext context) =>
            AlertDialog(
              contentPadding: EdgeInsets.fromLTRB(20, 40, 20, 0),
              content:Text(text,textAlign: TextAlign.center),
              actions: <Widget> [
                TextButton(
                    style: ButtonStyle(
                      backgroundColor: MaterialStateProperty.all(PrimaryColor),
                    ),
                    onPressed: () {
                      Navigator.pop(context, false);
                    },
                    child: Text("OK", style: TextStyle(color: Colors.white),)
                )
              ],
            )
    );
  }
}
