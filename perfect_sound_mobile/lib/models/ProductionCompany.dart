class ProductionCompany {
  final productionCompanyId;
  final String? productionCompanyName;

  ProductionCompany({this.productionCompanyId, this.productionCompanyName});

  factory ProductionCompany.fromJson(Map<String, dynamic> json) {
    return ProductionCompany(
        productionCompanyId : json['productionCompanyId'],
        productionCompanyName : json['productionCompanyName']
    );

  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['productionCompanyId'] = this.productionCompanyId;
    data['productionCompanyName'] = this.productionCompanyName;
    return data;
  }
}