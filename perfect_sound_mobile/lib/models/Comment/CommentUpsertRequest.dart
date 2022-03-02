class CommentUpsertRequest {
  int? songAndPodcastId;
  int? userId;
  DateTime? dateTimeOfComment;
  String? content;

  CommentUpsertRequest(
      {this.songAndPodcastId,
        this.userId,
        this.dateTimeOfComment,
        this.content});

  CommentUpsertRequest.fromJson(Map<String, dynamic> json) {
    songAndPodcastId = json['songAndPodcastId'];
    userId = json['userId'];
    dateTimeOfComment = DateTime.parse(json['dateTimeOfComment']);
    content = json['content'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['userId'] = this.userId;
    data['dateTimeOfComment'] = this.dateTimeOfComment!.toIso8601String();
    data['content'] = this.content;
    return data;
  }
}