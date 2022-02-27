import 'dart:convert';

import 'Genre.dart';

class SAP {
  int? songAndPodcastId;
  String? title;
  String? text;
  String? runningTime;
  DateTime? releaseDate;
  double? budget;
  List<int>? poster;
  late int numberOfRatings;
  int? productionCompanyId;
  bool? isPodcast;
  double? ratingValue;
  String? firstName;
  String? lastName;
  List<Genre>? genre;
  String? productionCompanyName;


  SAP(
      {this.songAndPodcastId,
        this.title,
        this.text,
        this.runningTime,
        this.releaseDate,
        this.budget,
        this.poster,
        required this.numberOfRatings,
        this.productionCompanyId,
        this.isPodcast,
        this.ratingValue,
        this.firstName,
        this.lastName,
        this.genre,
        this.productionCompanyName});

  SAP.fromJson(Map<String, dynamic> json) {

    String PhotoStringByte=json["poster"]as String;
    List<int>PhotoIntByte=base64.decode(PhotoStringByte);

    var genreList = <Genre>[];
    if (json['genre'] != null) {
      json['genre'].forEach((v) {
        genreList.add(new Genre.fromJson(v));
      });
    }

    songAndPodcastId = json['songAndPodcastId'];
    title = json['title'];
    text = json['text'];
    runningTime = json['runningTime'];
    releaseDate = DateTime.parse(json['releaseDate']);
    budget = json['budget'];
    poster = PhotoIntByte;
    numberOfRatings = json['numberOfRatings'];
    productionCompanyId = json['productionCompanyId'];
    isPodcast = json['isPodcast'];
    if(json['ratingValue'].runtimeType==int){
      int value=json['ratingValue'];
      ratingValue=value.toDouble();
    }
    else
      ratingValue = json['ratingValue'];
    if(json['ratingValue']==null)
      ratingValue=0.0;
    firstName = json['firstName'];
    lastName = json['lastName'];
    genre = genreList;
    productionCompanyName = json['productionCompanyName'];

  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['title'] = this.title;
    data['text'] = this.text;
    data['runningTime'] = this.runningTime;
    data['releaseDate'] = this.releaseDate;
    data['budget'] = this.budget;
    data['poster'] = this.poster;
    data['numberOfRatings'] = this.numberOfRatings;
    data['productionCompanyId'] = this.productionCompanyId;
    data['isPodcast'] = this.isPodcast;
    data['ratingValue'] = this.ratingValue;
    data['firstName'] = this.firstName;
    data['lastName'] = this.lastName;
    if (this.genre != null) {
      data['genre'] = this.genre!.map((v) => v.toJson()).toList();
    }
    data['productionCompanyName'] = this.productionCompanyName;

    return data;
  }
}
