class Gender {
  int? genderId;
  String? genderName;

  Gender({this.genderId, this.genderName});

  Gender.fromJson(Map<String, dynamic> json) {
    genderId = json['genderId'];
    genderName = json['genderName'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['genderId'] = this.genderId;
    data['genderName'] = this.genderName;
    return data;
  }
}