import 'package:flutter/cupertino.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:flutter/rendering.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/News.dart';
import 'package:perfect_sound_mobile/models/Quote.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/AllNews.dart';
import 'package:perfect_sound_mobile/pages/AllSongsAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/Feelings.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';
import 'AllArtists.dart';
import 'Login&SignUp/Login.dart';
import 'Login&SignUp/UserProfile.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: buildAppBar(context),
      drawer: buildDrawer(context),
      /*body:
      Padding(
        padding: EdgeInsets.fromLTRB(10, 20, 10, 10),
        child: Column(
          children: [
            Container(
              height: 180,
              decoration: BoxDecoration(color: Colors.grey.withOpacity(0.5)),
              child:QuoteWidget()
            ),
            SizedBox(
              height: 10,
            ),
            Container(
              height: 180,
              decoration: BoxDecoration(color: Colors.grey.withOpacity(0.5)),
                child:NewsWidget(),
            ),
            SizedBox(
              height: 10,
            ),
            Container(
              height: 180,
              decoration: BoxDecoration(color: Colors.grey.withOpacity(0.5)),
              child:SaPWidget(),
            )
           ]
       )
      )*/
    );
  }
}



/*
Widget QuoteWidget() {
  return FutureBuilder<Quote>(
    future:GetQuote(),
    builder: (BuildContext context, AsyncSnapshot<Quote> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(
          child: Text('')
        );
      } else if (snapshot.hasError) {
        return Center(
          child: Text('${snapshot.error}'),
        );
      }
      else {
        return QuoteOfTheDay(snapshot.data);
      }
    },
  );
}

Future<Quote> GetQuote() async {
  var quote = await APIService.GetRandom('Quote/GetRandomQuote');
  var x=Quote.fromJson(quote);
  SongAndPodcast sap=await GetSongAndPodcast(x.songAndPodcastId as int);
  x.songAndPodcast=sap;
  return x;
}

GetSongAndPodcast(int id) async {
  var x= await APIService.GetById('SongAndPodcast',id.toString());
  var y=SongAndPodcast.fromJson(x);
  return y;
}

Widget QuoteOfTheDay(Quote? x){
  return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        children: [
          Padding(
            padding: EdgeInsets.fromLTRB(0, 15, 0, 15),
            child: Row(
              children: [
                Text('Quote of the day : ', style: TextStyle(fontSize: 16))
              ],
            ),
          ),
          Container(
              child: Text(x!.quoteText.toString(),
                  style: TextStyle(fontSize: 16))),
          Padding(
            padding: EdgeInsets.fromLTRB(0, 50, 10, 10),
            child: Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  Text(x.songAndPodcast!.title.toString()
                      , style: TextStyle(fontSize: 12))]),
          )
        ],
      )
  );
}



Widget NewsWidget() {
  return FutureBuilder<List<News>>(
    future: Get3News(),
    builder: (BuildContext context, AsyncSnapshot<List<News>> snapshot) {
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
          scrollDirection: Axis.horizontal,
          children: snapshot.data!.map((e) => Top3News(e)).toList(),
        );
      }
    },
  );
}

Future<List<News>> Get3News() async {

  var newsList = await APIService.Get('News',null);
  List<News> x=newsList!.map((i) => News.fromJson(i)).toList();
  List<News> top3=<News>[];
  for(int i =x.length-1;i>0;i--){
    if(top3.length==3)
      return top3;
    else
      {
        top3.add(x[i]);
      }
  }
  return top3;
}

Widget Top3News(News e){
  return
      Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Padding(
            padding: EdgeInsets.fromLTRB(10, 0, 10, 0),
            child: Container(
                height: 150,
                width: 110,
                decoration: BoxDecoration(color: Colors.amber),
                child:Text(e.title.toString(),textAlign: TextAlign.center,)
              ),
          ),
        ],
      );
}



Widget SaPWidget() {
  return FutureBuilder<List<SongAndPodcast>>(
    future: Get3SaP(),
    builder: (BuildContext context, AsyncSnapshot<List<SongAndPodcast>> snapshot) {
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
          scrollDirection: Axis.horizontal,
          children: snapshot.data!.map((e) => Top3SaP(e)).toList(),
        );
      }
    },
  );
}

Future<List<SongAndPodcast>> Get3SaP() async {

  var SongAndPodcastList = await APIService.Get('SongAndPodcast',null);
  List<SongAndPodcast> x=SongAndPodcastList!.map((i) => SongAndPodcast.fromJson(i)).toList();
  List<SongAndPodcast> top3=<SongAndPodcast>[];
  for(int i =x.length-1;i>0;i--){
    if(top3.length==3)
      return top3;
    else
    {
      top3.add(x[i]);
    }
  }
  return top3;
}

Widget Top3SaP(SongAndPodcast e){
  return
    Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Padding(
          padding: EdgeInsets.fromLTRB(10, 0, 10, 0),
          child: Container(
              height: 150,
              width: 110,
              decoration: BoxDecoration(color: Colors.amber),
              child:Text(e.title.toString(),textAlign: TextAlign.center,)
          ),
        ),
      ],
    );
}

*/
