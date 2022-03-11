import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'SongAndPodcasts/SongAndPodcastDetails.dart';

class Recommended extends StatefulWidget {
  const Recommended({Key? key}) : super(key: key);

  @override
  _RecommendedState createState() => _RecommendedState();
}

class _RecommendedState extends State<Recommended> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: buildAppBar(context),
      drawer: buildDrawer(context),
      body: SingleChildScrollView(
          child: Column(
            children: [
              PageTitle(title: "Recommended"),
              LineSeparator(height: 6,width: 40),
              SizedBox(height: 15,),
              bodyWidget(context),
            ],
          )
      ),
    );
  }

  //WIDGET BUILDER SAP
  Widget bodyWidget(BuildContext context) {
    return FutureBuilder<List<SAP>>(
      future: getRecommendedSongAndPodcast(),
      builder: (BuildContext context,
          AsyncSnapshot<List<SAP>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: CircularProgressIndicator(color: PrimaryColor,),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          if(snapshot.data!.length==0)
            return Text("No recommended songs or podcasts");
          return ListView(
            physics: ClampingScrollPhysics(),
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!
                .map((e) => RecommendedWidget(e,context))
                .toList(),
          );
        }
      },
    );
  }

  //UI
  Widget RecommendedWidget(SAP SaP,BuildContext context) {
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
                Navigator.push(context, MaterialPageRoute(builder: (context) =>SongAndPodcastDetails(songAndPodcast: SaP)),);
              },
              child: Column(
                children: [
                  Text(SaP.title.toString(), style: TextStyle(color: Colors.black,
                      fontSize: 20,backgroundColor: Colors.white.withOpacity(0.6))),
                  SizedBox(height: 5,),
                  Text(SaP.firstName !=null && SaP.lastName!=null?SaP.firstName! + " "+ SaP.lastName!:'Unknown performer', style: TextStyle(color: Colors.black,
                      fontSize: 15,backgroundColor: Colors.white.withOpacity(0.6))),
                  Align(
                    alignment: Alignment.bottomRight,
                    child: Text('Rate : '+SaP.ratingValue.toString(), style: TextStyle(color: Colors.black,
                        fontSize: 16,backgroundColor: Colors.white.withOpacity(0.6))),
                  ),
                ],
              )
          )
      ),
    );
  }
}

//METHOD GET SAP
Future<List<SAP>> getRecommendedSongAndPodcast() async {
  var x= await APIService.Get('Recommended/Similar/${APIService.usersData!.userId}',null);
  var y= x!.map((e) => SAP.fromJson(e)).toList();
  y.sort((a,b)=>b.ratingValue!.compareTo(a.ratingValue!.round()));

  return y;
}
