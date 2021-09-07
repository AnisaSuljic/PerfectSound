import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'Home.dart';

class Feelings extends StatelessWidget {
  const Feelings({Key? key}) : super(key: key);

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
      body: Padding(
        padding: const EdgeInsets.all(10.0),
        child: bodyWidget1(),
      ),
    );
  }

  Widget bodyWidget1() {
    return Column(
      children: [
        Padding(
          padding: EdgeInsets.fromLTRB(0, 5, 0, 30),
          child: Container(
            alignment: Alignment.center,
              height: 30,
              child: Text("Pronađite pjesmu za sebe ",style: TextStyle(fontSize: 16))
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Container(
              height: 170,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Container(
                      width: 300,
                      height: 20,
                      child: TextField(
                        //controller: titleFilterController,
                        decoration: InputDecoration(
                            hintText:'Kako se osjećate?'
                        ),
                        onChanged:(newVel){
                          // setState(() {
                          //   isDateFiltered=false;
                          //   var titleFilter=titleFilterController.text;
                          //   GetAllNews(titleFilterController.text);
                          // });
                        },
                      )
                  ),
                  Container(
                      width: 300,
                      height: 20,
                      child: TextField(
                        //controller: titleFilterController,
                        decoration: InputDecoration(
                            hintText:'Žanr'
                        ),
                        onChanged:(newVel){
                          // setState(() {
                          //   isDateFiltered=false;
                          //   var titleFilter=titleFilterController.text;
                          //   GetAllNews(titleFilterController.text);
                          // });
                        },
                      )
                  ),
                  Container(
                      width: 300,
                      height: 20,
                      child: TextField(
                        //controller: titleFilterController,
                        decoration: InputDecoration(
                            hintText:'Ocjene'
                        ),
                        onChanged:(newVel){
                          // setState(() {
                          //   isDateFiltered=false;
                          //   var titleFilter=titleFilterController.text;
                          //   GetAllNews(titleFilterController.text);
                          // });
                        },
                      )
                  ),
                  Container(
                      width: 300,
                      height: 20,
                      child: TextField(
                        //controller: titleFilterController,
                        decoration: InputDecoration(
                            hintText:'Izvođač'
                        ),
                        onChanged:(newVel){
                          // setState(() {
                          //   isDateFiltered=false;
                          //   var titleFilter=titleFilterController.text;
                          //   GetAllNews(titleFilterController.text);
                          // });
                        },
                      )
                  ),
                  Container(
                      width: 300,
                      height: 20,
                      child: TextField(
                        //controller: titleFilterController,
                        decoration: InputDecoration(
                            hintText:'Godina premijere'
                        ),
                        onChanged:(newVel){
                          // setState(() {
                          //   isDateFiltered=false;
                          //   var titleFilter=titleFilterController.text;
                          //   GetAllNews(titleFilterController.text);
                          // });
                        },
                      )
                  ),
                ],
              ),
            ),
          ],
        ),

      ],
    );
  }
}