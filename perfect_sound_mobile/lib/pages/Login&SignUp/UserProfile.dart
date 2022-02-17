import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/User/UserUpsertRequest.dart';
import 'package:perfect_sound_mobile/models/User/Users.dart';
import 'package:perfect_sound_mobile/pages/Home.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class UserProfile extends StatefulWidget {
  const UserProfile({Key? key}) : super(key: key);

  @override
  _UserProfileState createState() => _UserProfileState();
}

class _UserProfileState extends State<UserProfile> {
  TextEditingController firstnameController = new TextEditingController(text: APIService.usersData!.firstName);
  TextEditingController lastnameController = new TextEditingController(text: APIService.usersData!.lastName);
  TextEditingController emailController = new TextEditingController(text: APIService.usersData!.email);
  TextEditingController phoneController = new TextEditingController(text: APIService.usersData!.phone);
  TextEditingController oldPasswordController = new TextEditingController();
  TextEditingController newPasswordController = new TextEditingController();

  Users? usersData;
  Users? checkUser;
  UserUpsertRequest updateData=new UserUpsertRequest();

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size; //total height&width of screen
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: PrimaryColor,
        centerTitle: true,
        title: Text("Profile"),
      ),
      body: buildBody(size)
    );
  }

  SingleChildScrollView buildBody(Size size) {
    return SingleChildScrollView(
      child: Container(
        height: size.height,
        width: double.infinity,
        child:Form(
          key: _formKey,
          child: Column(
            children: [
              SizedBox(height: size.height * 0.02),
              Container(
                  height: size.height * 0.08,
                  width: size.width * 0.95,
                  decoration: BoxDecoration(
                    color: PrimaryColor,
                    borderRadius: BorderRadius.only(
                      bottomRight: Radius.circular(100.0),
                      topRight: Radius.circular(100.0),
                      bottomLeft: Radius.circular(100.0),
                      topLeft: Radius.circular(100.0),
                    ),
                  ),
                  child: Align(
                      alignment: Alignment.centerLeft,
                      child: Row(
                        children: [
                          Padding(
                            padding: const EdgeInsets.fromLTRB(30, 0, 20, 0),
                            child: Icon(Icons.person_outline_outlined,color: Colors.white,),
                          ),
                          Text("Username :   " + APIService.username.toString(),style: TextStyle(fontSize: 18, color: Colors.white))
                        ],
                      )
                  )
              ),
              SizedBox(height: size.height * 0.03),
              Text("Profile information",style: TextStyle(fontSize: 18)),
              SizedBox(height: size.height * 0.02),
              Padding(
                padding: const EdgeInsets.fromLTRB(20,0,20,0),
                child: Column(
                  children: [
                    FormFieldBuild(txtController: firstnameController,label:"First name",obscure: false, msgRequiredField: msgRequiredField, msgFormat:null, regex:null),
                    FormFieldBuild(txtController: lastnameController,label:"Last name",obscure: false, msgRequiredField: msgRequiredField, msgFormat:null, regex:null),
                    FormFieldBuild(txtController: emailController,label:"Email",obscure: false, msgRequiredField: msgRequiredField, msgFormat:msgEmailFormatField, regex:emailRegex),
                    FormFieldBuild(txtController: phoneController,label:"Phone number",obscure: false, msgRequiredField: msgRequiredField, msgFormat:msgPhoneFormatField, regex:phoneRegex),
                    FormFieldBuild(txtController: oldPasswordController,label:"Enter the current password to save changes",obscure: true, msgRequiredField: msgRequiredFieldPass, msgFormat:null, regex:null),
                    TextFormField(controller: newPasswordController,obscureText: true,decoration: InputDecoration(labelText: "New password"),),
                  ],
                ),
              ),
              SizedBox(height: size.height * 0.03),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  ClipRRect(
                    borderRadius: BorderRadius.circular(30),
                    child: ElevatedButton(
                      style: ButtonStyle(backgroundColor: MaterialStateProperty.all(PrimaryColor), padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 15, horizontal: 40))),
                      onPressed: () {
                        Navigator.of(context).pushAndRemoveUntil(MaterialPageRoute(
                            builder: (BuildContext context) => const Home()),(route)=>false);
                      },
                      child: const Text('Cancel'),
                    ),
                  ),
                  ClipRRect(
                    borderRadius: BorderRadius.circular(30),
                    child: ElevatedButton(
                      style: ButtonStyle(
                          backgroundColor: MaterialStateProperty.all(PrimaryColor),
                          padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 15, horizontal: 40))
                      ),
                      onPressed: () async {
                          if (_formKey.currentState!.validate()) {
                            await GetUser(true,oldPasswordController.text);
                            if(checkUser!=null){

                              updateData.firstName=firstnameController.text;
                              updateData.lastName=lastnameController.text;
                              updateData.userName=APIService.username;
                              updateData.email=emailController.text;
                              updateData.phone=phoneController.text;
                              updateData.password=newPasswordController.text!=''?newPasswordController.text:APIService.password;
                              updateData.passwordConfirm=newPasswordController.text!=''?newPasswordController.text:APIService.password;
                              updateData.userTypeId=2;

                              await PutUser(updateData);

                              if(usersData!=null)
                                await APIService.SetPatameter(updateData.userName.toString(), updateData.password.toString(), usersData!);
                              Navigator.of(context).pushAndRemoveUntil(MaterialPageRoute(
                                  builder: (BuildContext context) => const Home()),(route)=>false);
                              ScaffoldMessenger.of(context).showSnackBar(
                                const SnackBar(content: Text('Successfully updated'),backgroundColor: Colors.lightGreen,),
                              );
                            }
                          }
                      },
                      child: const Text('Save'),
                    ),
                  ),
                ],
              )
            ],
          ),
        ),
      )
    );
  }

  //GET USER METHOD
  Future<void> GetUser(bool update, String? pass)async{
    checkUser = await APIService.Login(update,pass);
  }

  //PUT USER METHOD
  Future<void> PutUser(UserUpsertRequest request) async {
    var x=await APIService.Put("User",APIService.userID, json.encode(updateData.toJson()));
    usersData=Users.fromJson(x);
  }
}






