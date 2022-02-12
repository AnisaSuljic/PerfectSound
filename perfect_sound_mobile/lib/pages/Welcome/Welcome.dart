import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/pages/Login&SignUp/Login.dart';
import 'package:perfect_sound_mobile/Helper/components.dart';
import 'package:perfect_sound_mobile/pages/Login&SignUp/SignUp.dart';
import '../../Helper/constants.dart';

class Welcome extends StatelessWidget {
  const Welcome({Key? key}) : super(key: key);

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
              Center(child: Text('WELCOME TO PERFECTSOUND',style: TextStyle(fontWeight: FontWeight.bold))),
              SizedBox(height: size.height * 0.02),
              Image(width: size.width * 0.8,image: AssetImage('assets/images/background.png')),
              RoundedButton(
                  color: PrimaryColor,
                  text: "LOGIN",
                  press: () {
                    Navigator.push(context,
                        MaterialPageRoute(builder: (context) => Login()));
                  }),
              RoundedButton(
                color: PrimaryColorLight,
                  text: "SIGNUP",
                  press: () {
                    Navigator.push(context,
                        MaterialPageRoute(builder: (context) => SignUp()));
                  })
            ],
          ),
        ),
      ),
    );
  }
}
