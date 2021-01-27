using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SongLoaderController : MonoBehaviour
{
    public List<Prephab> BeatPrephabs;
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

                var prephab = BeatPrephabs.Where(p => p.PrephabName == beatData.BeatPrephabName).First();
                if (prephab != null)
                    beat.BeatPrephab = prephab.PrephabObject;

                var beatClip = BeatClips.Where(c => c.BeatClipName == beatData.HitAudioClipName).FirstOrDefault();
                if (beatClip != null)
                    beat.HitAudioClip = beatClip.BeatAudioClip;

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

        var path = Application.persistentDataPath + SongName + ".bin";
        songData.SongName = SongName;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SongData data = formatter.Deserialize(stream) as SongData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }

    public void SaveSong(Song Song)
    {
        var songData = new SongData();

        foreach(var bar in Song.Bars)
        {
            var barData = new BarData();

            foreach (var beat in bar.Beats)
            {
                var beatData = new BeatData();

                beatData.BeatNumber = beat.BeatNumber;

                var prephab = BeatPrephabs.Where(p => p.PrephabObject == beat.BeatPrephab).First();
                if (prephab != null)
                    beatData.BeatPrephabName = prephab.PrephabName;

                var beatClip = BeatClips.Where(c => c.BeatAudioClip == beat.HitAudioClip).First();
                if (beatClip != null)
                    beatData.HitAudioClipName = beatClip.BeatClipName;

                beatData.YPosition = beat.YPosition;


                barData.Beats.Add(beatData);
            }

            songData.Bars.Add(barData);
        }

        SaveSong(songData);
    }

    public void SaveSong(SongData songData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + songData.SongName + ".bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, songData);
        stream.Close();
    }


    public GameObject FindPrephabGameObject(string PrephabName)
    {
        var prephab = BeatPrephabs.Where(p => p.PrephabName == PrephabName).First();
        if (prephab != null)
            return prephab.PrephabObject;
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
