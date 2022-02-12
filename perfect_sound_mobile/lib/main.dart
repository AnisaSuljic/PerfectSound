import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/Helper/constants.dart';
import 'package:perfect_sound_mobile/pages/Home.dart';
import 'package:perfect_sound_mobile/pages/Loading.dart';
import 'package:perfect_sound_mobile/pages/Welcome/Welcome.dart';

void main() {
  runApp(PerfectSoundApp());
}

class PerfectSoundApp extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'PerfectSong',
      theme: ThemeData(
        primaryColor: PrimaryColor,
        scaffoldBackgroundColor: Colors.white,
      ),
      home: Welcome(),
      routes: {
        //'/login':(context)=>Login(),
        //'/loading' :(context)=>Loading(),
        //'/home':(context)=>Home(),
        //'/allnews':(context)=>AllNews(),
        // ostatak pageva
        // ...
      },
    );
  }
}


