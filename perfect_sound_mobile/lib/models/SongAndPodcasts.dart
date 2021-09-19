import 'dart:convert';
import 'package:perfect_sound_mobile/models/PodcastSeason.dart';
import 'package:perfect_sound_mobile/models/ProductionCompany.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcastGenre.dart';

import 'Genre.dart';
import 'SongAndPodcastPerson.dart';


class SongAndPodcast{
  final songAndPodcastId;
  final String? title;
  final String? text;
  final String? runningTime;
  final DateTime? releaseDate;
  final double? budget;
  final List<int>? poster;
  final int? numberOfRatings;
  final int? productionCompanyId;
  final ProductionCompany? productionCompany;
  final List<SongAndPodcastGenre?> songAndPodcastGenre;
  final bool? isPodcast;
  final List<Genre>? genre;
  final List<PodcastSeason?> podcastSeason;


  SongAndPodcast(
      {this.songAndPodcastId,
        this.title,
        this.text,
        this.runningTime,
        this.releaseDate,
        this.budget,
        this.poster,
        this.numberOfRatings,
        this.productionCompanyId,
        this.isPodcast,
        this.productionCompany,
        required this.songAndPodcastGenre,
        this.genre,
        required this.podcastSeason});


  factory SongAndPodcast.fromJson(Map<String,dynamic>json){
    String PhotoStringByte=json["poster"]as String;
    List<int>PhotoIntByte=base64.decode(PhotoStringByte);


    var genreList = <Genre>[];
    if (json['genre'] != null) {
      json['genre'].forEach((v) {
        genreList.add(new Genre.fromJson(v));
      });
    }

    var songAndPodcastGenreList = <SongAndPodcastGenre>[];
    if (json['songAndPodcastGenre'] != null) {
      json['songAndPodcastGenre'].forEach((v) {
        songAndPodcastGenreList.add(new SongAndPodcastGenre.fromJson(v));
      });
    }

    var podcastSeasonList = <PodcastSeason>[];
    if (json['podcastSeason'] != null) {
      json['podcastSeason'].forEach((v) {
        podcastSeasonList.add(new PodcastSeason.fromJson(v));
      });
    }
    return SongAndPodcast(
        songAndPodcastId: json["songAndPodcastId"],
        title: json["title"],
        text: json["text"],
        runningTime: json["runningTime"],
        releaseDate: DateTime.parse(json['releaseDate']),
        budget: json["budget"],
        poster: PhotoIntByte,
        numberOfRatings : json['numberOfRatings'],
        productionCompanyId : json['productionCompanyId'],
        productionCompany : json['productionCompany'] != null? new ProductionCompany.fromJson(json['productionCompany']): null,
        isPodcast: (json['isPodcast']),
        genre: genreList,
        songAndPodcastGenre:songAndPodcastGenreList,
        podcastSeason: podcastSeasonList
    );
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
    if (this.productionCompany != null) {
      data['productionCompany'] = this.productionCompany!.toJson();
    }
    if (this.songAndPodcastGenre != null) {
      data['songAndPodcastGenre'] =
          this.songAndPodcastGenre.map((v) => v!.toJson()).toList();
    }
    if (this.genre != null) {
      data['genre'] = this.genre!.map((v) => v.toJson()).toList();
    }
    if (this.podcastSeason != null) {
      data['podcastSeason'] =
          this.podcastSeason.map((v) => v!.toJson()).toList();
    }
    return data;
  }

}

