import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/Genre.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'SongAndPodcasts/SongAndPodcastDetails.dart';

class TopRated extends StatefulWidget {
  const TopRated({Key? key}) : super(key: key);

  @override
  State<TopRated> createState() => _TopRatedState();
}
int? genre_id;

class _TopRatedState extends State<TopRated> {
  @override
  Widget build(BuildContext context) {


    return Scaffold(
      appBar: buildAppBar(context),
      drawer: buildDrawer(context),
      body: SingleChildScrollView(
          child: Column(
            children: [
              PageTitle(title: "Top rated"),
              LineSeparator(height: 6,width: 40),
              SizedBox(height: 15,),
              filterWidget(),
              SizedBox(height: 15,),
              bodyWidget(context),
            ],
          )
      ),
    );
  }


Widget filterWidget() {
  return FutureBuilder<List<Genre>>(
      future: GetGenre(),
      builder: (BuildContext context, AsyncSnapshot<List<Genre>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          Genre resetChoose=new Genre(genreId: 0,genreName: 'Filter by genre');
          List<Genre>? genres=[];
          genres.add(resetChoose);
          snapshot.data!.forEach((element) {genres.add(element);});
          Genre? valueChoose;
          genres.forEach((element)
            {
              if(genre_id==0)
                valueChoose=null;
              else if(element.genreId==genre_id)
                valueChoose=element;
            }
          );
          return Padding(
            padding: EdgeInsets.fromLTRB(5, 15, 0, 0),
            child: Container(
              padding: EdgeInsets.only(left: 20, right: 20,),
              child: DropdownButton(
                hint: Text("Filter",style: TextStyle(color: Colors.black87),),
                value: valueChoose,
                isExpanded: true,
                dropdownColor: PrimaryColor,
                icon: Icon(Icons.arrow_drop_down),
                iconSize: 36,
                onChanged: (value)=>setState(()
                {
                  Genre x= value as Genre;
                  valueChoose=value;
                  genre_id=value.genreId;
                  getSongAndPodcast(genre_id);
                }),
                items:
                genres.map((val)=>DropdownMenuItem(
                  value: val,
                  child: Text(val.genreName.toString()),
                  enabled: true,
                )
                ).toList(),

              ),
            ),
          );
        }
      }
  );
}



  //WIDGET BUILDER SAP
  Widget bodyWidget(BuildContext context) {
    return FutureBuilder<List<SAP>>(
      future: getSongAndPodcast(genre_id),
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
            return Text("No content yet");
          return ListView(
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!
                .map((e) => TopRatedtWidget(e,context))
                .toList(),
          );
        }
      },
    );
  }

  //UI
  Widget TopRatedtWidget(SAP SaP,BuildContext context) {
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
Future<List<SAP>> getSongAndPodcast(int? genreid) async {
  Map<String,String>?queryParams;
  if(genreid!=0 && genreid!=null){
    queryParams={'GenreId':genreid.toString()};
  }

  var x= await APIService.Get('SongAndPodcast',queryParams);
  var y= x!.map((e) => SAP.fromJson(e)).toList();
  y.sort((a,b)=>b.ratingValue!.compareTo(a.ratingValue!.round()));

  return y;
}

Future<List<Genre>> GetGenre() async {
  var x= await APIService.Get('Genre',null);
  var y= x!.map((e) => Genre.fromJson(e)).toList();
  return y;
}

