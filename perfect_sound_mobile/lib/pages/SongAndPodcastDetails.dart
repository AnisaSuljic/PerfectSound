import 'dart:typed_data';
import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class SongAndPodcastDetails extends StatelessWidget {
  final SongAndPodcast songAndPodcast;
  const SongAndPodcastDetails({Key? key,required this.songAndPodcast}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.deepPurpleAccent,
        actions: [
          Icon(Icons.account_box_rounded),
          Padding(
            padding: EdgeInsets.fromLTRB(5.0, 18.0, 18.0, 18.0),
            child: Text(APIService.username as String,style: TextStyle(fontSize: 16),),
          ),
        ],
        title: Text('Details'),
      ),
      body: bodyWidget(),
    );
  }
  Widget bodyWidget() {
    return Container(
      height: 150,
      decoration: BoxDecoration(color: Colors.amberAccent),
      child: Row(
        children: [
          Expanded(
            flex: 40,
            child:  Container(
              alignment: Alignment.center,
              child: Image(
                    width:150,
                    height: 150,
                    image: MemoryImage(songAndPodcast.poster as Uint8List)
                ),
            ),
          ),
          Expanded(
            flex: 60,
            child:
              Container(
                alignment: Alignment.center,
                  child: Text(songAndPodcast.title.toString(),style: TextStyle(fontSize: 24),)
              )
          )
        ],
      ),
    );
  }
}
