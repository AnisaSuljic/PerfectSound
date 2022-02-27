import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcasts/SongAndPodcastDetails.dart';

class ArtistDetails extends StatefulWidget {
  final Artists artists;
  final List<SAP?> listSap;
  ArtistDetails({Key? key, required this.artists, required this.listSap}) : super(key: key);

  @override
  _ArtistDetailsState createState() => _ArtistDetailsState();
}
class _ArtistDetailsState extends State<ArtistDetails> {
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
                                      sortUp();
                                    });
                                  },
                                  icon:Icon(Icons.arrow_upward),

                                ),
                                IconButton(
                                  onPressed: () {
                                    setState(() {
                                      sortDown();
                                    });
                                  },
                                  icon:Icon(Icons.arrow_downward),

                                )
                              ],
                            ),
                          ],
                        ),
                      ),
                      ListView(
                        scrollDirection: Axis.vertical,
                        shrinkWrap: true,
                        children:
                        this.widget.listSap.map((e) => SongAndPodcastPersonListWidget(e!)).toList(),
                      )
                  ]
                )
            )
        );
  }
  void sortUp() {
    this.widget.listSap.sort((a, b) => a!.releaseDate!
          .compareTo(b!.releaseDate as DateTime));
  }
  void sortDown() {
    this.widget.listSap.sort((a, b) => b!.releaseDate!
        .compareTo(a!.releaseDate as DateTime));
  }

  Widget SongAndPodcastPersonListWidget(SAP e) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(10.0),
        child: TextButton(
          onPressed: (){
            Navigator.push(
              context, MaterialPageRoute(builder: (context) =>
                SongAndPodcastDetails(songAndPodcast: e,)),
            );
          },
          child: Container(
            height: 80,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(e.title.toString(),
                    style:TextStyle(color: PrimaryColor, fontSize: 16)),
                Text(dateFormatConverter(e.releaseDate),style:TextStyle(color: PrimaryColor,)),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
