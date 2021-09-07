import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/Artists.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class ArtistDetails extends StatelessWidget {
  final Artists artists;
  const ArtistDetails({Key? key, required this.artists}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          backgroundColor: Colors.deepPurpleAccent,
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
          title: Text('Details'),
        ),
        body: bodyWidget()
    );
  }

  Widget bodyWidget() {
    return Column(children: [
      Container(
        height: 100,
        decoration: BoxDecoration(
            border: Border(bottom: BorderSide(color: Colors.grey, width: 1.2))),
        child: Row(
          children: [
            Expanded(
              flex: 40,
              child: Container(
                alignment: Alignment.center,
                child: Image(
                    width: 80,
                    height: 80,
                    image: MemoryImage(artists.photo as Uint8List)),
              ),
            ),
            Expanded(
                flex: 60,
                child: Container(
                    alignment: Alignment.center,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Text(
                          artists.firstName.toString() +
                              ' ' +
                              artists.lastName.toString(),
                          style: TextStyle(fontSize: 20),
                        ),
                        Text(
                          artists.dateOfBirth!.day.toString() +
                              "." +
                              artists.dateOfBirth!.month.toString() +
                              "." +
                              artists.dateOfBirth!.year.toString() +
                              '   - ' +
                              DeathCheck(artists.dateOfDeath),
                          style: TextStyle(
                              fontSize: 16,
                              backgroundColor: Colors.grey.withOpacity(0.5),
                              color: Colors.black),
                        )
                      ],
                    )
                )
            )
          ],
        ),
      ),

      Container(
        decoration: BoxDecoration(
            border: Border(bottom: BorderSide(color: Colors.grey, width: 1.2))),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text('Spol : '+artists.gender!.genderName.toString(),style: TextStyle(fontSize: 16,color: Colors.black),),
                  Text('Mjesto rođenja : '+artists.placeOfBirth.toString(),style: TextStyle(fontSize: 16,color: Colors.black),),
                ],
              ),
            ),
          ],
        ),
      ),

      Container(
      child:Column(
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Padding(
                padding: EdgeInsets.fromLTRB(0, 10, 0, 10),
                child: Text('Biografija',style: TextStyle(fontSize: 16,color: Colors.black)),
              ),
          ],
          ),
          Container(
            child:
              Text(artists.biography.toString(),style: TextStyle(fontSize: 16,color: Colors.black))
          )
        ],
      )


      )
    ]);
  }
}

String DeathCheck(dateOfDeath) {
  return dateOfDeath != null
      ? dateOfDeath.day.toString() +
          '.' +
          dateOfDeath.month.toString() +
          '.' +
          dateOfDeath.year.toString()
      : '  /  ';
}
