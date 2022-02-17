import 'package:perfect_sound_mobile/models/Person.dart';
import 'package:perfect_sound_mobile/models/Role.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcasts.dart';


class SongAndPodcastPerson {
  final songAndPodcastPersonId;
  final int? songAndPodcastId;
  final int? personId;
  final int? roleId;
  final Person? person;
  final SongAndPodcast? songAndPodcast;
  final Role? role;

  SongAndPodcastPerson(
      {this.songAndPodcastPersonId,
        this.songAndPodcastId,
        this.personId,
        this.roleId,
        this.person,
        this.songAndPodcast,
        this.role});

  factory SongAndPodcastPerson.fromJson(Map<String, dynamic> json) {
    return SongAndPodcastPerson(
        songAndPodcastPersonId:json['songAndPodcastPersonId'],
        songAndPodcastId:json['songAndPodcastId'],
        personId:json['personId'],
        roleId:json['roleId'],
        person:json['person'] != null ? new Person.fromJson(json['person']) : null,
        songAndPodcast:json['songAndPodcast'] != null? new SongAndPodcast.fromJson(json['songAndPodcast']): null,
        role:json['role'] != null ? new Role.fromJson(json['role']) : null
    );
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['songAndPodcastPersonId'] = this.songAndPodcastPersonId;
    data['songAndPodcastId'] = this.songAndPodcastId;
    data['personId'] = this.personId;
    data['roleId'] = this.roleId;
    if (this.person != null) {
      data['person'] = this.person!.toJson();
    }
    if (this.songAndPodcast != null) {
      data['songAndPodcast'] = this.songAndPodcast!.toJson();
    }
    if (this.role != null) {
      data['role'] = this.role!.toJson();
    }
    return data;
  }
}









