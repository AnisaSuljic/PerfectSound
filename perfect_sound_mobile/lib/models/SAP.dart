import 'dart:convert';

class SAP {
  int? songAndPodcastId;
  String? title;
  String? text;
  String? runningTime;
  DateTime? releaseDate;
  double? budget;
  List<int>? poster;
  int? productionCompanyId;
  bool? isPodcast;
  double? ratingValue;
  String? firstName;
  String? lastName;

  SAP(
      {this.songAndPodcastId,
        this.title,
        this.text,
        this.runningTime,
        this.releaseDate,
        this.budget,
        this.poster,
        this.productionCompanyId,
        this.isPodcast,
        this.ratingValue,
        this.firstName,
        this.lastName});

  SAP.fromJson(Map<String, dynamic> json) {
    print("json: "+ json['firstName'].toString());

    String PhotoStringByte=json["poster"]as String;
    List<int>PhotoIntByte=base64.decode(PhotoStringByte);


    songAndPodcastId = json['songAndPodcastId'];
    title = json['title'];
    text = json['text'];
    runningTime = json['runningTime'];
    releaseDate = DateTime.parse(json['releaseDate']);
    budget = json['budget'];
    poster = PhotoIntByte;
    productionCompanyId = json['productionCompanyId'];
    isPodcast = json['isPodcast'];
    if(json['ratingValue'].runtimeType==int){
      int value=json['ratingValue'];
      ratingValue=value.toDouble();
    }
    else
      ratingValue = json['ratingValue'];
    firstName = json['firstName'];
    lastName = json['lastName'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['title'] = this.title;
    data['text'] = this.text;
    data['runningTime'] = this.runningTime;
    data['releaseDate'] = this.releaseDate;
    data['budget'] = this.budget;
    data['poster'] = this.poster;
    data['productionCompanyId'] = this.productionCompanyId;
    data['isPodcast'] = this.isPodcast;
    data['ratingValue'] = this.ratingValue;
    data['firstName'] = this.firstName;
    data['lastName'] = this.lastName;
    return data;
  }
}
