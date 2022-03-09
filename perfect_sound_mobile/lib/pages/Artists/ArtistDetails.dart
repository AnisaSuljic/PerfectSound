import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcasts/SongAndPodcastDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class ArtistDetails extends StatefulWidget {
  final Artists artists;
  ArtistDetails({Key? key, required this.artists}) : super(key: key);

  @override
  _ArtistDetailsState createState() => _ArtistDetailsState();
}

class _ArtistDetailsState extends State<ArtistDetails> {
  List<SAP?> listSap=[];
  bool isDesc=true;
  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return
        Scaffold(
            appBar: buildAppBar(context),
            body: SingleChildScrollView(
                child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                  //image and rating
                    Container(
                        height: size.height * 0.4,
                        child: Stack(
                          children: [
                            Container(
                              height: size.height * 0.4 - 30,
                              decoration: BoxDecoration(
                                  borderRadius: BorderRadius.only(
                                      bottomLeft: Radius.circular(50)),
                                  image: DecorationImage(
                                    fit: BoxFit.fitHeight,
                                    image: MemoryImage(
                                        this.widget.artists.photo as Uint8List),
                                  )),
                            ),
                            Positioned(
                                bottom: 0,
                                right: 0,
                                child: Container(
                                  height: 70,
                                  width: size.width * 0.9,
                                  decoration: BoxDecoration(
                                      borderRadius: BorderRadius.only(
                                          bottomLeft: Radius.circular(50),
                                          topLeft: Radius.circular(50)),
                                      color: Colors.white,
                                      boxShadow: [
                                        BoxShadow(
                                            offset: Offset(0, 5),
                                            blurRadius: 10,
                                            color: Colors.grey.withOpacity(0.9))
                                      ]),
                                  child: Container(
                                    width: size.width*0.8,
                                    child: Center(
                                      child: Text(
                                        nameFormat(this.widget.artists.firstName,
                                            this.widget.artists.lastName),
                                        style: TextStyle(fontSize: 20),maxLines: 2,
                                      ),
                                    ),
                                  )
                                ))
                          ],
                        )
                    ),
                        SizedBox(height: 10,),

                        //title, release date, time and prod company + button "read more"
                    Padding(
                      padding: EdgeInsets.all(10),
                      child: Column(
                        children: [
                          Row(
                            children: [
                              Text("Place of birth :  "),
                              Text(this.widget.artists.placeOfBirth.toString()),
                            ],
                          ),
                          SizedBox(height: 10,),
                          Row(
                            children: [
                              Text("Date of birth :  "),
                              Text(dateFormatConverter(this.widget.artists.dateOfBirth)),
                            ],
                          ),
                          SizedBox(height: 10,),
                          Row(
                            children: [
                              Text("Date of death :  "),
                              Text(this.widget.artists.dateOfDeath==null?'Not dead':dateFormatConverter(this.widget.artists.dateOfDeath)),
                            ],
                          ),
                          SizedBox(height: 10,),
                          Row(
                            children: [
                              Text("Gender :  "),
                              Text(this.widget.artists.gender!.genderName.toString()),
                            ],
                          ),
                          ]
                      ),
                    ),
                    //ARTIST Biography
                    Padding(
                      padding: EdgeInsets.symmetric(
                        vertical: 5,
                        horizontal: 10,
                      ),
                      child: Text(
                        "Biography",
                        style: TextStyle(fontSize: 16),
                      ),
                    ),
                    Padding(
                      padding: EdgeInsets.symmetric(horizontal: 10),
                      child: Text(
                        this.widget.artists.biography.toString(),
                        style: TextStyle(fontSize: 10),
                      ),
                    ),

                      //list sap
                      SizedBox(
                        height: 10,
                      ),
                      Padding(
                        padding: const EdgeInsets.all(10.0),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Text("Songs/Podcasts:", style: TextStyle(fontSize: 16),),
                            Row(
                              children: [
                                IconButton(
                                  onPressed: () {
                                   setState(() {
                                     this.isDesc=false;
                                      //sortUp();
                                    });
                                  },
                                  icon:Icon(Icons.arrow_upward),

                                ),
                                IconButton(
                                  onPressed: () {
                                    setState(() {
                                      this.isDesc=true;
                                      //sortDown();
                                    });
                                  },
                                  icon:Icon(Icons.arrow_downward),

                                )
                              ],
                            ),
                          ],
                        ),
                      ),
                      SAPlistWidget()
                  ]
                )
            )
        );
  }
  void sortUp() {
    listSap.sort((a, b) => a!.releaseDate!
          .compareTo(b!.releaseDate as DateTime));
  }
  void sortDown() {
    listSap.sort((a, b) => b!.releaseDate!
        .compareTo(a!.releaseDate as DateTime));
  }

  Widget SAPlistWidget() {
    return FutureBuilder<List<SAP?>>(
      future: GetSongAndPodcastPerson(this.widget.artists.personId),
      builder: (BuildContext context, AsyncSnapshot<List<SAP?>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: CircularProgressIndicator(color: PrimaryColor,),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          listSap=snapshot.data!;
          this.isDesc?sortDown():sortUp();
          if(listSap.length==0)
            return Center(child: Text('No song and/or podcasts yet'));
          return ListView(
          physics: ClampingScrollPhysics(),
          scrollDirection: Axis.vertical,
          shrinkWrap: true,
          children: listSap.map((e) => SongAndPodcastPersonListWidget(e!)).toList(),
          );
        }
      },
    );
  }

  Widget SongAndPodcastPersonListWidget(SAP e,) {
    return Card(
      child: TextButton(
        onPressed: (){
          Navigator.push(
            context, MaterialPageRoute(builder: (context) =>
              SongAndPodcastDetails(songAndPodcast: e,)),
          );
        },
        child: Container(
          height: 80,
          decoration: BoxDecoration(
              image: DecorationImage(
                image: MemoryImage(e.poster as Uint8List),
                fit: BoxFit.cover,
                alignment: Alignment.center,
              )
          ),
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(e.title.toString(), style: TextStyle(color: Colors.black,
                    fontSize: 16, fontWeight: FontWeight.bold,
                    backgroundColor: Colors.white.withOpacity(0.8))),
                Text(dateFormatConverter(e.releaseDate), style: TextStyle(color: Colors.black,
                    backgroundColor: Colors.white.withOpacity(0.8))),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Future<List<SAP>> GetSongAndPodcastPerson(int? personId) async {
    Map<String, String>? querryParams;
    if (personId != null) {
      querryParams = {'ArtistId': personId.toString()};
    }
    var x=await APIService.Get('SongAndPodcast', querryParams);
    return x!.map((i) => SAP.fromJson(i)).toList();
  }
}
