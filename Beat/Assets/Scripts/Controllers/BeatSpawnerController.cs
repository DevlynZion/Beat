using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class BeatSpawnerController : MonoBehaviour
{
    public GameObject BeatLineToSpawn;
    public float CollsionSize = 4;
    public float SpawnXPosition = 8.6f;
    public AudioClip MusicAudioClip;
    public float BPM = 100; // just 4/4 for now
    public Song song;
    public bool IsDebug = false;
    public bool IsFlattenBeats = false;
    public string SongName;

    private AudioSource MusicSound;
    private bool isStart = false;
    private int barIndex = 0;
    private int beatNumber = 1;
    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
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

        InvokeRepeating("SpawnBeats", 4, lengthOf8thBeat);
    }


    void SpawnBeats()
    {
        SpawnBeatline();

        var bar = song.Bars[barIndex];

        var beatsToShoot = bar.Beats.Where(b => b.BeatNumber == beatNumber);

        if (beatsToShoot.Count() > 0)
        {
            foreach (var beat in beatsToShoot)
            {
                Vector3 position;
                if (IsFlattenBeats)
                    position = new Vector3(SpawnXPosition, 0, 0);
                else
                    position = new Vector3(SpawnXPosition, beat.YPosition, 0);

                var newSpawnBeat = objectPooler.GetFromPool<BeatController>(beat.BeatPrephabName, position, Quaternion.identity);
                newSpawnBeat.HitAudioClip = beat.HitAudioClip;
                newSpawnBeat.Volume = beat.Volume;

                newSpawnBeat.Initialize();

                newSpawnBeat.Shoot();
            }
        }        

        beatNumber++;
        if (beatNumber > 16)
        {
            beatNumber = 1;
            barIndex++;

            if (barIndex >= song.Bars.Count)
                CancelInvoke();
        }
    }
    void SpawnBeatline()
    {
        var newSpawnBeatline = objectPooler.GetFromPool("BeatLine", new Vector3(SpawnXPosition, 0, 0), Quaternion.identity);
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

