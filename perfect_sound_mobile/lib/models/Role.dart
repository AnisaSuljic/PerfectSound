class Role {
  final roleId;
  final String? roleName;

  Role({this.roleId, this.roleName});

  factory Role.fromJson(Map<String, dynamic>json) {
    return Role(
      roleId : ['roleId'],
      roleName : json['roleName'],
    );
  }
  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['roleId'] = this.roleId;
    data['roleName'] = this.roleName;
    return data;
  }
}