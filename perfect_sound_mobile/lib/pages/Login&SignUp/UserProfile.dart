import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/User/Users.dart';
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
  TextEditingController passwordController = new TextEditingController();
  TextEditingController confirmPasswordcontroller = new TextEditingController();

  bool disable=true;
  Users? usersData;

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
        child:Column(
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
            ProfileTextField(txtController: firstnameController,label: "First name",obscureText: false,),
            ProfileTextField(txtController: lastnameController,label: "Last name",obscureText: false,),
            ProfileTextField(txtController: emailController,label: "Email",obscureText: false,),
            ProfileTextField(txtController: phoneController,label: "Phone",obscureText: false,),
            ProfileTextField(txtController: passwordController,label: "Password",obscureText: true,),
            ProfileTextField(txtController: confirmPasswordcontroller,label: "Password confirmation",obscureText: true,),
            SizedBox(height: size.height * 0.03),
            RoundedButton(text: "Save",textColor: Colors.white,color: PrimaryColor,disabled: disable,press: (){
              setState(() {
                disable=true;
              });
            },
            )
          ],
        ),
      )
    );
  }

}



