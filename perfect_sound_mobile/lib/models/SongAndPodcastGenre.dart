class SongAndPodcastGenre {
  final songAndPodcastGenreId;
  final int? songAndPodcastId;
  final int? genreId;

  SongAndPodcastGenre(
      {this.songAndPodcastGenreId, this.songAndPodcastId, this.genreId});

  factory SongAndPodcastGenre.fromJson(Map<String, dynamic> json) {
    return SongAndPodcastGenre(
        songAndPodcastGenreId : ['songAndPodcastGenreId'],
        songAndPodcastId : json['songAndPodcastId'],
        genreId : json['genreId']
    );

  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['songAndPodcastGenreId'] = this.songAndPodcastGenreId;
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['genreId'] = this.genreId;
    return data;
  }
}