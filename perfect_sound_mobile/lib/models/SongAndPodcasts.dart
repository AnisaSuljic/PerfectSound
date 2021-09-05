import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';


class SongAndPodcast{
  final songAndPodcastId;
  final String? title;
  final String? text;
  final String? runningTime;
  final DateTime? releaseDate;
  final double? budget;
  final List<int>? poster;
  final bool? isPodcast;
  final List<Genre>? genre;

  SongAndPodcast({this.songAndPodcastId,this.title,this.text,this.runningTime,
    this.releaseDate,this.budget,this.poster,this.isPodcast,this.genre
  });


  factory SongAndPodcast.fromJson(Map<String,dynamic>json){
    String PhotoStringByte=json["poster"]as String;
    List<int>PhotoIntByte=base64.decode(PhotoStringByte);


    var genreList = <Genre>[];
    if (json['genre'] != null) {
      json['genre'].forEach((v) {
        genreList.add(new Genre.fromJson(v));
      });
    }


    return SongAndPodcast(
        songAndPodcastId: ["songAndPodcastId"],
        title: json["title"],
        text: json["text"],
        runningTime: json["runningTime"],
        releaseDate: DateTime.parse(json['releaseDate']),
        budget: json["budget"],
        poster: PhotoIntByte,
        isPodcast: (json['isPodcast']),
        genre: genreList
    );
  }

  Map<String,dynamic>toJson()=>{
    "songAndPodcastId": songAndPodcastId,
    "title": title,
    "text": text,
    "runningTime": runningTime,
    "releaseDate": releaseDate!.toIso8601String(),
    "budget": budget,
    "poster": poster,
    "isPodcast": isPodcast,

  };


}

class Genre {
  int? genreId;
  String? genreName;

  Genre({this.genreId, this.genreName});

  Genre.fromJson(Map<String, dynamic> json) {
    genreId = json['genreId'];
    genreName = json['genreName'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['genreId'] = this.genreId;
    data['genreName'] = this.genreName;
    return data;
  }
}