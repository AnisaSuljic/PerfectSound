import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
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
  TextEditingController confirmPasswordController=new TextEditingController();
  TextEditingController emailController=new TextEditingController();
  TextEditingController phoneController=new TextEditingController();

  UserUpsertRequest newUser=new UserUpsertRequest();
  bool validate=false;
  dynamic userResponse;
  final _formKey=GlobalKey<FormState>();


  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size; //total height&width of screen
    return Scaffold(
      body:
      Padding(
        padding: const EdgeInsets.fromLTRB(0,20,0,20),
        child: SafeArea(
          child:
          Container(
            height: size.height,
            width: double.infinity,
            child: Form(
              key: _formKey,
              child: SingleChildScrollView(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Center(child: Text('SIGNUP',style: TextStyle(fontWeight: FontWeight.bold))),
                    Image(width: size.width * 0.2, image: AssetImage('assets/images/sign.png')),
                    Padding(
                      padding: const EdgeInsets.fromLTRB(20,0,20,0),
                      child: Column(
                        children: [
                          FormFieldBuild(label: "First name", obscure: false, txtController: firstnameController,msgRequiredField: msgRequiredField,msgFormat: null,regex: null,),
                          FormFieldBuild(label: "Last name", obscure: false,txtController: lastnameController,msgRequiredField: msgRequiredField,msgFormat: null,regex: null,),
                          FormFieldBuild(label: "Your username", obscure: false,txtController: usernameController,msgRequiredField: msgRequiredField,msgFormat: null,regex: null,),
                          FormFieldBuild(label: "Email", obscure: false,txtController: emailController,msgRequiredField: msgRequiredField,msgFormat: msgEmailFormatField,regex: emailRegex,),
                          FormFieldBuild(label: "Password", obscure: true,txtController: passwordController,msgRequiredField: msgRequiredField,msgFormat: null,regex: null,),
                          FormFieldBuild(label: "Confirm password", obscure: true,txtController: confirmPasswordController,msgRequiredField: msgRequiredField,msgFormat: null,regex: null,txtController2: passwordController,),
                          FormFieldBuild(label: "Phone", obscure: false,txtController: phoneController,msgRequiredField: msgRequiredField,msgFormat: msgPhoneFormatField,regex: phoneRegex,),
                        ],
                      ),
                    ),
                    SizedBox(height: size.height * 0.02),
                    Container(
                      width: size.width*0.7,
                      margin: EdgeInsets.symmetric(vertical: 5),
                      child: ClipRRect(
                        borderRadius: BorderRadius.circular(30),
                        child: ElevatedButton(
                            style: ButtonStyle(backgroundColor: MaterialStateProperty.all(PrimaryColor), padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 15, horizontal: 40))),
                            onPressed: () async {
                              if(_formKey.currentState!.validate()){
                                userResponse=null;

                                newUser.firstName=firstnameController.text;
                                newUser.lastName=lastnameController.text;
                                newUser.userName=usernameController.text;
                                newUser.email=emailController.text;
                                newUser.password=passwordController.text;
                                newUser.passwordConfirm=confirmPasswordController.text;
                                newUser.phone=phoneController.text;
                                newUser.userTypeId=2;

                                await PostUser(newUser);

                                if(userResponse==null && userResponse=='')
                                  showDialogWidget("An error has occurred, please try again.");
                                else if (userResponse!=null && userResponse!='') {
                                  Navigator.pushAndRemoveUntil(context, MaterialPageRoute(builder: (context) { return Login(); }), (route) => false);
                                  ScaffoldMessenger.of(context).showSnackBar(
                                    const SnackBar(content: Text('You have successfully registered'),backgroundColor: Colors.lightGreen,),
                              );
                                }else
                                  showDialogWidget(userResponse.toString());
                              }
                          }, child: const Text('SIGNUP'),
                        ),
                      ),
                    ),
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
          ),
        ),
      )
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
