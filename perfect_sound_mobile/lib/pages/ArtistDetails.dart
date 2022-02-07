import 'dart:typed_data';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcastPerson.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class ArtistDetails extends StatefulWidget {
  final Artists artists;

  ArtistDetails({Key? key,required this.artists}) : super(key: key);

  late String sort='';

  @override
  _ArtistDetailsState createState() => _ArtistDetailsState();
}

class _ArtistDetailsState extends State<ArtistDetails> {
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
              APIService.username as String,
              style: TextStyle(fontSize: 16),
            ),
          ),
        ],
        title: Text('Details'),
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            bodyWidget(),
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
                          widget.sort='up';
                          GetSongAndPodcastPerson(widget.artists.personId, widget.sort);
                          setState(() {});
                        },
                        icon:Icon(Icons.arrow_upward),

                      ),
                      IconButton(
                        onPressed: () {
                          widget.sort='down';
                          GetSongAndPodcastPerson(widget.artists.personId, widget.sort);
                          setState(() {});
                        },
                        icon:Icon(Icons.arrow_downward),

                      )
                    ],
                  ),
                ],
              ),
            ),
            ArtistSaPWidget(widget.artists.personId),
          ],
        ),
      ),
    );
  }

  Widget bodyWidget() {
    return Column(children: [
      Container(
        height: 100,
        decoration: BoxDecoration(
            border: Border(bottom: BorderSide(color: Colors.grey, width: 1.2))),
        child: Row(
          children: [
            Expanded(
              flex: 40,
              child: Container(
                alignment: Alignment.center,
                child: Image(
                    width: 80,
                    height: 80,
                    image: MemoryImage(widget.artists.photo as Uint8List)),
              ),
            ),
            Expanded(
                flex: 60,
                child: Container(
                    alignment: Alignment.center,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Text(
                          widget.artists.firstName.toString() +
                              ' ' +
                              widget.artists.lastName.toString(),
                          style: TextStyle(fontSize: 20),
                        ),
                        Text(
                          widget.artists.dateOfBirth!.day.toString() +
                              "." +
                              widget.artists.dateOfBirth!.month.toString() +
                              "." +
                              widget.artists.dateOfBirth!.year.toString() +
                              '   - ' +
                              DeathCheck(widget.artists.dateOfDeath),
                          style: TextStyle(
                              fontSize: 16,
                              backgroundColor: Colors.grey.withOpacity(0.5),
                              color: Colors.black),
                        )
                      ],
                    )
                )
            )
          ],
        ),
      ),

      Container(
        decoration: BoxDecoration(
            border: Border(bottom: BorderSide(color: Colors.grey, width: 1.2))),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text('Gender : ' + widget.artists.gender!.genderName.toString(),
                    style: TextStyle(fontSize: 16, color: Colors.black),),
                  Text('Birth place : ' + widget.artists.placeOfBirth.toString(),
                    style: TextStyle(fontSize: 16, color: Colors.black),),
                ],
              ),
            ),
          ],
        ),
      ),

      Container(
          decoration: BoxDecoration(
              border: Border(bottom: BorderSide(color: Colors.grey, width: 1.2))),
          child: Column(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Padding(
                    padding: EdgeInsets.fromLTRB(0, 10, 0, 10),
                    child: Text('Biography',
                        style: TextStyle(fontSize: 16, color: Colors.black)),
                  ),
                ],
              ),
              Padding(
                padding: const EdgeInsets.all(10.0),
                child: Container(
                    child:Text(widget.artists.biography.toString(),
                        style: TextStyle(fontSize: 16, color: Colors.black))
                ),
              ),
              SizedBox(
                height: 20,
              )
            ],
          )
      )
    ]);
  }


  String DeathCheck(dateOfDeath) {
    return dateOfDeath != null
        ? dateOfDeath.day.toString() +
        '.' +
        dateOfDeath.month.toString() +
        '.' +
        dateOfDeath.year.toString()
        : '  /  ';
  }

  Widget ArtistSaPWidget(int? personId)
  {
    return FutureBuilder<List<SongAndPodcastPerson>>(
      future: GetSongAndPodcastPerson(personId,widget.sort),
      builder: (BuildContext context, AsyncSnapshot<List<SongAndPodcastPerson>> snapshot) {
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
            children: snapshot.data!.map((e) => SongAndPodcastPersonList(e)).toList(),
          );
        }
      },
    );
  }

  Future<List<SongAndPodcastPerson>> GetSongAndPodcastPerson(int? personId, String sort) async {

    Map<String,String>?querryParams;
    if(personId!=null){
      querryParams={'personId':personId.toString()};
    }
    var SongAndPodcastPersonList = await APIService.Get('SongAndPodcastPerson',querryParams);

    var x=SongAndPodcastPersonList!.map((i) => SongAndPodcastPerson.fromJson(i)).toList();
    if(sort=='down')
      x.sort((a,b)=>a.songAndPodcast!.releaseDate!.compareTo(b.songAndPodcast!.releaseDate as DateTime));
    if(sort==''||sort=='up')
    {
      x.reversed;
    }
    return x;
  }

  Widget SongAndPodcastPersonList(SongAndPodcastPerson e){
    return
      Card(
        child:  Padding(
          padding: const EdgeInsets.all(10.0),
          child: Container(
            height: 80,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(e.songAndPodcast!.title.toString(),
                    style: TextStyle(color: Colors.deepPurpleAccent,fontSize: 16)),
                Text(e.songAndPodcast!.releaseDate!.day.toString()+'.'+
                    e.songAndPodcast!.releaseDate!.month.toString()+'.'+
                    e.songAndPodcast!.releaseDate!.year.toString()),
              ],
            ),
          ),
        ),
      );
  }
}

