import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcasts/SongAndPodcastDetails.dart';
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
      body: SingleChildScrollView(
        child: Column(
          children: [
            PageTitle(title: this.isPodcast==false?'Songs':'Podcasts'),
            LineSeparator(height: 6,width: 40),
            SizedBox(height: 15,),
            bodyWidget(context),
          ],
        ),
      )
    );
  }

  Widget bodyWidget(BuildContext context) {
    return FutureBuilder<List<SAP>>(
      future: GetAllSongs(),
      builder: (BuildContext context,
          AsyncSnapshot<List<SAP>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          if(snapshot.data!.length==0)
            return Text("No content");
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

  Future<List<SAP>> GetAllSongs() async {
    var ispodcast=this.isPodcast.toString();
    Map<String, String>?querryParams;
    querryParams = {'IsPodcast': ispodcast};
    var SaPList = await APIService.Get('SongAndPodcast', querryParams);
    return SaPList!.map((i) => SAP.fromJson(i)).toList();
  }

  Widget SongAndPodcastWidget(SAP SaP,BuildContext context) {
    var running;
    if (SaP.runningTime == null)
      running = "Podcast";
    else
      running = timeFormat(SaP.runningTime);

    return Card(
      child: Container(
          height: 100,
          decoration: BoxDecoration(
              image: DecorationImage(
                image: MemoryImage(SaP.poster as Uint8List),
                fit: BoxFit.cover,
                alignment: Alignment.center,
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
                  Text(nameFormat(SaP.firstName,SaP.lastName), style: TextStyle(color: Colors.black,
                      backgroundColor: Colors.white.withOpacity(0.5))),
                  Text(running, style: TextStyle(color: Colors.black,
                      backgroundColor: Colors.white.withOpacity(0.5))),
                ],
              )
          )
      ),
    );
  }
}