import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/models/SongAndPodcastPerson.dart';
import 'package:perfect_sound_mobile/pages/Artists/AllArtists.dart';
import 'package:perfect_sound_mobile/pages/Feelings.dart';
import 'package:perfect_sound_mobile/pages/Home.dart';
import 'package:perfect_sound_mobile/pages/Login&SignUp/UserProfile.dart';
import 'package:perfect_sound_mobile/pages/News/AllNews.dart';
import 'package:perfect_sound_mobile/pages/SongAndPodcasts/AllSongsAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/TopRated.dart';
import 'package:perfect_sound_mobile/pages/Welcome/Welcome.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

import 'constants.dart';

//ROUNDED BUTTONS
class RoundedButton extends StatelessWidget {
  final String text;
  final Function() press;
  final Color color, textColor;
  final bool? disabled;

  const RoundedButton({Key? key, required this.text, required this.press,
    this.color=PrimaryColor, this.textColor=Colors.white, this.disabled
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Container(
      width: size.width*0.7,
      margin: EdgeInsets.symmetric(vertical: 5),
      child:
      ClipRRect(
        borderRadius: BorderRadius.circular(30),
        child: TextButton(
          style: ButtonStyle(
              backgroundColor: MaterialStateProperty.all(disabled!=true?color:PrimaryColorLight1),
              padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 15, horizontal: 40))
          ),
          onPressed: press,
          child: Text(text, style: TextStyle(color: textColor),),
        ),
      ),
    );
  }
}

// TEXT FIELDS
class TextFieldContainer extends StatelessWidget {
  final String hintText;
  final IconData icon;
  final ValueChanged<String>onChanged;
  final IconData? suffixIcon;
  final bool obscureText;
  final TextEditingController? txtController;

  const TextFieldContainer({Key? key, required this.hintText, required this.icon, required this.onChanged,
    this.suffixIcon, required this.obscureText, this.txtController,}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Container(
      margin: EdgeInsets.symmetric(vertical: 5),
      padding: EdgeInsets.symmetric(horizontal: 25),
      width: size.width * 0.7,
      decoration: BoxDecoration(color: PrimaryColorLight, borderRadius: BorderRadius.circular(30)),
      child:
      TextField(
          controller: txtController,
          obscureText: obscureText,
          onChanged: onChanged,
          decoration: InputDecoration(
              icon: Icon(icon, color: PrimaryColor),
              hintText: hintText,
              border: InputBorder.none,
              suffixIcon: IconButton(
                  onPressed: null,
                  icon: Icon(suffixIcon,color: PrimaryColor,)
              )
          )
      ),
    );
  }
}

// TEXT FORM FIELDS
class TextFormFieldContainer extends StatelessWidget {
  final String msgRequiredField;
  final String hintText;
  final String? msgFormat;
  final String? regex;
  final IconData icon;
  final IconData? suffixIcon;
  final bool obscureText;
  final TextEditingController? txtController;

  const TextFormFieldContainer({Key? key, required this.hintText, required this.icon,
    this.suffixIcon, required this.obscureText, this.txtController, required this.msgRequiredField, this.msgFormat, this.regex,}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Container(
      margin: EdgeInsets.symmetric(vertical: 5),
      padding: EdgeInsets.symmetric(horizontal: 25),
      width: size.width * 0.7,
      decoration: BoxDecoration(color: PrimaryColorLight, borderRadius: BorderRadius.circular(30)),
      child:
      TextFormField(
          controller: txtController,
          obscureText: obscureText,
          decoration: InputDecoration(
              icon: Icon(icon, color: PrimaryColor),
              hintText: hintText,
              border: InputBorder.none,
              suffixIcon: IconButton(
                  onPressed: null,
                  icon: Icon(suffixIcon,color: PrimaryColor,)
              ),
          ),
          validator: (value){
            if(value==null || value.isEmpty)
              return msgRequiredField;
            if(regex!=null){
              if(!RegExp(regex!).hasMatch(value))
                return msgFormat;
            }
            return null;
          },
      ),
    );
  }
}

class FormFieldBuild extends StatelessWidget {
  final TextEditingController txtController;
  final String msgRequiredField;
  final String label;
  final String? msgFormat;
  final String? regex;
  final bool obscure;

  const FormFieldBuild({
    Key? key,
    required this.txtController,
    required this.msgRequiredField, required this.label, required this.obscure, this.msgFormat, this.regex,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      controller: txtController,
      obscureText: obscure,
      decoration: InputDecoration(labelText: label),
      validator: (value){
        if(value==null || value.isEmpty)
          return msgRequiredField;
        if(regex!=null){
          if(!RegExp(regex!).hasMatch(value))
            return msgFormat;
        }
        return null;
      },
    );
  }
}

