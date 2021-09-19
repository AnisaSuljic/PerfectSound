class PodcastSeason {
  final podcastSeasonId;
  final int? songAndPodcastId;
  final String? seasonName;

  PodcastSeason({this.podcastSeasonId, this.songAndPodcastId, this.seasonName});

  factory PodcastSeason.fromJson(Map<String, dynamic> json) {
    return PodcastSeason(
        podcastSeasonId : ['podcastSeasonId'],
        songAndPodcastId : json['songAndPodcastId'],
        seasonName : json['seasonName']
    );

  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['podcastSeasonId'] = this.podcastSeasonId;
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['seasonName'] = this.seasonName;
    return data;
  }
}