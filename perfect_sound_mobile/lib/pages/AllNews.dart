import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/models/News.dart';
import 'package:perfect_sound_mobile/pages/NewsDetails.dart';
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
      body: Column(

        children: [
          filterWidget(),
          Expanded(child: bodyWidget()),
        ],
      ),
    );
  }
  Widget filterWidget(){
    return Padding(
      padding: EdgeInsets.fromLTRB(25, 10, 0, 15),
      child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Column(
            children: [
              Container(
                width: 240,
                  height: 15,
                  child: TextField(
                  controller: titleFilterController,
                  decoration: InputDecoration(
                  hintText:'Title'
                  ),
                  onChanged:(newVel){
                    setState(() {
                      isDateFiltered=false;
                  GetAllNews(titleFilterController.text);
                  });
                  },
                )
              ),
            ],
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
                    date=dateVal!;
                    isDateFiltered=true;
                    GetAllNews(titleFilterController.text);
                  });
                }
                );
              },
              child: Icon(Icons.date_range_outlined,color: Colors.deepPurpleAccent,)
          ),
            TextButton(
              onPressed: (){
                    setState(() {
                      isDateFiltered=false;
                      titleFilterController.text='';
                      GetAllNews(titleFilterController.text);
                    });
              },
                    child:Text("Clear filters",style: TextStyle(fontSize: 12,color:Colors.deepPurpleAccent) )

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
          return ListView(
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


  Widget NewsWidget(news) {
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
                        image: MemoryImage(news.coverPhoto as Uint8List)
                    ),
                  ),
                  Flexible(
                    child:Text(news.title,style: TextStyle(color: Colors.black87)),
                  )
                ],
              ),
        )
        ),
    );
  }

}
