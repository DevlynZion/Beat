using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class SongData 
{
    public string SongName;
    public List<BarData> Bars;

    public SongData()
    {
        Bars = new List<BarData>();
    }

    public static SongData LoadSong(string songName)
    {
        var song = new SongData();

        var path = Application.persistentDataPath + songName + ".bin";
        song.SongName = songName;

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

    public static void SaveSong(SongData songData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + songData.SongName + ".bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, songData);
        stream.Close();
    }
}
