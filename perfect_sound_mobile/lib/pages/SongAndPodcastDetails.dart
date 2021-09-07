import 'dart:typed_data';
import 'dart:ui';

import 'package:flutter/cupertino.dart';
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
      body: Padding(
        padding: const EdgeInsets.all(10.0),
        child: bodyWidget(),
      ),
    );
  }
  Widget bodyWidget() {
    return Column(
      children: [
        Container(
          height: 100,
          decoration: BoxDecoration(border: Border(bottom: BorderSide(color: Colors.grey,width: 1.2))),
          child: Row(
            children: [
              Expanded(
                flex: 40,
                child:  Container(
                  alignment: Alignment.center,
                  child: Image(
                        width:80,
                        height: 80,
                        image: MemoryImage(songAndPodcast.poster as Uint8List)
                    ),
                ),
              ),
              Expanded(
                flex: 60,
                child:
                  Container(
                    alignment: Alignment.center,
                      child: Text(songAndPodcast.title.toString(),style: TextStyle(fontSize: 20),)
                  )
              )
            ],
          ),
        ),
        Container(
          height: 80,
          //decoration: BoxDecoration(color: Colors.pinkAccent),
          //child: Padding(
            //padding: EdgeInsets.fromLTRB(15, 0, 15, 0),
            child: Column(
              children: [
                Container(
                  height: 40,
                  alignment: Alignment.center,
                  //decoration: BoxDecoration(color: Colors.blueAccent),
                  child: Row(
                    children: [
                      Text(songAndPodcast.releaseDate!.day.toString()+"."+songAndPodcast.releaseDate!.month.toString()+"."+songAndPodcast.releaseDate!.year.toString()
                        ,style: TextStyle(fontSize: 16,backgroundColor:Colors.grey.withOpacity(0.5),color: Colors.black),)
                    ],
                  ),
                ),
                Container(
                  height: 40,
                  alignment: Alignment.bottomCenter,
                  //decoration: BoxDecoration(color: Colors.deepOrange),
                  child: Row(
                    children: [
                      Expanded(
                        flex: 60,
                        child: Text("Ocijeni  ",style: TextStyle(fontSize: 16)),
                      ),
                      Expanded(
                        flex: 40,
                          child:Column(
                            mainAxisAlignment: MainAxisAlignment.spaceAround,
                            children: [
                              Text('4.7',style: TextStyle(fontSize: 16,backgroundColor:Colors.grey.withOpacity(0.5),color: Colors.black),),
                              Text('Prosječna ocjena',style: TextStyle(fontSize: 12,color: Colors.black))
                            ],
                          )
                      )
                    ],
                  ),
                )
              ],
            ),
          //),
        ),
        SizedBox(
          height: 10,
        ),
        Container(
          height: 60,
          decoration: BoxDecoration(color: Colors.deepPurpleAccent),
          child:
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Column(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text("Žanr:",style: TextStyle(fontSize: 16)),
                    for(var i=0;i<songAndPodcast.genre!.length;i++) Text(' | '+songAndPodcast.genre![i].genreName.toString()+' | ',style: TextStyle(fontSize: 14,color: Colors.black))
                  ],
                )
              ],
            ),
          )
        ),

        Container(
          height: 80,
          decoration: BoxDecoration(border: Border(bottom: BorderSide(color: Colors.grey,width: 1.2))),
            child:Column(
              children:[
                  Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children:
                    [
                      Padding(
                        padding: EdgeInsets.fromLTRB(0, 10, 0, 10),
                        child: Text("Izvođači: ",style: TextStyle(fontSize: 16)),
                      ),
                    ]
                  ),
                Row(
                  children: [
                    Container(
                      //decoration: BoxDecoration(color: Colors.blue),
                      child: Row(
                        children: [
                          Padding(
                            padding: EdgeInsets.fromLTRB(5, 0, 5, 0),
                            child: Image(
                                width: 30,
                                height: 30,
                                image: MemoryImage(songAndPodcast.poster as Uint8List)
                                ),
                          ),
                          Text("Naziv izvođača"+" | ")
                        ],
                      ),
                    )
                  ],
                )
               ]
            )
        ),
        Container(
          child: Column(
            children: [
              Padding(
                padding: EdgeInsets.fromLTRB(0, 10, 0, 10),
                child: Row(
                  children: [
                    Text("Komentari: ",style: TextStyle(fontSize: 16))
                  ],
                ),
              ),

            ],
          ),
        )
      ],
    );
  }
}
