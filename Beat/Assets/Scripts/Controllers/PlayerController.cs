using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float CollsionSize = 4;
    public float PlayerMoveForce = 50;
    public bool IsLongPlayer = false;

    private Rigidbody2D playerRigidbody;
    private float previousDirection;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        if (IsLongPlayer)
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.size = new Vector2(boxCollider2D.size.x, 20);
        }
    }

    // TODO: still trying to find good controls to use
    void FixedUpdate()
    {
        //TouchMove();
        //ButtonMove();
        KeybordMove();
    }

    private void ButtonMove()
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
    private void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }
    }

    private void KeybordMove()
    {
        var moveBy = Input.GetAxis("Vertical");

        if (moveBy != 0.0f)
        {
            playerRigidbody.AddForce(new Vector2(0, moveBy * PlayerMoveForce), ForceMode2D.Impulse);

            previousDirection = moveBy;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }

    }
}
