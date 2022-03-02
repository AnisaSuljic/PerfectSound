import 'dart:convert';
import 'dart:typed_data';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:perfect_sound_mobile/helper/components.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/Comment/Comment.dart';
import 'package:perfect_sound_mobile/models/Comment/CommentUpsertRequest.dart';
import 'package:perfect_sound_mobile/models/Rating/Rating.dart';
import 'package:perfect_sound_mobile/models/Rating/RatingUpsertRequest.dart';
import 'package:perfect_sound_mobile/models/SAP.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcastPerson.dart';
import 'package:perfect_sound_mobile/pages/Artists/ArtistDetails.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcasts/PodcastMoreDetails.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcasts/SongMoreDetails.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class SongAndPodcastDetails extends StatefulWidget {
  final SAP songAndPodcast;
  const SongAndPodcastDetails({Key? key,required this.songAndPodcast}) : super(key: key);

  @override
  _SongAndPodcastDetailsState createState() => _SongAndPodcastDetailsState();

}

class _SongAndPodcastDetailsState extends State<SongAndPodcastDetails> {
  RatingUpsertRequest requestRating = RatingUpsertRequest();
  CommentUpsertRequest requestComment = CommentUpsertRequest();
  double personalRating = 0.0;
  late double fullRating = this.widget.songAndPodcast.ratingValue as double;

  List<SAP> listSap1=[];

  Future<void> fetchData() async {

    listSap1=await Get_saps();
    }

  @override
  void initState() {
    super.initState();
    fetchData().then((result) {
      setState(() {});
    });
  }

