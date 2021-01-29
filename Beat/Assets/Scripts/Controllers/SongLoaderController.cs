using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using UnityEngine;

public class SongLoaderController : MonoBehaviour
{
    public List<BeatClip> BeatClips;

    public Song LoadSong(string SongName)
    {
        var song = new Song();

        var songData = LoadSongData(SongName);

        foreach(var barData in songData.Bars)
        {
            var bar = new Bar();

            foreach (var beatData in barData.Beats)
            {
                var beat = new Beat();

                beat.BeatNumber = beatData.BeatNumber;

                beat.BeatPrephabName = beatData.BeatPrephabName;

                var beatClip = FindBeatClipAudioClip(beatData.HitAudioClipName);
                if (beatClip != null)
                    beat.HitAudioClip = beatClip;

                beat.YPosition = beatData.YPosition;

                bar.Beats.Add(beat);
            }

            song.Bars.Add(bar);
        }


        return song;
    }

    private SongData LoadSongData(string SongName)
    {
        var songData = new SongData();

        var song = new SongData();

        var filePath = Path.Combine(Application.streamingAssetsPath, string.Format("Songs/{0}.xml", SongName));

        song.SongName = SongName;

        using (var www = new WWW(filePath))
        {
            XmlDocument xml = null;
            while (!www.isDone) { }

            xml = new XmlDocument();
            xml.LoadXml(www.text);

            var songNode = xml.DocumentElement.SelectSingleNode("/song");

            var songAttributes = songNode.Attributes;

            songData.SongName = songAttributes["name"].Value;

            int bpm;
            if (int.TryParse(songAttributes["bpm"].Value, out bpm))
                songData.BMP = bpm;

            var barsNodes = songNode.SelectSingleNode("bars");
            var barNodes = barsNodes.SelectNodes("bar");

            foreach (XmlNode barNode in barNodes)
            {
                var bar = new BarData();
                var beatNodes = barNode.SelectNodes("beat");

                foreach (XmlNode beatNode in beatNodes)
                {
                    var beat = new BeatData();
                    var beatAttributes = beatNode.Attributes;

                    int beatNumber;
                    if (int.TryParse(beatAttributes["beatNumber"].Value, out beatNumber))
                        beat.BeatNumber = beatNumber;

                    System.Globalization.NumberFormatInfo nf = new System.Globalization.NumberFormatInfo()
                    {
                        NumberGroupSeparator = "."
                    };

                    float yPosition;
                    yPosition = float.Parse(beatAttributes["yPosition"].Value, nf);
                    beat.YPosition = yPosition;


                    beat.BeatPrephabName = beatAttributes["beatPrephabName"].Value;
                    beat.HitAudioClipName = beatAttributes["hitAudioClipName"].Value;

                    bar.Beats.Add(beat);
                }

                songData.Bars.Add(bar);
            }
        }

        return songData;
    }

    public AudioClip FindBeatClipAudioClip(string BeatClipName)
    {
        var beatClip = BeatClips.Where(c => c.BeatClipName == BeatClipName).FirstOrDefault();
        if (beatClip != null)
            return beatClip.BeatAudioClip;
        else
            return null;
    }
}
