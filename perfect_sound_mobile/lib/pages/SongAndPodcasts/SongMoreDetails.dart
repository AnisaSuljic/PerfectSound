import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';

class SongMoreDetails extends StatelessWidget {

  final SAP songAndPodcast;
  const SongMoreDetails({Key? key, required this.songAndPodcast}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: PrimaryColor,
        centerTitle: true,
        title: Text("Lyrics"),
      ),
      body: Padding(
        padding: EdgeInsets.all(10),
        child: Column(
          children: [
            Text(songAndPodcast.title.toString(), style: TextStyle(fontSize: 24),),
            SizedBox(height: 10,),
            Text(songAndPodcast.text.toString(), style: TextStyle(fontSize: 16),),
          ],
        )
      ),
    );
  }
}
