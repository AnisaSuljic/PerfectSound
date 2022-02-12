import 'dart:convert';
import 'dart:typed_data';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/models/Comment/Comment.dart';
import 'package:perfect_sound_mobile/models/Comment/CommentUpsertRequest.dart';
import 'package:perfect_sound_mobile/models/Rating/Rating.dart';
import 'package:perfect_sound_mobile/models/Rating/RatingUpsertRequest.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class SongAndPodcastDetails extends StatefulWidget {
  final SongAndPodcast songAndPodcast;
  const SongAndPodcastDetails({Key? key,required this.songAndPodcast}) : super(key: key);

  get actions => null;

  @override
  _SongAndPodcastDetailsState createState() => _SongAndPodcastDetailsState();

}

class _SongAndPodcastDetailsState extends State<SongAndPodcastDetails> {
  RatingUpsertRequest requestRating=RatingUpsertRequest();
  CommentUpsertRequest requestComment = CommentUpsertRequest();
  double personalRating = 0;

  @override
  Widget build(BuildContext context) {
    TextEditingController CommentController = new TextEditingController();

    return Scaffold(
        appBar: buildAppBar(context),
        body:
        SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.all(10.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                bodyWidget(),
                SizedBox(
                  height: 10,
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Container(
                      child: Text("Comments:", style: TextStyle(fontSize: 16),),

                    ),
                    TextButton(
                        onPressed: () {
                          showDialog(
                              context: context,
                              builder: (_) =>
                                  AlertDialog(
                                    title: Text("Your comment: "),
                                    content: TextField(
                                        decoration: InputDecoration(
                                          border: OutlineInputBorder(),
                                          hintText: 'Enter a comment',
                                        ),
                                        onChanged: (newVel) {
                                          CommentController.text = newVel;
                                        }
                                    ),
                                    actions: [
                                      TextButton(
                                          onPressed: () {

                                            Navigator.pop(context, false);
                                          },
                                          child: Text("Cancle")),
                                      TextButton(
                                          onPressed: () {
                                            requestComment.songAndPodcastId =
                                                this.widget.songAndPodcast.songAndPodcastId;
                                            requestComment.userId =
                                                APIService.userID;
                                            requestComment.dateTimeOfComment =
                                                DateFormat(
                                                    'yyyy-MM-ddTkk:mm:ss')
                                                    .format(DateTime.now());
                                            requestComment.content =
                                                CommentController.text;

                                            PostComment(requestComment);

                                            setState(() {});
                                            Navigator.pop(context, true);
                                          },
                                          child: Text("Done"))
                                    ],
                                  ),
                              barrierDismissible: false
                          ).then((exit) =>
                          {
                            if(exit){
                            }
                          });
                        },
                        child:
                        Container(
                            child: Row(
                              children: [
                                Icon(Icons.add_circle_outline),
                                Text("Add comment", style: TextStyle(
                                    fontSize: 16),),

                              ],
                            )
                        )
                    )
                  ],
                ),
                CommentWidget(),

              ],
            ),
          ),
        )
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Rating>>(
      future: GetRating(this.widget.songAndPodcast.songAndPodcastId),
      builder: (BuildContext context, AsyncSnapshot<List<Rating>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          //snapshot.data!.map((e) => RatingList(e)).toList(),
          double fullRating = 0;
          int counter=0;
          snapshot.data!.forEach((element) {fullRating+=element.ratingValue!;counter++;});
          fullRating=fullRating/counter;

          var personalRatingGetList=snapshot.data!.where((element) => element.userId==APIService.userID).toList();
          if(personalRatingGetList.length==0)
            personalRating=0;
          else
            personalRating=snapshot.data!.where((element) => element.userId==APIService.userID).first.ratingValue!;

    return Column(
      children: [
        Container(
          height: 100,
          decoration: BoxDecoration(border: Border(
              bottom: BorderSide(color: Colors.grey, width: 1.2))),
          child: Row(
            children: [
              Expanded(
                flex: 40,
                child: Container(
                  alignment: Alignment.center,
                  child: Image(
                      width: 80,
                      height: 80,
                      image: MemoryImage(this.widget.songAndPodcast.poster as Uint8List)
                  ),
                ),
              ),
              Expanded(
                  flex: 60,
                  child:
                  Container(
                      alignment: Alignment.center,
                      child: Text(this.widget.songAndPodcast.title.toString(),
                        style: TextStyle(fontSize: 20),)
                  )
              )
            ],
          ),
        ),
        Container(
          height: 80,
          //decoration: BoxDecoration(color: Colors.pinkAccent),
          //child: Padding(
          //padding: EdgeInsets.fromLTRB(15, 0, 15, 0),
          child: Column(
            children: [
              Container(
                height: 40,
                alignment: Alignment.center,
                //decoration: BoxDecoration(color: Colors.blueAccent),
                child: Row(
                  children: [
                    Text(this.widget.songAndPodcast.releaseDate!.day.toString() + "." +
                        this.widget.songAndPodcast.releaseDate!.month.toString() + "." +
                        this.widget.songAndPodcast.releaseDate!.year.toString()
                      , style: TextStyle(fontSize: 16,
                          backgroundColor: Colors.grey.withOpacity(0.5),
                          color: Colors.black),)
                  ],
                ),
              ),
              Container(
                height: 40,
                alignment: Alignment.bottomCenter,
                //decoration: BoxDecoration(color: Colors.deepOrange),
                child: Row(
                  children: [
                    Expanded(
                      flex: 60,
                      child: Text("Rate", style: TextStyle(fontSize: 16)),
                    ),
                  RatingBar(
                    initialRating: personalRating,
                    minRating: 1,
                    direction: Axis.horizontal,
                    allowHalfRating: true,
                    itemCount: 5,
                    ratingWidget: RatingWidget(
                      full: Icon(Icons.star),
                      half: Icon(Icons.star_half),
                      empty: Icon(Icons.star_border)
                    ),
                    itemPadding: EdgeInsets.symmetric(horizontal: 2.0),
                    onRatingUpdate: (rating) {
                      requestRating.songAndPodcastId=this.widget.songAndPodcast.songAndPodcastId;
                      requestRating.userId=APIService.userID;
                      requestRating.ratingValue=rating;

                      PostRating(requestRating);

                      setState(() {});
                    },
                  ),
                    Expanded(
                        flex: 40,
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.spaceAround,
                          children: [
                            Text(fullRating.toString(), style: TextStyle(fontSize: 16,
                                backgroundColor: Colors.grey.withOpacity(0.5),
                                color: Colors.black),),
                            Text('Rating', style: TextStyle(fontSize: 12,
                                color: Colors.black))
                          ],
                        )
                    )
                  ],
                ),
              )
            ],
          ),
          //),
        ),
        SizedBox(
          height: 10,
        ),
        Container(
            height: 60,
            decoration: BoxDecoration(color: Colors.deepPurpleAccent),
            child:
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Column(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text("Genre:", style: TextStyle(fontSize: 16)),
                      for(var i = 0; i <
                          this.widget.songAndPodcast.genre!.length; i++) Text(' | ' +
                          this.widget.songAndPodcast.genre![i].genreName.toString() + ' | ',
                          style: TextStyle(fontSize: 14, color: Colors.black))
                    ],
                  )
                ],
              ),
            )
        ),

        Container(
            height: 80,
            decoration: BoxDecoration(border: Border(
                bottom: BorderSide(color: Colors.grey, width: 1.2))),
            child: Column(
                children: [
                  Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children:
                      [
                        Padding(
                          padding: EdgeInsets.fromLTRB(0, 10, 0, 10),
                          child: Text(
                              "Artists: ", style: TextStyle(fontSize: 16)),
                        ),
                      ]
                  ),
                  Row(
                    children: [
                      Container(
                        //decoration: BoxDecoration(color: Colors.blue),
                        child: Row(
                          children: [
                            Padding(
                              padding: EdgeInsets.fromLTRB(5, 0, 5, 0),
                              child: Image(
                                  width: 30,
                                  height: 30,
                                  image: MemoryImage(this.widget.songAndPodcast
                                      .poster as Uint8List)
                              ),
                            ),
                          ],
                        ),
                      )
                    ],
                  )
                ]
            )
        ),
      ],
    );
        }
      },
    );
  }

  Widget CommentWidget() {
    return FutureBuilder<List<Comment>>(
      future: GetComment(this.widget.songAndPodcast.songAndPodcastId),
      builder: (BuildContext context, AsyncSnapshot<List<Comment>> snapshot) {
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
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!.map((e) => CommentList(e)).toList(),
          );
        }
      },
    );
  }

  //Get comments

  Future<List<Comment>> GetComment(int id) async {
    Map<String, String>?queryParams;
    if (id != 0) {
      queryParams = {'SongAndPodcastId': id.toString()};
    }

    var CommentList = await APIService.Get('Comment', queryParams);
    var x=CommentList!.reversed.toList();
    return x.map((i) => Comment.fromJson(i)).toList();
  }

  //Get ratings

  Future<List<Rating>> GetRating(int SAPId) async {
    Map<String, String>?queryParams;
    if (SAPId != 0) {
      queryParams = {'SongAndPodcastId':SAPId.toString()};
    }

    var RatingList = await APIService.Get('Rating', queryParams);
    var x=RatingList!.toList();
    return x.map((i) => Rating.fromJson(i)).toList();
  }

  //Comment post

  Future<void> PostComment(CommentUpsertRequest request) async {
    await APIService.Post("Comment", json.encode(request.toJson()));
  }

  //Rating post

  Future<void> PostRating(RatingUpsertRequest request) async {
    await APIService.Post("Rating", json.encode(request.toJson()));
  }

  //End comment post

  Widget CommentList(Comment e) {
    return
      Card(
        child: Container(
          height: 80,
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Padding(
                padding: const EdgeInsets.all(10.0),
                child: Column(
                  children: [
                    Flexible(
                      child: Text("By : " + e.user!.userName.toString(),
                          style: TextStyle(color: Colors.black)),
                    ),
                    SizedBox(
                      height: 10,
                    ),
                    Flexible(
                      child: Text(e.content as String,
                          style: TextStyle(color: Colors.deepPurpleAccent)),
                    ),
                  ],
                ),
              )
            ],
          ),
        ),
      );
  }

}