import 'package:flutter/material.dart';
import 'package:perfect_sound_mobile/helper/constants.dart';
import 'package:perfect_sound_mobile/models/PodcastSeason.dart';
import 'package:perfect_sound_mobile/models/PodcastSeasonEpisode.dart';
import 'package:perfect_sound_mobile/services/APIService.dart';

class PodcastMoreDetails extends StatefulWidget {
  final int sapID;
  const PodcastMoreDetails({Key? key, required this.sapID}) : super(key: key);

  @override
  State<PodcastMoreDetails> createState() => _PodcastMoreDetailsState();
}

class _PodcastMoreDetailsState extends State<PodcastMoreDetails> {
  @override

  Widget build(BuildContext context) {
    List listItem=['Item1','Item2','Item3'];
    return Scaffold(
        appBar: AppBar(
        elevation: 0,
        backgroundColor: PrimaryColor,
        centerTitle: true,
        title: Text("Seasons & episodes"),
      ),
      body:SingleChildScrollView(child: bodyWidget(this.widget.sapID)),
      //DropDown(listItem, valueChoose)
    );
  }


  Widget bodyWidget(int sapid) {
    return FutureBuilder<List<PodcastSeason>>(
      future: GetSeasons(sapid),
      builder: (BuildContext context, AsyncSnapshot<List<PodcastSeason>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          if(snapshot.data!.length==0)
            return Center(
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Column(
                  children: [
                    Text("No season yet"),
                    Text("Be patient, they are coming soon...")
                  ],
                ),
              ),
            );
          return ListView(
            scrollDirection: Axis.vertical,
            shrinkWrap: true,
            children: snapshot.data!.map((e) => DropDownWidget(e)).toList(),
          );
        }
      },
    );
  }

  Widget DropDownWidget(PodcastSeason podSeason) {
    return FutureBuilder<List<PodcastSeasonEpisode>>(
      future: GetSeasonEpisode(podSeason.podcastSeasonId as int),
      builder: (BuildContext context, AsyncSnapshot<List<PodcastSeasonEpisode>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text('${snapshot.error}'),
          );
        } else {
          String? valueChoose='';
          var episodes=snapshot.data;
          List<String> noEpisodeList=['No episodes'];
          return
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Container(
                padding: EdgeInsets.only(left: 20, right: 20,),
                child: DropdownButton(
                  hint: Text(podSeason.seasonName.toString(),style: TextStyle(color: Colors.black87),),
                  isExpanded: true,
                  dropdownColor: PrimaryColor,
                  icon: Icon(Icons.arrow_drop_down),
                  iconSize: 36,
                  items: episodes!.length==0?noEpisodeList.map((val)=>DropdownMenuItem(
                    child: Text(val),
                    value: val,
                    enabled: false,
                  )
                  ).toList():
                  episodes.map((val)=>DropdownMenuItem(
                    child: Text(val.episodeNumber.toString()+'.  '+ val.episodeName.toString()),
                    value: val,
                    enabled: false,
                  )
                  ).toList(),
                  onChanged: (value)=>setState(()=>valueChoose=value as String?),
                ),
              ),
            );
        }
      },
    );
  }
}

//Get seasons
Future<List<PodcastSeason>> GetSeasons(int id) async {
  Map<String, String>?queryParams;
  if (id != 0) {
    queryParams = {'SongAndPodcastId': id.toString()};
  }

  var SeasonList = await APIService.Get('PodcastSeason', queryParams);
  var x=SeasonList!.toList();
  var listArt= x.map((i) => PodcastSeason.fromJson(i)).toList();

  return listArt;
}

//Get episodes
Future<List<PodcastSeasonEpisode>> GetSeasonEpisode(int id) async {
  Map<String, String>?queryParams;
  if (id != 0) {
    queryParams = {'PodcastSeasonId': id.toString()};
  }

  var EpisodeList = await APIService.Get('PodcastSeasonEpisode', queryParams);
  var x=EpisodeList!.toList();
  var listEp= x.map((i) => PodcastSeasonEpisode.fromJson(i)).toList();

  return listEp;
}
