import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:perfect_sound_mobile/pages/AllNews.dart';
import 'package:perfect_sound_mobile/pages/AllSongsAndPodcasts.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();
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
          child: Text(APIService.username as String,style: TextStyle(fontSize: 16),),
        ),
        ],
        backgroundColor: Colors.deepPurpleAccent,
      ),
      drawer: Drawer(
        child: ListView(
          children: [
            Container(
              height: 80,
              child: DrawerHeader(
                child: Center(
                    child: Text('PerfectSound',style: TextStyle(color: Colors.white,fontSize: 16),)
                ),
                decoration: BoxDecoration(
                  color: Colors.deepPurpleAccent
                ),
              ),
            ),
            Card(
              child: ListTile(
                title: Text('News',style: TextStyle(fontSize: 16),),
                onTap: (){
                  //Navigator.of(context).pushReplacementNamed('/allnews');
                  Navigator.push(
                      context, MaterialPageRoute(builder: (context) => AllNews()));
                },
              ),
            ),
            Card(
              child: ListTile(
                title: Text('Songs',style: TextStyle(fontSize: 16),),
                onTap: (){
                  Navigator.push(
                      context, MaterialPageRoute(builder: (context) => AllSongsAndPodcasts()));
                },
              ),
            )
          ],
        ),
      ),
    );
  }
}
