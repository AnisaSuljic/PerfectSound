import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'News.dart';
import 'SongAndPodcasts.dart';

class Quote {
  final quoteId;
  final int? songAndPodcastId;
  SongAndPodcast? songAndPodcast;
  final String? quoteText;

  Quote({this.quoteId, this.songAndPodcastId, this.quoteText,this.songAndPodcast});

  factory Quote.fromJson(Map<String, dynamic>json) {

    return Quote(
        quoteId : ['quoteId'],
        songAndPodcastId : json['songAndPodcastId'],
        quoteText : json['quoteText'],
    );
  
  
/*
  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['quoteId'] = this.quoteId;
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['quoteText'] = this.quoteText;
    return data;
  }*/
}
}
