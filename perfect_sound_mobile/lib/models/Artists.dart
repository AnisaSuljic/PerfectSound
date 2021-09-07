import 'dart:convert';

import 'Gender.dart';


class Artists {
  final personId;
  final String? firstName;
  final String? lastName;
  final List<int>? photo;
  final String? biography;
  final DateTime? dateOfBirth;
  final String? placeOfBirth;
  final DateTime? dateOfDeath;
  final int? genderId;
  final Gender? gender;

  Artists({
    this.personId,
    this.firstName,
    this.lastName,
    this.photo,
    this.biography,
    this.dateOfBirth,
    this.placeOfBirth,
    this.dateOfDeath,
    this.genderId,
    this.gender
  });


  factory Artists.fromJson(Map<String, dynamic>json){

    print('json '+json.toString());
    String PhotoStringByte=json["photo"]as String;
    List<int>PhotoIntByte=base64.decode(PhotoStringByte);

    var gender_ =json['gender'] != null ? new Gender.fromJson(json['gender']) : null;

    return Artists(
        personId:["personId"],
        firstName:json["firstName"],
        lastName:json["lastName"],
        photo:PhotoIntByte,
        biography:json["biography"],
        dateOfBirth:DateTime.tryParse(json["dateOfBirth"]),
        placeOfBirth:json["placeOfBirth"],
        dateOfDeath:json["dateOfDeath"]!=null?DateTime.tryParse(json["dateOfDeath"]):null,
        genderId:json["genderId"],
        gender:gender_
    );
  }
}
