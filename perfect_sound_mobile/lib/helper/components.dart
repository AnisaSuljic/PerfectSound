import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/pages/AllArtists.dart';
import 'package:perfect_sound_mobile/pages/AllNews.dart';
import 'package:perfect_sound_mobile/pages/AllSongsAndPodcasts.dart';
import 'package:perfect_sound_mobile/pages/Feelings.dart';
import 'package:perfect_sound_mobile/pages/Home.dart';
import 'package:perfect_sound_mobile/pages/Login&SignUp/Login.dart';
import 'package:perfect_sound_mobile/pages/Login&SignUp/UserProfile.dart';
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
        CardBuilder(route: Feelings(), cardName: "Feelings"),
        CardBuilder(route: Login(), cardName: "Log out"),
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

  const ProfileTextField({Key? key, required this.txtController, required this.label, required this.obscureText}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(20,0,20,0),
      child: TextField(
        obscureText: obscureText,
        decoration: InputDecoration(labelText: label),
        autocorrect: false,
        controller: txtController,
      ),
    );
  }
}