//METHOD - EXTRACTED APPBAR
AppBar buildAppBar(BuildContext context) {
  return AppBar(
      backgroundColor: Colors.white,
      elevation: 0,
      iconTheme: IconThemeData(color: PrimaryColor),
      centerTitle: true,
      actions: [
        TextButton(
            onPressed: (){Navigator.push(context,MaterialPageRoute(builder:(context){return UserProfile();}));},
            child: Row(
              children: [
                Icon(Icons.account_box_rounded,color: PrimaryColor,),
                Text(
                  APIService.username as String,
                  style: TextStyle(fontSize: 16, color: Colors.black87),
                ),
              ],
            ))
      ]);
}

//METHOD - EXTRACTED DRAWER
Drawer buildDrawer(BuildContext context) {
  return Drawer(
    child: ListView(
      children: [
        Container(
          height: 80,
          child: DrawerHeader(
              child: ListTile(
                title: Center(
                    child: Text('PerfectSound',
                        style: TextStyle(color: Colors.white, fontSize: 16))),
                onTap: () {
                  Navigator.push(
                      context, MaterialPageRoute(builder: (context) => Home()));
                },
              )),
          decoration: BoxDecoration(color: PrimaryColor),
        ),
        CardBuilder(route: AllNews(), cardName: "News"),
        CardBuilder(
            route: AllSongsAndPodcasts(isPodcast: false), cardName: "Songs"),
        CardBuilder(
            route: AllSongsAndPodcasts(isPodcast: true),
            cardName: "Podcasts"),
        CardBuilder(route: AllArtists(), cardName: "Artists"),
        CardBuilder(route: TopRated(), cardName: "Top rated"),
        CardBuilder(route: Feelings(), cardName: "Feelings"),
        CardBuilder(route: Welcome(), cardName: "Log out"),
      ],
    ),
  );
}

//WIDGET - EXTRACTED CARD FROM DRAWER
class CardBuilder extends StatelessWidget {
  final Widget route;
  final String cardName;

  const CardBuilder({
    Key? key,
    required this.route,
    required this.cardName,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: ListTile(
        title: Text(cardName, style: TextStyle(fontSize: 16)),
        onTap: () {
          //Navigator.of(context).pushReplacementNamed('/allnews');
          Navigator.push(
              context, MaterialPageRoute(builder: (context) => route));
        },
      ),
    );
  }
}

//WIDGET - TEXT FIELDS - USER PROFILE
class ProfileTextField extends StatelessWidget {
  final TextEditingController txtController;
  final String label;
  final bool obscureText;
  final ValueChanged<String>onChanged;
  final String? errMsg;


  const ProfileTextField({Key? key, required this.txtController, required this.label, required this.obscureText, required this.onChanged, this.errMsg}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(20,0,20,0),
      child: TextField(
        onChanged: onChanged,
        obscureText: obscureText,
        decoration: InputDecoration(labelText: label, errorText: errMsg),
        autocorrect: false,
        controller: txtController,
      ),
    );
  }
}

//WIDGET - LINE SEPARATOR
class LineSeparator extends StatelessWidget {
  final double width;
  final double height;
  const LineSeparator({
    Key? key, required this.width, required this.height,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Align(
      alignment: Alignment.centerLeft,
      child: Padding(
        padding: const EdgeInsets.fromLTRB(20,0,0,0),
        child: Container(
          height: height,
          width: width,
          decoration: BoxDecoration(borderRadius: BorderRadius.circular(10),color: PrimaryColor),
        ),
      ),
    );
  }
}

class PageTitle extends StatelessWidget {
  final String title;
  const PageTitle({
    Key? key, required this.title,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Align(
      alignment: Alignment.centerLeft,
      child: Padding(
        padding: const EdgeInsets.fromLTRB(20,0,0,5),
        child: Text(title,style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold, color: Colors.black87),textAlign: TextAlign.start,),
      ),
    );
  }
}

class GenreCard extends StatelessWidget {
  final String genre;
  const GenreCard({
    Key? key, required this.genre,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      alignment: Alignment.center,
      margin: EdgeInsets.only(left: 10),
      padding: EdgeInsets.symmetric(
          horizontal: 15,
          vertical: 3
      ),
      decoration: BoxDecoration(
          border: Border.all(color: PrimaryColor),
          borderRadius: BorderRadius.circular(20)
      ),
      child: Text(genre,style: TextStyle(color: Colors.black87),),
    );
  }
}
//Artists heads

class ArtistsHeads extends StatelessWidget {
  final SongAndPodcastPerson artists;
  const ArtistsHeads({
    Key? key, required this.artists,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(right: 10),
      width: 80,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Container(
            height: 50,
            decoration: BoxDecoration(
              shape: BoxShape.circle,
              image: DecorationImage(
                image:MemoryImage(artists.person!.photo as Uint8List)
              )
            ),
          ),
          SizedBox(height: 3,),
          Text(nameFormat(artists.person!.firstName,artists.person!.lastName), textAlign: TextAlign.center,maxLines: 2,style: TextStyle(fontSize: 10,fontWeight: FontWeight.bold,color: Colors.black87),),
          Text(artists.role!.roleName.toString(), textAlign: TextAlign.center,style: TextStyle(fontSize: 10,color: Colors.black87)),
        ],
      ),
    );
  }
}

