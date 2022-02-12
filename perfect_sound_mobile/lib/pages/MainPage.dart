import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'AllArtists.dart';
import 'AllNews.dart';
import 'Home.dart';
import 'Login&SignUp/Login.dart';

class MainPage extends StatefulWidget {
  const MainPage({Key? key}) : super(key: key);

  @override
  _MainPageState createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> {
  @override
  Widget build(BuildContext context) {
    return Container();
  }
}

/*
class MainPage extends StatefulWidget {
  const MainPage({Key? key}) : super(key: key);

  @override
  _MainPageState createState() => _MainPageState();
}

int currentIndex = 1;

class _MainPageState extends State<MainPage> {
  List pages = [
    AllArtists(),
    Home(),
    AllArtists(),
    AllNews(),
  ];
  void onTap(int index) {
    setState(() {
      currentIndex = index;
    });
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: pages[currentIndex],
      //bottomNavigationBar: BottomNavBar(),
      appBar: AppBar(
        backgroundColor: Colors.white,
        elevation: 0,
        iconTheme: IconThemeData(color: PrimaryColor),
        centerTitle: true,
        title: Image.asset(
          "assets/images/logo.png",
          height: 50,
        ),
      ),
      drawer: Drawer(
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
            Card(
              child: ListTile(
                title: Text(
                  'News',
                  style: TextStyle(fontSize: 16),
                ),
                onTap: () {
                  //Navigator.of(context).pushReplacementNamed('/allnews');
                  //Navigator.push(context,MaterialPageRoute(builder: (context) => AllNews()));
                  setState(() {
                    currentIndex=3;
                  });
                },
              ),
            ),/*
            Card(
              child: ListTile(
                title: Text(
                  'Songs',
                  style: TextStyle(fontSize: 16),
                ),
                onTap: () {
                  /*Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) =>
                              AllSongsAndPodcasts(isPodcast: false)));*/
                  currentIndex=4;
                  onTap(currentIndex);
                },
              ),
            ),
            Card(
              child: ListTile(
                title: Text(
                  'Podcasts',
                  style: TextStyle(fontSize: 16),
                ),
                onTap: () {
                  currentIndex=5;
                  onTap(currentIndex);
                  /*Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) =>
                              AllSongsAndPodcasts(isPodcast: true)));*/
                },
              ),
            ),
            Card(
              child: ListTile(
                title: Text(
                  'Artists',
                  style: TextStyle(fontSize: 16),
                ),
                onTap: () {
                  currentIndex=6;
                  onTap(currentIndex);
                  /*Navigator.push(context,
                      MaterialPageRoute(builder: (context) => AllArtists()));*/
                },
              ),
            ),
            Card(
              child: ListTile(
                title: Text(
                  'Feelings',
                  style: TextStyle(fontSize: 16),
                ),
                onTap: () {
                  currentIndex=7;
                  onTap(currentIndex);
                  /*Navigator.push(context,
                      MaterialPageRoute(builder: (context) => Feelings()));*/
                },
              ),
            ),
            Card(
              child: ListTile(
                title: Text(
                  'Log out',
                  style: TextStyle(fontSize: 16),
                ),
                onTap: () {
                  Navigator.push(context,
                      MaterialPageRoute(builder: (context) => Login()));
                },
              ),
            )*/
          ],
        ),
      ),
    );
  }

  BottomNavigationBar BottomNavBar() {
    return BottomNavigationBar(
      type: BottomNavigationBarType.fixed,
      backgroundColor: Colors.white,
      onTap: onTap,
      currentIndex: currentIndex,
      selectedItemColor: PrimaryColor,
      unselectedItemColor: Colors.black54,
      showUnselectedLabels: false,
      showSelectedLabels: false,
      elevation: 0,
      items: [
        BottomNavigationBarItem(
            label: "Recommendation", icon: Icon(Icons.recommend)),
        BottomNavigationBarItem(label: "Home", icon: Icon(Icons.home)),
        BottomNavigationBarItem(
            label: "Top rated", icon: Icon(Icons.star_rate_outlined)),
      ],
    );
  }
}*/
