import 'dart:ui';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcastDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class AllSongsAndPodcasts extends StatefulWidget {
  const AllSongsAndPodcasts({Key? key}) : super(key: key);

  @override
  _AllSongsAndPodcastsState createState() => _AllSongsAndPodcastsState();
}

class _AllSongsAndPodcastsState extends State<AllSongsAndPodcasts> {
  TextEditingController titleFilterController=new TextEditingController();

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
      title: Text('Songs'),
      ),
      body: bodyWidget(),
    );
  }



  Future<List<SongAndPodcast>> GetAllSongs() async {
    var SaPList = await APIService.Get('SongAndPodcast',null);
    return SaPList!.map((i) => SongAndPodcast.fromJson(i)).toList();
  }


  Widget bodyWidget() {
    return FutureBuilder<List<SongAndPodcast>>(
      future: GetAllSongs(),
      builder: (BuildContext context, AsyncSnapshot<List<SongAndPodcast>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          return ListView(
            children: snapshot.data!.map((e) => SongAndPodcastWidget(e)).toList(),
          );
        }
      },
    );
  }

  Widget SongAndPodcastWidget(SaP) {
    var running;
    if(SaP.runningTime==null)
      running="Podcast";
    else
      running=SaP.runningTime.toString();

    return Card(

          child: Container(
            height: 100,
            decoration: BoxDecoration(
                image: DecorationImage(
                  image: MemoryImage(SaP.poster) ,
                  fit: BoxFit.cover,
                  alignment: Alignment.topCenter,
                )
            ),
            child:TextButton(
                    onPressed: () {
                      Navigator.push(
                        context, MaterialPageRoute(builder: (context) => SongAndPodcastDetails(songAndPodcast:SaP)),
                      );
                    },
                    child: Column(
                      children: [
                        Text(SaP.title,style: TextStyle(color: Colors.black,fontSize: 24,backgroundColor: Colors.white.withOpacity(0.5))),
                        Text(running,style: TextStyle(color: Colors.black,backgroundColor: Colors.white.withOpacity(0.5))),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                       children: [
                         for(var i=0;i<SaP.genre.length;i++) Text('| '+SaP.genre[i].genreName+" |",style: TextStyle(color: Colors.black,backgroundColor: Colors.white.withOpacity(0.5))),
                         Text('4.7',style: TextStyle(color: Colors.black,fontSize: 16,backgroundColor: Colors.white.withOpacity(0.5)))
                       ],
                     ),

                      ],
                    )
                )
          ),

    );
  }
}
