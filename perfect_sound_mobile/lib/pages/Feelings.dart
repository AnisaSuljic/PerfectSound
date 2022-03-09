
import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'SongAndPodcasts/SongAndPodcastDetails.dart';

class Feelings extends StatefulWidget {
  const Feelings({Key? key}) : super(key: key);

  @override
  State<Feelings> createState() => _FeelingsState();
}

enum feelingList {
  Happy,
  Sad,
  Calm,
  Energetic,
  Depression
}

class _FeelingsState extends State<Feelings> {

  final _formKey=GlobalKey<FormState>();
  List<SAP> searchResponse=[];

  List<Artists> _artList =[];
  List<int> _yearList =[];
  var _feelList =[];

  int? art_id;
  var artistsValueChoose;
  var feelValueChoose;
  var yearValueChoose;


  Future<void> fetchData() async {
    _artList=await GetArtists();
    _yearList=await GetAllYears();
    _feelList=feelingList.values;
  }

  @override
  void initState() {
    super.initState();
    fetchData()
        .then((result) {
          setState(() {
            bodyWidget();
          });
    });
  }

  @override
  Widget build(BuildContext context) {

    return Scaffold(
      appBar: buildAppBar(context),
      drawer: buildDrawer(context),
      body:
          SingleChildScrollView(
            child: Column(
              children: [
                PageTitle(title: "Feelings"),
                LineSeparator(height: 6,width: 40),
                SizedBox(height: 15),
                bodyWidget(),
                listWidget()
              ],
            ),
          )
    );
  }

