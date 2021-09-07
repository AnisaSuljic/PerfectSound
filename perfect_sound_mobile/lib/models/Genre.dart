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