import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/pages/ArtistDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';


class AllArtists extends StatelessWidget {

  const AllArtists({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.deepPurpleAccent,
        actions: [
          Icon(Icons.account_box_rounded),
          Padding(
            padding: EdgeInsets.fromLTRB(5.0, 18.0, 18.0, 18.0),
            child: Text(
              APIService.username as String, style: TextStyle(fontSize: 16),),
          ),
        ],
        title: Text('Artists'),
      ),
      body: bodyWidget(context),
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
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          return ListView(
            children: snapshot.data!
                .map((e) => ArtistsWidget(e,context))
                .toList(),
          );
        }
      },
    );
  }

  Widget ArtistsWidget(Artist,context) {

    return Card(
        child: Container(
          height: 90,
          child: TextButton(
              onPressed: () {
                Navigator.push(
                  context, MaterialPageRoute(builder: (context) =>
                    ArtistDetails(artists: Artist)),
                );
              },
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Column(
                    children: [
                      Image(
                        width: 70,
                        height: 70,
                        image: MemoryImage(Artist.photo),
                            alignment: Alignment.centerLeft,)
                     ]
                    ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.end,
                    children: [
                      Text(Artist.firstName+' '+Artist.lastName, style: TextStyle(color: Colors.black,
                          fontSize: 16)),
                      Text(Artist.gender.genderName, style: TextStyle(color: Colors.black,)),
                      Text(Artist.dateOfBirth.day.toString()+'.'+Artist.dateOfBirth.month.toString()+'.'+Artist.dateOfBirth.year.toString()
                          +'-'+DeathCheck(Artist.dateOfDeath),
                          style: TextStyle(color: Colors.black,)),
                    ],
                  ),
                ],
              )
          )
      // ),
    )
    );
  }

  String DeathCheck(dateOfDeath) {
    return dateOfDeath!=null?dateOfDeath.day.toString()+'.'+dateOfDeath.month.toString()+'.'+dateOfDeath.year.toString():'  /  ';
  }


}
