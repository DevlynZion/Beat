using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSong : MonoBehaviour
{
  
    void Start()
    {
        var songloader = Object.FindObjectOfType<SongLoaderController>();

        var song  = SomethingJustLikeThis.Create();

        songloader.SaveSong(song);

        SceneManager.LoadScene("Something Just Like this");
    }

}
