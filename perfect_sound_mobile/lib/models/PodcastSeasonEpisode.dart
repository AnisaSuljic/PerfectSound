import 'package:perfect_sound_mobile/models/PodcastSeason.dart';

class PodcastSeasonEpisode {
  int? podcastSeasonEpisodeId;
  int? podcastSeasonId;
  String? episodeName;
  int? episodeNumber;
  PodcastSeason? podcastSeason;

  PodcastSeasonEpisode(
      {this.podcastSeasonEpisodeId,
        this.podcastSeasonId,
        this.episodeName,
        this.episodeNumber,
      this.podcastSeason});

  PodcastSeasonEpisode.fromJson(Map<String, dynamic> json) {
    var podcastSeason_ =json['podcastSeason'] != null ? new PodcastSeason.fromJson(json['podcastSeason']) : null;


    podcastSeasonEpisodeId = json['podcastSeasonEpisodeId'];
    podcastSeasonId = json['podcastSeasonId'];
    episodeName = json['episodeName'];
    episodeNumber = json['episodeNumber'];
    podcastSeason = podcastSeason_;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['podcastSeasonEpisodeId'] = this.podcastSeasonEpisodeId;
    data['podcastSeasonId'] = this.podcastSeasonId;
    data['episodeName'] = this.episodeName;
    data['episodeNumber'] = this.episodeNumber;
    data['podcastSeason'] = this.podcastSeason;
    return data;
  }
}
