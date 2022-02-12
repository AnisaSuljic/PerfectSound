class UserUpsertRequest {
  String? firstName;
  String? lastName;
  String? userName;
  String? email;
  String? phone;
  String? password;
  String? passwordConfirm;
  int? userTypeId;

  UserUpsertRequest(
      {this.firstName,
        this.lastName,
        this.userName,
        this.email,
        this.phone,
        this.password,
        this.passwordConfirm,
        this.userTypeId});

  UserUpsertRequest.fromJson(Map<String, dynamic> json) {
    firstName = json['firstName'];
    lastName = json['lastName'];
    userName = json['userName'];
    email = json['email'];
    phone = json['phone'];
    password = json['password'];
    passwordConfirm = json['passwordConfirm'];
    userTypeId = json['userTypeId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['firstName'] = this.firstName;
    data['lastName'] = this.lastName;
    data['userName'] = this.userName;
    data['email'] = this.email;
    data['phone'] = this.phone;
    data['password'] = this.password;
    data['passwordConfirm'] = this.passwordConfirm;
    data['userTypeId'] = this.userTypeId;
    return data;
  }
}