class Rating {
  int? userId;
  int? songAndPodcastId;
  double? ratingValue;

  Rating({this.userId, this.songAndPodcastId, this.ratingValue});

  Rating.fromJson(Map<String, dynamic> json) {
    userId = json['userId'];
    songAndPodcastId = json['songAndPodcastId'];
    if(json['ratingValue'].runtimeType==int){
      int value=json['ratingValue'];
      ratingValue=value.toDouble();
    }
    else
      ratingValue = json['ratingValue'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['userId'] = this.userId;
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['ratingValue'] = this.ratingValue;
    return data;
  }
}
