class Users {
  final userId;
  final String? firstName;
  final String? lastName;
  final String? userName;
  final String? email;
  final String? phone;
  final int? userTypeId;

  Users(
      {this.userId,
        this.firstName,
        this.lastName,
        this.userName,
        this.email,
        this.phone,
        this.userTypeId});

  factory Users.fromJson(Map<String, dynamic> json) {
    return Users(
        userId:['userId'],
        firstName:json['firstName'],
        lastName:json['lastName'],
        userName:json['userName'],
        email:json['email'],
        phone:json['phone'],
        userTypeId:json['userTypeId']
    );
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['userId'] = this.userId;
    data['firstName'] = this.firstName;
    data['lastName'] = this.lastName;
    data['userName'] = this.userName;
    data['email'] = this.email;
    data['phone'] = this.phone;
    data['userTypeId'] = this.userTypeId;
    return data;
  }
}