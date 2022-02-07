class RatingUpsertRequest {
  int? songAndPodcastId;
  int? userId;
  double? ratingValue;

  RatingUpsertRequest({this.songAndPodcastId, this.userId, this.ratingValue});

  RatingUpsertRequest.fromJson(Map<String, dynamic> json) {
    songAndPodcastId = json['songAndPodcastId'];
    userId = json['userId'];
    ratingValue = json['ratingValue'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['userId'] = this.userId;
    data['ratingValue'] = this.ratingValue;
    return data;
  }
}
