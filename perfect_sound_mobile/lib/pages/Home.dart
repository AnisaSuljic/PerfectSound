import 'dart:typed_data';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:perfect_sound_mobile/models/News.dart';
import 'package:perfect_sound_mobile/models/Quote.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/AllNews.dart';
import 'package:perfect_sound_mobile/pages/AllSongsAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/Feelings.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'AllArtists.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();

  static DrawerWidget(BuildContext context) {
    return Drawer(
      child: ListView(
        children: [
          Container(
            height: 80,
            child: DrawerHeader(
                child: ListTile(
              title: Center(
                  child: Text('PerfectSound',
                      style: TextStyle(color: Colors.white, fontSize: 16))),
              onTap: () {
                Navigator.push(
                    context, MaterialPageRoute(builder: (context) => Home()));
              },
            )),
            decoration: BoxDecoration(color: Colors.deepPurpleAccent),
          ),
          Card(
            child: ListTile(
              title: Text(
                'News',
                style: TextStyle(fontSize: 16),
              ),
              onTap: () {
                //Navigator.of(context).pushReplacementNamed('/allnews');
                Navigator.push(context,
                    MaterialPageRoute(builder: (context) => AllNews()));
              },
            ),
          ),
          Card(
            child: ListTile(
              title: Text(
                'Songs',
                style: TextStyle(fontSize: 16),
              ),
              onTap: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) =>
                            AllSongsAndPodcasts(isPodcast: false)));
              },
            ),
          ),
          Card(
            child: ListTile(
              title: Text(
                'Podcasts',
                style: TextStyle(fontSize: 16),
              ),
              onTap: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) =>
                            AllSongsAndPodcasts(isPodcast: true)));
              },
            ),
          ),
          Card(
            child: ListTile(
              title: Text(
                'Artists',
                style: TextStyle(fontSize: 16),
              ),
              onTap: () {
                Navigator.push(context,
                    MaterialPageRoute(builder: (context) => AllArtists()));
              },
            ),
          ),
          Card(
            child: ListTile(
              title: Text(
                'Feelings',
                style: TextStyle(fontSize: 16),
              ),
              onTap: () {
                Navigator.push(context,
                    MaterialPageRoute(builder: (context) => Feelings()));
              },
            ),
          )
        ],
      ),
    );
  }
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
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
        backgroundColor: Colors.deepPurpleAccent,
      ),
      drawer: Home.DrawerWidget(context),
       body:
      Padding(
        padding: const EdgeInsets.all(10.0),
        child: Column(
          children: [
            QuoteWidget(),
            SizedBox(
              height: 10,
            ),
            Expanded(child:NewsWidget(),

            ),
          //
           ]
       )
      )
    );
  }
}

Widget QuoteWidget() {
  return FutureBuilder<Quote>(
    future:GetQuote(),
    builder: (BuildContext context, AsyncSnapshot<Quote> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(
          child: Text('Loading...')
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

Widget QuoteOfTheDay(Quote? x)
{
  return  Container(
    height: 150,
    decoration: BoxDecoration(color: Colors.grey.withOpacity(0.5)),
    child: Padding(
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
          Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                Text(x.songAndPodcast!.title.toString()
                    , style: TextStyle(fontSize: 12))])
        ],
      ),
    ),
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
          children: snapshot.data!.map((e) => Top3News(e)).toList(),
        );
      }
    },
  );
}

Future<List<News>> Get3News() async {

  var newsList = await APIService.Get('News',null);
  List<News> x=newsList!.map((i) => News.fromJson(i)).toList();
  print("sdas 3: "+x[0].title.toString());
  List<News> top3=<News>[];
  print("ff "+x.length.toString());
  for(int i =x.length-1;i>0;i--){
    if(top3.length==3)
      return top3;
    else
      top3.add(x[i]);
  }
  print("lista 3: "+top3[0].title.toString());
  return top3;
}

Widget Top3News(News e){
  return Text(e.title.toString());
}

/*
Container(
    width: 100,
    height: 120,
    decoration: BoxDecoration(
        color: Colors.pinkAccent.withOpacity(0.5)),
    child: Column(
      children: [
        Text(e.title.toString(), style: TextStyle(fontSize: 16))
      ],
    ),
  );*/

Widget Top3SaP(){
  return Container(
      height: 200,
      decoration: BoxDecoration(color: Colors.grey.withOpacity(0.5)),
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            Padding(
              padding: EdgeInsets.fromLTRB(0, 15, 0, 15),
              child: Row(
                children: [
                  Text('Najnovije pjesme/podcasti : ',
                      style: TextStyle(fontSize: 16))
                ],
              ),
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                Container(
                  width: 100,
                  height: 120,
                  decoration: BoxDecoration(
                      color: Colors.pinkAccent.withOpacity(0.5)),
                  child: Column(
                    children: [],
                  ),
                ),
                Container(
                  width: 100,
                  height: 120,
                  decoration: BoxDecoration(
                      color: Colors.pinkAccent.withOpacity(0.5)),
                  child: Column(
                    children: [],
                  ),
                ),
                Container(
                  width: 100,
                  height: 120,
                  decoration: BoxDecoration(
                      color: Colors.pinkAccent.withOpacity(0.5)),
                  child: Column(
                    children: [],
                  ),
                )
              ],
            )
          ],
        ),
      )
  );
}