  Widget bodyWidget() {
    Size size = MediaQuery.of(context).size; //total height&width of screen

    return
      Column(
      children: [
        Padding(
          padding: EdgeInsets.fromLTRB(0, 5, 0, 10),
          child: Container(
            alignment: Alignment.center,
              height: 30,
              child: Text("Find song or podcast for you",style: TextStyle(fontSize: 16))
          ),
        ),
        Form(
          key: _formKey,
          child: SingleChildScrollView(
            child: Padding(
              padding: const EdgeInsets.only(left: 20,right: 20),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    child: DropdownButton(
                        hint: Text("How do you feel"),
                        value: feelValueChoose,
                        isExpanded: true,
                        dropdownColor: PrimaryColor,
                        icon: Icon(Icons.arrow_drop_down),
                        iconSize: 36,
                        onChanged: (value)=>setState(()
                        {
                          _feelList.forEach((element) {
                            if(element.index==value)
                              feelValueChoose=element.index;
                          });
                        }),
                        items:_feelList.map((val) => DropdownMenuItem(
                          value: val.index,
                          child: Text(val.toString().split('.').last),
                          enabled: true,
                        )
                        ).toList()

                    ),
                  ),
                  Container(
                    child: DropdownButton(
                        hint: Text("Artist"),
                        value: artistsValueChoose,
                        isExpanded: true,
                        dropdownColor: PrimaryColor,
                        icon: Icon(Icons.arrow_drop_down),
                        iconSize: 36,
                        onChanged: (value)=>setState(()
                        {
                          var valuex=value as Artists;
                          _artList.forEach((element) {
                            if(element.personId==value.personId)
                              artistsValueChoose=element;
                          });
                        }),
                        items:_artList.map((val) => DropdownMenuItem(
                              value: val,
                              child: Text(nameFormat(val.firstName, val.lastName)),
                              enabled: true,
                            )
                          ).toList()
                    ),
                  ),
                  Container(
                    child: DropdownButton(
                        hint: Text("Release year"),
                        value: yearValueChoose,
                        isExpanded: true,
                        dropdownColor: PrimaryColor,
                        icon: Icon(Icons.arrow_drop_down),
                        iconSize: 36,
                        onChanged: (value)=>setState(()
                        {
                          var valuex=value as int;
                          _yearList.forEach((element) {
                            if(element==value)
                              yearValueChoose=element;
                          });
                        }),
                        items:_yearList.map((val) => DropdownMenuItem(
                          value: val,
                          child: Text(val.toString()),
                          enabled: true,
                        )
                        ).toList()
                    ),
                  ),
                  Align(
                    alignment: Alignment.centerRight,
                    child: TextButton(onPressed: (){
                      setState(() {
                        feelValueChoose=null;
                        artistsValueChoose=null;
                        yearValueChoose=null;
                      });
                    }, child: Text("Reset filters",style: TextStyle(color: PrimaryColor),)),
                  ),

                  SizedBox(height: 15,),
                ],
              ),
            ),
          ),
        ),
      ],
    );
  }

  Widget listWidget() {
    return FutureBuilder<List<SAP>>(
      future: GetAll(),
      builder: (BuildContext context, AsyncSnapshot<List<SAP>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: CircularProgressIndicator(color: PrimaryColor,),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          if(snapshot.data!.length==0)
            return Text("No matches");
          return ListView(
            physics: ClampingScrollPhysics(),
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!.map((e) => SAPList(e)).toList(),
          );
        }
      },
    );
  }

  Widget SAPList(SAP e) {
    return
      Card(
        child: Container(
          height: 80,
          decoration: BoxDecoration(
              image: DecorationImage(
                image: MemoryImage(e.poster as Uint8List),
                fit: BoxFit.cover,
                alignment: Alignment.center,
              )
          ),
          child: TextButton(
            onPressed: () {
              Navigator.push(
                context, MaterialPageRoute(builder: (context) =>
                  SongAndPodcastDetails(songAndPodcast: e)),
              );
            },
            child: Column(
              children: [
                Flexible(
                  child: Text(e.title.toString(), style: TextStyle(color: Colors.black,
                      fontSize: 18, fontWeight: FontWeight.bold,
                      backgroundColor: Colors.white.withOpacity(0.8))),
                ),
                SizedBox(
                  height: 10,
                ),
                Flexible(
                  child: Text(nameFormat(e.firstName,e.lastName), style: TextStyle(color: Colors.black,
                      backgroundColor: Colors.white.withOpacity(0.8))),
                ),
              ],
            ),
          ),
        ),
      );
  }

  Future<void> showDialogWidget(String text, BuildContext context) async {
    return showDialog<void>(
        context: context,
        builder: (BuildContext context) =>
            AlertDialog(
              contentPadding: EdgeInsets.fromLTRB(20, 40, 20, 0),
              content:Text(text,textAlign: TextAlign.center),
              actions: <Widget> [
                TextButton(
                    style: ButtonStyle(
                      backgroundColor: MaterialStateProperty.all(PrimaryColor),
                    ),
                    onPressed: () {
                      Navigator.pop(context, false);
                    },
                    child: Text("OK", style: TextStyle(color: Colors.white),)
                )
              ],
            )
    );
  }


  Future<List<SAP>> GetAll() async {
    Map<String,String>?queryParams;
      queryParams={'feelingId':feelValueChoose==null?'0':feelValueChoose.toString(),
        'artistId':artistsValueChoose==null?'0':artistsValueChoose.personId.toString(),
        'year':yearValueChoose==null?'0':yearValueChoose.toString()};
    var x= await APIService.Get('SongAndPodcast',queryParams);
    searchResponse=x!.map((i) => SAP.fromJson(i)).toList();
    return searchResponse;
  }
}
Future<List<Artists>> GetArtists() async {
  var x= await APIService.Get('Person',null);
  var y= x!.map((e) => Artists.fromJson(e)).toList();
  return y;
}

Future<List<int>> GetAllYears() async {
  var SaPList = await APIService.Get('SongAndPodcast', null);
    var x= SaPList!.map((i) => SAP.fromJson(i).releaseDate!.year).toList();
    x=x.toSet().toList();
    return x;
}
