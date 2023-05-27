using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float CollsionSize = 4;
    public float PlayerMoveForce = 50;
    public float InputSensitivity = 0.5f;
    public bool IsLongPlayer = false;

    private Rigidbody2D playerRigidbody;
    private float previousDirection;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
        if (IsLongPlayer)
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.size = new Vector2(boxCollider2D.size.x, 20);
        }
    }

    
    private void FixedUpdate()
    {
        MouseMove();
        //TouchMove();
        //KeybordMove();
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
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, touchedPos.y, Time.deltaTime), 0);
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

    
    private void MouseMove()
    {          
        var deltaY = Input.GetAxis("Mouse Y");

#if !UNITY_EDITOR
        deltaY = deltaY * InputSensitivity;
#endif

        var newPos = transform.position.y + deltaY;

        newPos = Mathf.Clamp(newPos, -CollsionSize, CollsionSize);        

        transform.transform.position = new Vector3(transform.transform.position.x, newPos, 0);
    }
}
