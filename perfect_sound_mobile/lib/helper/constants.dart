import 'package:flutter/material.dart';

const PrimaryColor = Color.fromRGBO(207, 14, 143,1);
const PrimaryColorLight = Color.fromRGBO(212, 174, 236, 0.5450980392156862);
const PrimaryColorLight1 = Color.fromRGBO(234, 174, 236, 0.8823529411764706);
const GoldStar = Color.fromRGBO(226, 179, 8, 100);

const String phoneRegex=r"^(?:[+0]9)?[0-9]{9,10}$";
const String emailRegex=r"^[a-zA-Z0-9.a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9]+\.[a-zA-Z]+";
const String msgRequiredField="Required field!";
const String msgEmailFormatField="Incorrect email format; e.g. example@gmail.com";
const String msgPhoneFormatField="Incorrect phone number format; e.g. 036894257";
const String msgRequiredFieldPass="This field is required if you want to save changes";

String dateFormatConverter(DateTime? date){
  return date!.day.toString()+'.'+date.month.toString()+'.'+date.year.toString();
}

String nameFormat(String? firstName, String? lastName){
  return firstName !=null && lastName!=null?firstName + " "+ lastName:'More than one performer';
}

String timeFormat(String? time){
  if(time!.substring(0,2)=='00')
    return time.substring(3,time.length);
  return time;
}