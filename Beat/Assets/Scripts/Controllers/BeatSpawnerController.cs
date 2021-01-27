using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BeatSpawnerController : MonoBehaviour
{
    public GameObject BeatToSpawn;
    public GameObject BeatLineToSpawn;
    public float CollsionSize = 4;
    public float SpawnXPosition = 8.6f;
    public AudioClip MusicAudioClip;
    public float BPM = 100; // just 4/4 for now
    public Song song;
    public bool IsDebug = false;
    public string SongName;

    private AudioSource MusicSound;
    private bool isStart = false;
    private int barIndex = 0;
    private int beatIndex = 0;
    private int beatNumber = 1;    

    void Start()
    {
        var songLoader = Object.FindObjectOfType<SongLoaderController>();
        song = songLoader.LoadSong(SongName);


        MusicSound = gameObject.AddComponent<AudioSource>();
        MusicSound.playOnAwake = false;
        MusicSound.loop = true;
        MusicSound.clip = MusicAudioClip;
        MusicSound.volume = 0.8f;

        var beatsPerSecond = BPM / 60;
        var lengthOf1Beat = 1 / BPM * 60;
        var lengthOf1Bar = lengthOf1Beat * 4;
        var lengthOf8thBeat = lengthOf1Beat / 4;

        InvokeRepeating("Spawn", 2, lengthOf8thBeat);
    }


    void Spawn()
    {
        SpawnBeatline();

        var bar = song.Bars[barIndex];
        var beat = bar.Beats[beatIndex];

        if (beat.BeatNumber == beatNumber)
        {
            var newSpawnBeat = Instantiate(beat.BeatPrephab, new Vector3(SpawnXPosition, beat.YPosition, 0), Quaternion.identity);
            var beatController = newSpawnBeat.GetComponent<BeatController>();
            beatController.HitAudioClip = beat.HitAudioClip;

            beatController.Initialize();

            beatController.Shoot();
            beatIndex++;

            if (beatIndex >= bar.Beats.Count)
                beatIndex = 0;
        }        

        beatNumber++;
        if (beatNumber > 16)
        {
            beatNumber = 1;
            beatIndex = 0;
            barIndex++;

            Debug.Log(string.Format("Bar {0}", barIndex + 1));

            if (barIndex >= song.Bars.Count)
                CancelInvoke();
        }
    }
    void SpawnBeatline()
    {
        var newSpawnBeatline = Instantiate(BeatLineToSpawn, new Vector3(SpawnXPosition, 0, 0), Quaternion.identity);
        var beatLineController = newSpawnBeatline.GetComponent<BeatLineController>();
        var beatLineRenderer = newSpawnBeatline.GetComponent<SpriteRenderer>();

        beatLineRenderer.enabled = IsDebug;

        if (IsDebug)
        {
            switch (beatNumber)
            {
                case 1:
                    beatLineRenderer.color = Color.red;
                    break;
                case 5:
                case 9:
                case 13:
                    beatLineRenderer.color = Color.white;
                    break;
                case 3:
                case 7:
                case 11:
                case 15:
                    beatLineRenderer.color = Color.black;
                    break;
                default:
                    beatLineRenderer.color = Color.grey;
                    break;
            }
        }


        beatLineController.Shoot();
    }

    public void StarMusic()
    {
        if (!isStart)
        {
            isStart = true;

            MusicSound.Play();
        }
    }
}

