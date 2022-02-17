import 'dart:convert';

class News{
  final newsId;
  final String? title;
  final String? subTitle;
  final String? content;
  final DateTime? publicationDate;
  final List<int>? coverPhoto;

  News({this.newsId,this.title,this.subTitle,this.content,this.publicationDate,this.coverPhoto});

  factory News.fromJson(Map<String,dynamic>json){
    String PhotoStringByte=json["coverPhoto"]as String;
    List<int>PhotoIntByte=base64.decode(PhotoStringByte);



    return News(
        newsId: json["newsId"],
        title: json["title"],
        subTitle: json["subTitle"],
        content: json["content"],
        publicationDate: DateTime.parse(json['publicationDate']),
        coverPhoto: PhotoIntByte
    );
  }

  Map<String,dynamic>toJson()=>{
    "newsId":newsId,
    "title":title,
    "subTitle":subTitle,
    "content":content,
    "publicationDate":publicationDate!.toIso8601String(),
    "coverPhoto":coverPhoto
  };
}




