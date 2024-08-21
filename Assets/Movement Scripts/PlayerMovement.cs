using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementinput;

    public void IAMovement(InputAction.CallbackContext context)
    {
        movementinput = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementinput.x * movementSpeed * Time.deltaTime, 0, movementinput.y * movementSpeed *Time.deltaTime);
    }
}
