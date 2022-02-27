class SongAndPodcastSearchRequest {
  String? title;
  int? genreId;
  bool? isPodcast;
  String? releaseDate;
  late int feelingId;
  late int artistId;
  late int year;

  SongAndPodcastSearchRequest(
      {this.title,
        this.genreId,
        this.isPodcast,
        this.releaseDate,
        this.feelingId=0,
        this.artistId=0,
        this.year=0});

  SongAndPodcastSearchRequest.fromJson(Map<String, dynamic> json) {
    title = json['title'];
    genreId = json['genreId'];
    isPodcast = json['isPodcast'];
    releaseDate = json['releaseDate'];
    feelingId = json['feelingId'];
    artistId = json['artistId'];
    year = json['year'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['title'] = this.title;
    data['genreId'] = this.genreId;
    data['isPodcast'] = this.isPodcast;
    data['releaseDate'] = this.releaseDate;
    data['feelingId'] = this.feelingId.toString();
    data['artistId'] = this.artistId.toString();
    data['year'] = this.year.toString();
    print("data: "+ data.runtimeType.toString());
    return data;
  }
}
