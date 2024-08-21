using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementinput;

    public float gravity = 9.8f;
    public float jumpSpeed = 20f;
    public float verticalSpeed = 0;
    public float movementSpeed = 2;

    public void IAMovement(InputAction.CallbackContext context)
    {
        movementinput = context.ReadValue<Vector2>();
    }

    public void IAJump(InputAction.CallbackContext context)
    {
        if (context.started == true)
        {
            Debug.Log("Started");
        }
        if (context.performed == true)
        {
            Debug.Log("performed");
        }
        if (context.canceled == true)
        {
            Debug.Log("cancelled");
        }
    }

            // Start is called before the first frame update
            void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GroundCheck() == true)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed = (verticalSpeed - gravity) * Time.deltaTime;
        }
        transform.Translate(movementinput.x * movementSpeed * Time.deltaTime, verticalSpeed, movementinput.y * movementSpeed * Time.deltaTime);
    }

    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1);
    }
}
