import 'dart:typed_data';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/News.dart';
import 'package:perfect_sound_mobile/pages/News/NewsDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';


class AllNews extends StatefulWidget {
  const AllNews({Key? key}) : super(key: key);

  @override
  _AllNewsState createState() => _AllNewsState();
}

class _AllNewsState extends State<AllNews> {
  TextEditingController titleFilterController=new TextEditingController();
  TextEditingController titleDateController=new TextEditingController();
  DateTime date=new DateTime(0001,1,1,0,0,0,0,0);
  bool isDateFiltered=false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: buildAppBar(context),
    drawer: buildDrawer(context),
      body: SingleChildScrollView(
        child: Column(
          children: [
            PageTitle(title: "News"),
            LineSeparator(height: 6,width: 40),
            filterWidget(),
            bodyWidget(),
          ],
        ),
      ),
    );
  }
  Widget filterWidget(){
    return Padding(
      padding: EdgeInsets.fromLTRB(5, 15, 0, 0),
      child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Container(
              width: 200,
              height: 15,
              child: TextField(
                controller: titleFilterController,
                decoration: InputDecoration(
                    hintText:'Title',
                    focusedBorder: UnderlineInputBorder(borderSide: BorderSide(color: PrimaryColor))
                ),
                onChanged:(newVel){
                  setState(() {
                    GetAllNews(titleFilterController.text);
                  });
                },
              )
          ),
          TextButton(
              onPressed:() {
                showDatePicker(
                    context: context,
                    initialDate: DateTime.now(),
                    firstDate: DateTime(1940),
                    lastDate: DateTime(3000)
                ).then((dateVal){
                    setState(() {
                      if(dateVal!=null){
                        date=dateVal;
                        isDateFiltered=true;
                        GetAllNews(titleFilterController.text);
                      }
                      else{
                        date=date;
                        isDateFiltered=false;
                      }
                    });
                  }
                );
              },
              child: Column(
                children: [
                  Icon(Icons.date_range_outlined,color: PrimaryColor,),
                  Text(isDateFiltered!=false?dateFormatConverter(date):'No date filter',
                    style: TextStyle(fontSize: 10,color: PrimaryColor),)
                ],
              )
          ),
            TextButton(
              onPressed: (){
                    setState(() {
                      isDateFiltered=false;
                      titleFilterController.text='';
                      GetAllNews(titleFilterController.text);
                    });
              },
                child:Text("Clear filters",style: TextStyle(fontSize: 12,color:Colors.black87) )
            ),
        ],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<News>>(
      future: GetAllNews(titleFilterController.text),
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
          if(snapshot.data!.length==0)
            return Text("No news yet");
          return ListView(
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!.map((e) => NewsWidget(e)).toList(),
          );
        }
      },
    );
  }

  Future<List<News>> GetAllNews(String titleFilter) async {
    Map<String,String>?queryParams;
    if(titleFilter!=''){
      queryParams={'Title':titleFilter.toString()};
    }
    if(isDateFiltered==true){
      queryParams={'PublicationDate':date.toIso8601String()};
    }
    var newsList = await APIService.Get('News',queryParams);
    return newsList!.map((i) => News.fromJson(i)).toList();
  }

  Widget NewsWidget(News news) {
    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.push(
              context, MaterialPageRoute(builder: (context) => NewsDetails(news: news,)),
          );
        },
        child:  Container(
              height: 100,
          child: Row(
                children: [
                  Padding(
                    padding: const EdgeInsets.all(10.0),
                    child: Image(
                        width:80,
                        height: 80,
                        image: MemoryImage(news.coverPhoto as Uint8List)
                    ),
                  ),
                  Flexible(
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Text(news.title.toString(),style: TextStyle(color: Colors.black87)),
                        Align(
                            alignment: Alignment.bottomRight,
                            child: Text(dateFormatConverter(news.publicationDate),style: TextStyle(color: Colors.black87),)),

                      ],
                    ),
                  )

                ],
              ),
         )
        ),
    );
  }
}
