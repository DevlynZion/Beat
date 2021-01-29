using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBorderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beat")
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<BeatController>().Stop();
        }
        else if (collision.gameObject.tag == "BeatLine")
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<BeatLineController>().Stop();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

}
