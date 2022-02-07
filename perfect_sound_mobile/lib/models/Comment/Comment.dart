import '../Users.dart';

class Comment {
  final commentId;
  final int? songAndPodcastId;
  final int? userId;
  final String? dateTimeOfComment;
  final String? content;
  final Users? user;

  Comment(
      {this.commentId,
        this.songAndPodcastId,
        this.userId,
        this.dateTimeOfComment,
        this.content,this.user});

  factory Comment.fromJson(Map<String, dynamic> json) {
    return Comment(
        commentId:json['commentId'],
        songAndPodcastId:json['songAndPodcastId'],
        userId:json['userId'],
        dateTimeOfComment:json['dateTimeOfComment'],
        content:json['content'],
        user : json['user'] != null ? new Users.fromJson(json['user']) : null
    );
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['commentId'] = this.commentId;
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['userId'] = this.userId;
    data['dateTimeOfComment'] = this.dateTimeOfComment;
    data['content'] = this.content;
    return data;
  }
}