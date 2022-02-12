import 'dart:typed_data';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcastPerson.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcastDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';


class AllSongsAndPodcasts extends StatelessWidget {
  final bool isPodcast;

  const AllSongsAndPodcasts({Key? key, required this.isPodcast})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: buildAppBar(context),
        drawer: buildDrawer(context),
      body: bodyWidget(context),
    );
  }


  Future<List<SongAndPodcast>> GetAllSongs() async {
    var ispodcast=this.isPodcast.toString();
    Map<String, String>?querryParams;
    querryParams = {'IsPodcast': ispodcast};
    var SaPList = await APIService.Get('SongAndPodcast', querryParams);
    return SaPList!.map((i) => SongAndPodcast.fromJson(i)).toList();
  }


  Widget bodyWidget(BuildContext context) {
    return FutureBuilder<List<SongAndPodcast>>(
      future: GetAllSongs(),
      builder: (BuildContext context,
          AsyncSnapshot<List<SongAndPodcast>> snapshot) {
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
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!
                .map((e) => SongAndPodcastWidget(e,context))
                .toList(),
          );
        }
      },
    );
  }

  Future<List<SongAndPodcastPerson>> GetSinger(songAndPodcastId, int RoleId) async {
    Map<String, String>?querryParams;
    if(songAndPodcastId!=null){
      querryParams = {'SongAndPodcastId': songAndPodcastId.toString()};
    }
    var Singers = await APIService.Get('SongAndPodcastPerson', querryParams);
    return Singers!.map((i) => SongAndPodcastPerson.fromJson(i)).toList().where((element) => element.roleId==RoleId).toList();
  }

  Widget SingerSnapshotWidget(BuildContext context,int SaPID) {
    return FutureBuilder<List<SongAndPodcastPerson>>(
      future: GetSinger(SaPID,1),
      builder: (BuildContext context,
          AsyncSnapshot<List<SongAndPodcastPerson>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text(''),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          return ListView(
            children: snapshot.data!
                .map((e) => SingerWidget(e,context))
                .toList(),
          );
        }
      },
    );
  }

  Widget SingerWidget(SongAndPodcastPerson e, BuildContext context){
    return Text(e.person!.firstName.toString()+' '+e.person!.lastName.toString(),
      textAlign: TextAlign.center,style: TextStyle(color: Colors.black,
          backgroundColor: Colors.white.withOpacity(0.5)),);
  }

  Widget SongAndPodcastWidget(SongAndPodcast SaP,BuildContext context) {

    var running;
    if (SaP.runningTime == null)
      running = "Podcast";
    else
      running = SaP.runningTime.toString();

    
    return Card(

      child: Container(
          height: 150,
          decoration: BoxDecoration(
              image: DecorationImage(
                image: MemoryImage(SaP.poster as Uint8List),
                fit: BoxFit.cover,
                alignment: Alignment.topCenter,
              )
          ),
          child: TextButton(
              onPressed: () {
                Navigator.push(
                  context, MaterialPageRoute(builder: (context) =>
                    SongAndPodcastDetails(songAndPodcast: SaP)),
                );
              },
              child: Column(
                children: [
                  Text(SaP.title.toString(), style: TextStyle(color: Colors.black,
                      fontSize: 24,
                      backgroundColor: Colors.white.withOpacity(0.5))),
                  Flexible(child: SingerSnapshotWidget(context,SaP.songAndPodcastId)),

                  Text(running, style: TextStyle(color: Colors.black,
                      backgroundColor: Colors.white.withOpacity(0.5))),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      for(var i = 0; i < SaP.genre!.length; i++) Text(
                          '| ' + SaP.genre![i].genreName.toString() + " |",
                          style: TextStyle(color: Colors.black,
                              backgroundColor: Colors.white.withOpacity(0.5))),
                      Text('4.7', style: TextStyle(color: Colors.black,
                          fontSize: 16,
                          backgroundColor: Colors.white.withOpacity(0.5)))
                    ],
                  ),
                ],
              )
          )
      ),
    );
  }
}