  @override
  Widget build(BuildContext context) {
    TextEditingController CommentController = new TextEditingController();
    Size size = MediaQuery
        .of(context)
        .size;

    return Scaffold(
        appBar: buildAppBar(context),
        body:
        SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              //image and rating
              Container(
                  height: size.height * 0.3,
                  child: Stack(
                    children: [
                      Container(
                        height: size.height * 0.3 - 30,
                        decoration: BoxDecoration(
                            borderRadius: BorderRadius.only(
                                bottomLeft: Radius.circular(50)),
                            image: DecorationImage(
                              fit: BoxFit.cover,
                              image: MemoryImage(this.widget.songAndPodcast
                                  .poster as Uint8List),
                            )
                        ),
                      ),
                      Positioned(
                          bottom: 0,
                          right: 0,
                          child: Container(
                            height: 70,
                            width: size.width * 0.9,
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.only(
                                    bottomLeft: Radius.circular(50),
                                    topLeft: Radius.circular(50)),
                                color: Colors.white,
                                boxShadow: [
                                  BoxShadow(
                                      offset: Offset(0, 5),
                                      blurRadius: 10,
                                      color: Colors.grey.withOpacity(0.9)
                                  )
                                ]
                            ),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                              children: [
                                StarRatingWidget(),
                                FullRateStarWidget(),
                              ],
                            ),
                          )
                      )
                    ],
                  )

              ),
              //title, release date, time and prod company + button "read more"
              Padding(
                padding: EdgeInsets.all(10),
                child: Row(
                  children: [
                    Expanded(
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(this.widget.songAndPodcast.title.toString(),
                              style: TextStyle(fontSize: 22),),
                            SizedBox(height: 10,),
                            Row(
                              children: [
                                Text(dateFormatConverter(
                                    this.widget.songAndPodcast.releaseDate)),
                                SizedBox(width: 10,),
                                Text(this.widget.songAndPodcast.runningTime ==
                                    null ? '' : timeFormat(
                                    this.widget.songAndPodcast.runningTime)),
                                SizedBox(width: 10,),
                                Text(this.widget.songAndPodcast
                                    .productionCompanyName.toString()),

                              ],
                            ),
                          ],
                        )
                    ),
                    SizedBox(
                      height: 64,
                      width: 64,
                      child: TextButton(
                        style: ButtonStyle(
                            backgroundColor: MaterialStateProperty.all(
                                PrimaryColor),
                            shape: MaterialStateProperty.all(
                                RoundedRectangleBorder(
                                    borderRadius: BorderRadius.circular(50)))),
                                onPressed: () async {
                                  if (this.widget.songAndPodcast.isPodcast == false) {
                                    Navigator.push(
                                        context, MaterialPageRoute(builder: (context) =>
                                        SongMoreDetails(songAndPodcast: this.widget
                                            .songAndPodcast)));
                                  }
                                  else {
                                    var seasons = await GetSeasons(
                                        this.widget.songAndPodcast
                                            .songAndPodcastId as int);
                                    Navigator.push(
                                        context, MaterialPageRoute(builder: (context) =>
                                        PodcastMoreDetails(sapID: this.widget.songAndPodcast.songAndPodcastId as int))
                                    );
                                  }
                        },
                        child: Text(
                          "Read more", style: TextStyle(color: Colors.white),
                          textAlign: TextAlign.center,),

                      ),
                    )
                  ],
                ),
              ),
              //genre
              Padding(
                padding: EdgeInsets.symmetric(vertical: 5),
                child: SizedBox(
                  height: 36,
                  child: ListView.builder(
                      scrollDirection: Axis.horizontal,
                      itemCount: this.widget.songAndPodcast.genre!.length,
                      itemBuilder: (context, index) =>
                          GenreCard(
                            genre: this.widget.songAndPodcast.genre![index]
                                .genreName.toString(),
                          )

                  ),
                ),
              ),
              //Artists
              Padding(
                padding: const EdgeInsets.all(10),
                child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text("Artists", style: TextStyle(fontSize: 16),),
                      SizedBox(height: 15,),
                      ArtistsWidget(),
                    ]
                ),
              ),
              //recommended
              Padding(
                  padding: const EdgeInsets.all(10),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text("Recommended songs or podcasts", style: TextStyle(fontSize: 16)),
                    SizedBox(height: 15,),
                    RecommendedHead(listSap1: listSap1)
                  ],
                ),

              ),
              Padding(padding: EdgeInsets.fromLTRB(10, 0, 10, 0),
                child: CommentRow(context, CommentController),
              ),
              Padding(padding: EdgeInsets.fromLTRB(10, 0, 10, 10),
                  child: CommentWidget()
              ),
            ],
          ),
        )
    );
  }

  //Full star rating widget
  Column FullRateStarWidget() {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Icon(Icons.star, color: GoldStar, size: 40,),
        SizedBox(height: 3,),
        RichText(
            text: TextSpan(
                style: TextStyle(color: Colors.black87),
                children: [
                  TextSpan(text: fullRating.toString() + '/5')
                ]
            )
        )
      ],
    );
  }

  //Star rating widget
  Widget StarRatingWidget() {
    return FutureBuilder<List<Rating>>(
      future: GetPersonalRating(),
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
          snapshot.data!.length == 0 ? personalRating = 0 : personalRating =
          snapshot.data!.first.ratingValue!;
          return Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              RatingBar(
                initialRating: personalRating,
                minRating: 1,
                direction: Axis.horizontal,
                allowHalfRating: true,
                itemCount: 5,
                ratingWidget: RatingWidget(
                    full: Icon(Icons.star, color: GoldStar,),
                    half: Icon(Icons.star_half, color: GoldStar,),
                    empty: Icon(Icons.star_border, color: Colors.grey,)
                ),
                onRatingUpdate: (rating) async {
                  requestRating.songAndPodcastId =
                      this.widget.songAndPodcast.songAndPodcastId;
                  requestRating.userId = APIService.usersData!.userId;
                  requestRating.ratingValue = rating;

                  await PostRating(requestRating);
                  var fullrate = await FullRating();

                  setState(() {
                    fullRating = fullrate.ratingValue;
                  });
                },
              ),
              SizedBox(height: 3,),
              Text("Rate this", style: TextStyle(color: Colors.black87),)
            ],
          );
        }
      },
    );
  }

  //Get personal rating
  Future<List<Rating>> GetPersonalRating() async {
    Map<String, String>?queryParams;

    queryParams = {
      'SongAndPodcastId': this.widget.songAndPodcast.songAndPodcastId
          .toString(),
      'UserId': APIService.usersData!.userTypeId.toString()
    };

    var x = await APIService.Get('Rating', queryParams);
    return x!.map((i) => Rating.fromJson(i)).toList();
  }

  //Get full rating
  Future<dynamic> FullRating() async {
    var x = await APIService.GetById(
        "SongAndPodcast", this.widget.songAndPodcast.songAndPodcastId);
    var y = SAP.fromJson(x);
    return y;
  }

  //Rating post
  Future<void> PostRating(RatingUpsertRequest request) async {
    await APIService.Post("Rating", json.encode(request.toJson()));
  }

  //Comment UI
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
                          style: TextStyle(color: PrimaryColor)),
                    ),
                    SizedBox(
                      height: 10,
                    ),
                    Flexible(
                      child: Text(e.content as String,
                          style: TextStyle(color: Colors.black87)),
                    ),
                  ],
                ),
              )
            ],
          ),
        ),
      );
  }

  //Comment widget
  Widget CommentWidget() {
    return FutureBuilder<List<Comment>>(
      future: GetComment(this.widget.songAndPodcast.songAndPodcastId as int),
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
          if (snapshot.data!.isEmpty) {
            return Center(child: Text("No comments yet"));
          }
          else {
            return SizedBox(
              height: 250,
              child: ListView(
                scrollDirection: Axis.vertical,
                shrinkWrap: true,
                children: snapshot.data!.map((e) => CommentList(e)).toList(),
              ),
            );
          }
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
    var x = CommentList!.reversed.toList();
    return x.map((i) => Comment.fromJson(i)).toList();
  }

  Row CommentRow(BuildContext context,
      TextEditingController CommentController) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Container(
          child: Text("Comments:", style: TextStyle(fontSize: 16),),
        ),
        AddCommentBulder(context, CommentController)
      ],
    );
  }

  //lower lvl widget
  TextButton AddCommentBulder(BuildContext context,
      TextEditingController CommentController) {
    return TextButton(
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
                          child: Text(
                            "Cancle", style: TextStyle(color: PrimaryColor),)),
                      TextButton(
                          onPressed: () async {
                            requestComment.songAndPodcastId =this.widget.songAndPodcast.songAndPodcastId;
                            requestComment.userId =APIService.usersData!.userId;
                            requestComment.dateTimeOfComment =DateTime.now();
                            requestComment.content = CommentController.text;

                            await PostComment(requestComment);

                            setState(() {});
                            Navigator.pop(context, true);
                          },
                          child: Text(
                              "Done", style: TextStyle(color: PrimaryColor)))
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
                Icon(Icons.add_circle_outline, color: PrimaryColor,),
                Text("Add comment", style: TextStyle(
                    fontSize: 16, color: PrimaryColor),),
              ],
            )
        )
    );
  }

  //Comment post
  Future<void> PostComment(CommentUpsertRequest request) async {
    print("post: "+ request.content.toString());
    await APIService.Post("Comment", json.encode(request.toJson()));
  }

  //Get artists widget
  Widget ArtistsWidget() {
    return FutureBuilder<List<SongAndPodcastPerson>>(
      future: GetArtists(this.widget.songAndPodcast.songAndPodcastId as int),
      builder: (BuildContext context,
          AsyncSnapshot<List<SongAndPodcastPerson>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          var listArtist = snapshot.data;
          if (listArtist == null || listArtist.length == 0) {
            return Center(child: Text("No known artists"));
          } else {
            return
              SizedBox(
                  height: 110,
                  child: ListView.builder(
                    scrollDirection: Axis.horizontal,
                    itemCount: listArtist.length,
                    itemBuilder: (context, index) =>
                        TextButton(
                            onPressed: () async {
                              var art_=listArtist[index].person;
                              Navigator.push(
                                context, MaterialPageRoute(builder: (context) =>
                                  ArtistDetails(artists: art_!)),
                              );
                            },
                            child: ArtistsHeads(artists: listArtist[index])),
                  )
              );
          }
        }
      },
    );
  }

  //Get artists
  Future<List<SongAndPodcastPerson>> GetArtists(int id) async {
    Map<String, String>?queryParams;
    if (id != 0) {
      queryParams = {'SongAndPodcastId': id.toString()};
    }

    var ArtistsList = await APIService.Get('SongAndPodcastPerson', queryParams);
    var x = ArtistsList!.toList();
    var listArt = x.map((i) => SongAndPodcastPerson.fromJson(i)).toList();

    return listArt;
  }

  //Get artists
  Future<List<SAP>> Get_saps() async {
    int? id=this.widget.songAndPodcast.songAndPodcastId;
    var sapList = await APIService.Get('Recommended/Recommend/${id}', null);
    var x = sapList!.toList();
    var listsp = x.map((i) => SAP.fromJson(i)).toList();

    return listsp;
  }


  Future<List<SAP?>> GetSongAndPodcastPerson(
      int? personId) async {
    Map<String, String>? querryParams;
    if (personId != null) {
      querryParams = {'personId': personId.toString()};
    }
    var SongAndPodcastPersonList =
    await APIService.Get('SongAndPodcastPerson', querryParams);

    List<SAP?> x = SongAndPodcastPersonList!
        .map((i) => SongAndPodcastPerson.fromJson(i).songAndPodcast)
        .toList();
    return x;
  }
}

class RecommendedHead extends StatelessWidget {
  const RecommendedHead({
    Key? key,
    required this.listSap1,
  }) : super(key: key);

  final List<SAP> listSap1;

  @override
  Widget build(BuildContext context) {
    print("head: "+ listSap1.length.toString());
    return SizedBox(
        height: 110,
        child: ListView.builder(
          scrollDirection: Axis.horizontal,
          itemCount: listSap1.length,
          itemBuilder: (context, index) =>
              TextButton(
                  onPressed: () async {
                    var songpod=listSap1[index];
                    Navigator.push(
                      context, MaterialPageRoute(builder: (context) =>
                        SongAndPodcastDetails(songAndPodcast: songpod)),
                    );
                  },
                  child: RecommHeads(sap_: listSap1[index])),
        )
    );
  }
}