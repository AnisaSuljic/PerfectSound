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
import 'package:perfect_sound_mobile/models/Rating/Rating.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/NewsDetails.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcastDetails.dart';
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
              Align(
                alignment: Alignment.centerLeft,
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(20,0,0,5),
                  child: Text("Discover",style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold, color: Colors.black87),textAlign: TextAlign.start,),
                ),
              ),
              LineSeparator(height: 6,width: 40),
              Expanded(
                flex: 1,
                  child: Container(
                    width: size.width,
                    //margin: EdgeInsets.fromLTRB(0,10,0,0),
                    child: quoteWidget(),
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

Future<SongAndPodcast> getSongAndPodcast(int id) async {
  var x= await APIService.GetById('SongAndPodcast',id.toString());
  var y=SongAndPodcast.fromJson(x);
  return y;
}
Future<News> getNews(int id) async {
  var x= await APIService.GetById('News',id.toString());
  var y=News.fromJson(x);
  return y;
}
Future<Rating> getRating(int id) async {
  var x= await APIService.GetById('Rating',id.toString());
  var y=Rating.fromJson(x);
  return y;
}

//METHOD GET RANDOM QUOTE
Future<Quote> getQuote() async {
  var quote = await APIService.GetRandom('Quote/GetRandomQuote');
  var x=Quote.fromJson(quote);
  SongAndPodcast sap=await getSongAndPodcast(x.songAndPodcastId as int);
  x.songAndPodcast=sap;
  return x;
}

//METHOD GET TOP 3 NEWS
Future<List<News>> get3News() async {
  var newsList = await APIService.Get('News',null);
  List<News> x=newsList!.map((i) => News.fromJson(i)).toList();
  List<News> top3=[];

  if(x.length>3){
    for(int i =x.length-1;i>0;i--){
      if(top3.length==3)
        return top3;
      else
        top3.add(x[i]);
    }
  }
  else{
    top3=x;
  }

  return top3;
}

//METHOD GET TOP 3 SAP
Future<List<SAP>> get3SaP() async {
  var songAndPodcastList = await APIService.Get('SongAndPodcast',null);
  List<SAP> x=songAndPodcastList!.map((i) => SAP.fromJson(i)).toList();
  print("gg: "+ x[0].ratingValue.toString());

  List<SAP> top3=<SAP>[];

  if(x.length>3){
    for(int i =x.length-1;i>0;i--){
      if(top3.length==3)
        return top3;
      else{
        top3.add(x[i]);
      }
    }
  }
  else{
    top3=x;
  }
  //print("topic: "+ top3[0].toString());
  return top3;

}


//UI
Widget quoteOfTheDay(Quote? x,BuildContext context){
  return Padding(
    padding: const EdgeInsets.fromLTRB(20,10,20,0),
    child: Column(
      children: [
        Align(alignment: Alignment.centerLeft, child: Text('Quote of the day : ', style: TextStyle(fontSize: 16,fontWeight: FontWeight.bold),)),
        SizedBox(height: 8,),
        Text(x!.quoteText.toString(),style: TextStyle(fontSize: 14)),
        TextButton(
        onPressed: () async{
          SongAndPodcast SaP=await getSongAndPodcast(x.songAndPodcastId as int);
          Navigator.push(
            context, MaterialPageRoute(builder: (context) =>
              SongAndPodcastDetails(songAndPodcast: SaP)),
          );
        }
        ,child: Align(alignment: Alignment.centerRight, child: Text(x.songAndPodcast!.title.toString(), style: TextStyle(fontSize: 12,fontWeight: FontWeight.bold,color: PrimaryColor))))
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
      News news=await getNews(e.newsId as int);
        Navigator.push(
          context, MaterialPageRoute(builder: (context) =>
            NewsDetails(news: news)),
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
                      Text(e.firstName !=null && e.lastName!=null?e.firstName! + " "+ e.lastName!:'Unknown performer',textAlign: TextAlign.center,style: TextStyle(fontSize: 8,color: Colors.black87),),
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
          SongAndPodcast SaP=await getSongAndPodcast(e.songAndPodcastId as int);
          Navigator.push(
            context, MaterialPageRoute(builder: (context) =>
              SongAndPodcastDetails(songAndPodcast: SaP)),
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


