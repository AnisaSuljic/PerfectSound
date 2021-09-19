import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/pages/AllNews.dart';
import 'package:perfect_sound_mobile/pages/ArtistDetails.dart';
import 'package:perfect_sound_mobile/pages/Home.dart';
import 'package:perfect_sound_mobile/pages/Loading.dart';
import 'package:perfect_sound_mobile/pages/Login.dart';

void main() {
  runApp(PerfectSoundApp());
}

class PerfectSoundApp extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Login(),
      routes: {
        '/loading' :(context)=>Loading(),
        '/home':(context)=>Home(),
        //'/allnews':(context)=>AllNews(),
        // ostatak pageva
        // ...
      },
    );
  }
}


