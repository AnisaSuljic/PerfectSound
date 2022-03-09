import 'dart:async';
import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:flutter/rendering.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/News.dart';
import 'package:perfect_sound_mobile/models/Quote.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/pages/News/NewsDetails.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcasts/SongAndPodcastDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size; //total height&width of screen

    return Scaffold(
      appBar: buildAppBar(context),
      drawer: buildDrawer(context),
      body:
        Container(
          child: Column(
            children: [
              PageTitle(title: "Discover"),
              LineSeparator(height: 6,width: 40),
              Expanded(
                flex: 1,
                  child: Container(
                      margin: EdgeInsets.all(10),
                      child:
                      Column(
                          children: [
                            Padding(
                              padding: const EdgeInsets.fromLTRB(10,0,10,0),
                              child:Align(alignment: Alignment.centerLeft, child: Text('Quote of the day : ', style: TextStyle(fontSize: 16,fontWeight: FontWeight.bold),)),
                            ),
                            SizedBox(height: 5,),
                            quoteWidget()
                          ]
                      )
                  )
              ),
              LineSeparator(height: 3,width: size.width/2),
              ExpandedArea(title:"Last 3 news : ", widget: newsWidget()),
              LineSeparator(height: 3,width: size.width/2),
              ExpandedArea(title:"Last 3 songs / podcasts : ", widget: sapWidget()),
            ],
          ),
        )
      );
  }
}


