import 'dart:ffi';
import 'dart:typed_data';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcastPerson.dart';
import 'package:perfect_sound_mobile/pages/Artists/ArtistDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';


class AllArtists extends StatelessWidget {

  const AllArtists({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size=MediaQuery.of(context).size;
    return Scaffold(
      appBar: buildAppBar(context),
      drawer: buildDrawer(context),
      body: SingleChildScrollView(
        child: Column(
          children: [
            PageTitle(title: 'Artists'),
            LineSeparator(height: 6,width: 40),
            SizedBox(height: 15,),
            bodyWidget(context),
          ],
        ),
      )
    );
  }

  Future<List<Artists>> GetAllArtists() async {
    var ArtistsList = await APIService.Get('Person',null);
    return ArtistsList!.map((i) => Artists.fromJson(i)).toList();
  }

  Widget bodyWidget(BuildContext context) {
    return FutureBuilder<List<Artists>>(
      future: GetAllArtists(),
      builder: (BuildContext context,
          AsyncSnapshot<List<Artists>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: CircularProgressIndicator(color: PrimaryColor,),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          return ListView(
            physics: ClampingScrollPhysics(),
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!
                .map((e) => ArtistsWidget(e,context))
                .toList(),
          );
        }
      },
    );
  }

  Widget ArtistsWidget(Artists Artist,context) {
    Size size= MediaQuery.of(context).size;
    return Card(
        child: Container(
          height: 90,
          child: TextButton(
              onPressed: () async {
                //var list=await GetSongAndPodcastPerson(Artist.personId);
                Navigator.push(
                  context, MaterialPageRoute(builder: (context) =>
                    ArtistDetails(artists: Artist)),
                );
              },
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    height: size.height*0.2,
                    width: size.width*0.2,
                    decoration: BoxDecoration(
                        image: DecorationImage(
                          fit: BoxFit.fitHeight,
                          image: MemoryImage(Artist.photo as Uint8List),
                        )
                    ),
                  ),
                  SizedBox(width: 10,),
                  Container(
                    width: size.width*0.5,
                    child: Text(nameFormat(Artist.firstName, Artist.lastName),
                      style: TextStyle(color: Colors.black87,fontSize: 16),maxLines: 2,textAlign: TextAlign.center,),
                  )
                ],
              )
          )
       )
    );
  }

  Future<List<SAP?>> GetSongAndPodcastPerson(
      int? personId) async {
    Map<String, String>? querryParams;
    if (personId != null) {
      querryParams = {'personId': personId.toString()};
    }
    var SongAndPodcastPersonList =
    await APIService.Get('SongAndPodcastPerson', querryParams);

    List<SAP?> x = SongAndPodcastPersonList!
        .map((i) => SongAndPodcastPerson.fromJson(i).songAndPodcast)
        .toList();
    return x;
  }


}
