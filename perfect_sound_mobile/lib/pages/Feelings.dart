
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

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
  int? art_id;
  var artistsValueChoose;
  var feelValueChoose;
  var yearValueChoose;


  Future<void> fetchData() async {
    _artList=await GetArtists();
    _yearList=await GetAllYears();
  }

  @override
  void initState() {
    fetchData();
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
                          feelingList.values.forEach((element) {
                            if(element.index==value)
                              feelValueChoose=element.index;
                          });
                        }),
                        items:feelingList.values.map((val) => DropdownMenuItem(
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
                  Container(
                    width: size.width*0.3,
                    margin: EdgeInsets.symmetric(vertical: 5),
                    child: ClipRRect(
                      borderRadius: BorderRadius.circular(30),
                      child: ElevatedButton(
                        style: ButtonStyle(backgroundColor: MaterialStateProperty.all(PrimaryColor), padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 15, horizontal: 40))),
                        onPressed: () async {
                          if(_formKey.currentState!.validate()){
                            //searchResponse=null;

                            GetAll();

                            if(searchResponse.isEmpty)
                              showDialogWidget("An error has occurred, please try again.",context);
                          }
                        }, child: const Text('Find'),
                      ),
                    ),
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
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          if(snapshot.data!.length==0)
            return Text("No matches");
          return ListView(
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
          child: Padding(
            padding: const EdgeInsets.all(10.0),
            child: Column(
              children: [
                Flexible(
                  child: Text(e.title.toString(),
                      style: TextStyle(color: PrimaryColor,)),
                ),
                SizedBox(
                  height: 10,
                ),
                Flexible(
                  child: Text(nameFormat(e.firstName, e.lastName),
                      style: TextStyle(color: Colors.black87)),
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
    print("xx: "+x.toString());
    return x;
}
