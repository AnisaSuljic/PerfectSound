import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/News.dart';

class NewsDetails extends StatelessWidget {

  final News news;
  NewsDetails({Key? key,required this.news}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: buildAppBar(context),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          children: [
            Image(
                width:150,
                height: 150,
                image: MemoryImage(news.coverPhoto as Uint8List)
            ),
            Padding(
              padding: const EdgeInsets.all(20.0),
              child: Text(news.title as String,style: TextStyle(fontSize: 20)),
            ),
            Padding(
              padding: EdgeInsets.fromLTRB(0, 0, 0, 20),
              child: Text(news.subTitle as String,style: TextStyle(fontSize: 16)),
            ),
            Text(news.content as String,style: TextStyle(fontSize: 16)),
            Padding(
              padding: const EdgeInsets.all(25.0),
              child: Align(
                alignment: Alignment.centerRight,
                  child: Text((news.publicationDate?.day).toString()+'.'+(news.publicationDate?.month).toString()+'.'+(news.publicationDate?.year).toString(),style: TextStyle(fontSize: 14),)),
            )
          ],
        ),
      )

    );
  }
}
