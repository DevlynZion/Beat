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
                else if(beatData.HitAudioClipName != "")
                    Debug.LogError(string.Format("Beat HitAudioClipName '{0}' does not have an AudioClip", beatData.HitAudioClipName));

                beat.YPosition = beatData.YPosition;
                beat.Volume = beatData.Volume;

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
                    if (int.TryParse(SafeGetValue(beatAttributes, "beatNumber"), out beatNumber))
                        beat.BeatNumber = beatNumber;

                    System.Globalization.NumberFormatInfo nf = new System.Globalization.NumberFormatInfo()
                    {
                        NumberGroupSeparator = "."
                    };

                    float yPosition;
                    yPosition = float.Parse(SafeGetValue(beatAttributes, "yPosition"), nf);
                    beat.YPosition = yPosition;

                    float volume;
                    var volumeString = SafeGetValue(beatAttributes, "volume");
                    if (volumeString != null)
                    {
                        volume = float.Parse(volumeString, nf);
                        beat.Volume = volume;
                    }
                    else
                    {
                        beat.Volume = 1.0f;
                    }


                    beat.BeatPrephabName = SafeGetValue(beatAttributes, "beatPrephabName");
                    beat.HitAudioClipName = SafeGetValue(beatAttributes, "hitAudioClipName");

                    bar.Beats.Add(beat);
                }

                songData.Bars.Add(bar);
            }
        }

        return songData;
    }

    private string SafeGetValue(XmlAttributeCollection attributes, string name)
    {
        var attribute = attributes[name];

        if (attribute != null)
            return attribute.Value;
        else
            return null;
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
