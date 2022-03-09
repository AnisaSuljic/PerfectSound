import 'package:perfect_sound_mobile/models/SAP.dart';

class Quote {
  final quoteId;
  final int? songAndPodcastId;
  SAP? songAndPodcast;
  final String? quoteText;
  final String? artistName;

  Quote({this.quoteId, this.songAndPodcastId, this.quoteText,this.songAndPodcast,this.artistName});


  factory Quote.fromJson(Map<String, dynamic>json) {

    var songAndPodcast_ =json['songAndPodcast'] != null ? new SAP.fromJson(json['songAndPodcast']) : null;

    return Quote(
        quoteId : ['quoteId'],
        songAndPodcastId : json['songAndPodcastId'],
        songAndPodcast: songAndPodcast_,
        quoteText : json['quoteText'],
        artistName : json['artistName'],
    );
  }
}
