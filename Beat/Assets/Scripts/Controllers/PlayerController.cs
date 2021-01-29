using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float CollsionSize = 4;
    public float PlayerMoveForce = 50;

    private Rigidbody2D playerRigidbody;
    private float previousDirection;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //float mouseYvalue =  CrossPlatformInputManager.GetAxis("Vertical");

        //var newPos = transform.position.y + mouseYvalue;

        //if ((newPos <= CollsionSize) && (newPos >= -CollsionSize))
        //{
        //   transform.Translate(0, mouseYvalue, 0);

        //}
        //else if (newPos >= CollsionSize)
        //{
        //    newPos = CollsionSize;
        //}
        //else
        //{
        //    newPos = -CollsionSize;
        //}

        //var direction = Mathf.Clamp(CrossPlatformInputManager.GetAxis("Vertical"), -1, 1);
        var direction = CrossPlatformInputManager.GetAxis("Vertical");


        if (direction != 0.0f)
        {
            //if (previousDirection != direction)
            //    playerRigidbody.velocity = Vector2.zero;

            playerRigidbody.AddForce(new Vector2(0, direction * PlayerMoveForce), ForceMode2D.Impulse);

            previousDirection = direction;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