class ExpandedArea extends StatelessWidget {
  final String title;
  final Widget widget;
  const ExpandedArea({
    Key? key, required this.title, required this.widget,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Expanded(
        flex: 2,
        child: Container(
          margin: EdgeInsets.all(10),
          child:
          Column(
            children: [
              Padding(
              padding: const EdgeInsets.fromLTRB(10,0,10,0),
                child: Align(alignment: Alignment.centerLeft, child: Text(title, style: TextStyle(fontSize: 16,fontWeight: FontWeight.bold),)),
            ),
            SizedBox(height: 10,),
              widget
          ]
        )
      ),
    );
  }
}

//METHOD GET RANDOM QUOTE
Future<Quote> getQuote() async {
  var quote = await APIService.GetRandom();
  var x=Quote.fromJson(quote);
  return x;
}

//METHOD GET TOP 3 NEWS
Future<List<News>> get3News() async {
  var newsList = await APIService.Get('News/Last3',null);
  List<News> x=newsList!.map((i) => News.fromJson(i)).toList();
  return x;
}

//METHOD GET TOP 3 SAP
Future<List<SAP>> get3SaP() async {
  var songAndPodcastList = await APIService.Get('SongAndPodcast/Last3',null);
  List<SAP> x=songAndPodcastList!.map((i) => SAP.fromJson(i)).toList();
  return x;

}


//UI
Widget quoteOfTheDay(Quote? x,BuildContext context){
  return Padding(
    padding: const EdgeInsets.only(right: 10,left: 10),
    child: Column(
      children: [
        Text(x!.quoteText.toString(),style: TextStyle(fontSize: 14)),
        SizedBox(
          height: 30,
          child: TextButton(
          onPressed: () async{
            Navigator.push(
              context, MaterialPageRoute(builder: (context) =>
                SongAndPodcastDetails(songAndPodcast: x.songAndPodcast as SAP)),
            );
          }
          ,child: Text(x.songAndPodcast!.title.toString()+'-'+x.artistName.toString(), style: TextStyle(fontSize: 12,fontWeight: FontWeight.bold,color: PrimaryColor))),
        )
      ],
    ),
  );
}
//UI
Widget top3News(News e,BuildContext context){
  return TextButton(
    child: Container(
        height: 160,
        width: 110,
        decoration: BoxDecoration(border: Border.all(color: PrimaryColor,width: 2),borderRadius:BorderRadius.circular(5)),
        child:
        Padding(
          padding: const EdgeInsets.all(5.0),
          child: Column(
            children: [
              Expanded(flex:1,child: Image(image: MemoryImage(e.coverPhoto as Uint8List))),
              SizedBox(height: 5,),
              Expanded(flex:2,child: Text(e.title.toString(),textAlign: TextAlign.center,style: TextStyle(fontSize: 12,color: Colors.black87),)),
            ],
          ),
        )
    ),
      onPressed: () async{
      //News news=await getNews(e.newsId as int);
        Navigator.push(
          context, MaterialPageRoute(builder: (context) =>
            NewsDetails(news: e)),
        );
      }
  );
}
//UI
Widget top3SaP(SAP e, BuildContext context){
  return
    TextButton(
      child: Container(
          height: 160,
          width: 110,
          decoration: BoxDecoration(border: Border.all(color: PrimaryColor,width: 2),borderRadius:BorderRadius.circular(5)),
          child:
          Padding(
            padding: const EdgeInsets.all(5.0),
            child: Column(
              children: [
                Expanded(flex:1,child: Image(image: MemoryImage(e.poster as Uint8List))),
                SizedBox(height: 5,),
                Expanded(flex: 1, child:
                  Column(
                    children: [
                      Text(e.title.toString(),textAlign: TextAlign.center,style: TextStyle(fontSize: 12,color: Colors.black87),),
                      Text(nameFormat(e.firstName,e.lastName),textAlign: TextAlign.center,style: TextStyle(fontSize: 8,color: Colors.black87),),
                      SizedBox(height: 5,),
                      Text("Rate: "+ e.ratingValue.toString(),textAlign: TextAlign.center,style: TextStyle(fontSize: 10,color: Colors.black87),),
                      SizedBox(height: 5,),
                      Align(alignment: Alignment.bottomRight, child: Text(e.isPodcast==true?"Podcast":"Song",style: TextStyle(fontSize: 10,color: Colors.black87),)),
                    ],
                  )
                ),
              ],
            ),
          )
      ),
        onPressed: () async{
          //SAP SaP=await getSongAndPodcast(e.songAndPodcastId as int);
          Navigator.push(
            context, MaterialPageRoute(builder: (context) =>
              SongAndPodcastDetails(songAndPodcast: e)),
          );
        }
    );
}


//FUTURE BUILDER NEWS
Widget newsWidget() {
  return FutureBuilder<List<News>>(
    future: get3News(),
    builder: (BuildContext context, AsyncSnapshot<List<News>> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(
          child: Text('Loading...'),
        );
      } else if (snapshot.hasError) {
        return Center(
          child: Text('Unable to load'),
        );
      } else {
          return Row(
            mainAxisAlignment: snapshot.data!.length<3?MainAxisAlignment.start:MainAxisAlignment.spaceEvenly,
            children: snapshot.data!.map((e) => top3News(e,context)).toList(),
          );
      }
    },
  );
}
//FUTURE BUILDER SAP
Widget sapWidget() {
  return FutureBuilder<List<SAP>>(
    future: get3SaP(),
    builder: (BuildContext context, AsyncSnapshot<List<SAP>> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(
          child: Text('Loading...'),
        );
      } else if (snapshot.hasError) {
        return Center(
          child: Text('Unable to load'),
        );
      } else {
        return Row(
          mainAxisAlignment: snapshot.data!.length<3?MainAxisAlignment.start:MainAxisAlignment.spaceEvenly,
          children: snapshot.data!.map((e) =>top3SaP(e, context)).toList(),
        );
      }
    },
  );
}
//FUTURE BUILDER QUOTE
Widget quoteWidget() {
  return FutureBuilder<Quote>(
    future:getQuote(),
    builder: (BuildContext context, AsyncSnapshot<Quote> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(
            child: Text('Loading...')
        );
      } else if (snapshot.hasError) {
        return Center(
          child: Text('Unable to load'),
        );
      }
      else {
        return quoteOfTheDay(snapshot.data,context);
      }
    },
  );
}


