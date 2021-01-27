using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BeatLineController : MonoBehaviour
{
    public float SpeedForward = 500;
    protected Rigidbody2D beatRigidbody;
    protected Stopwatch sp;
    void Awake()
    {
        sp = new Stopwatch();
        beatRigidbody = GetComponent<Rigidbody2D>();        
    }

    public void Shoot()
    {
        //sp.Start();
        beatRigidbody.AddForce(new Vector2(-SpeedForward, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BeatSpawnerController beatSpawnerController = Object.FindObjectOfType<BeatSpawnerController>();
            beatSpawnerController.StarMusic();

            //sp.Stop();
            //UnityEngine.Debug.Log(string.Format("Total Time {0}ms", sp.Elapsed.TotalSeconds));
        }
    }
}
