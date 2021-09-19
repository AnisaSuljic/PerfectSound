
import 'package:perfect_sound_mobile/models/Gender.dart';

class Person {
  final personId;
  final String? firstName;
  final String? lastName;
  final String? photo;
  final String? biography;
  final String? dateOfBirth;
  final String? placeOfBirth;
  final String? dateOfDeath;
  final int? genderId;
  final Gender? gender;

  Person(
      {this.personId,
        this.firstName,
        this.lastName,
        this.photo,
        this.biography,
        this.dateOfBirth,
        this.placeOfBirth,
        this.dateOfDeath,
        this.genderId,
        this.gender});

  factory Person.fromJson(Map<String, dynamic> json) {
    return Person(
        personId : ['personId'],
        firstName : json['firstName'],
        lastName : json['lastName'],
        photo : json['photo'],
        biography : json['biography'],
        dateOfBirth : json['dateOfBirth'],
        placeOfBirth : json['placeOfBirth'],
        dateOfDeath : json['dateOfDeath'],
        genderId : json['genderId'],
        gender : json['gender'] != null ? new Gender.fromJson(json['gender']) : null
    );

  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['personId'] = this.personId;
    data['firstName'] = this.firstName;
    data['lastName'] = this.lastName;
    data['photo'] = this.photo;
    data['biography'] = this.biography;
    data['dateOfBirth'] = this.dateOfBirth;
    data['placeOfBirth'] = this.placeOfBirth;
    data['dateOfDeath'] = this.dateOfDeath;
    data['genderId'] = this.genderId;
    if (this.gender != null) {
      data['gender'] = this.gender!.toJson();
    }
    return data;
  }
}