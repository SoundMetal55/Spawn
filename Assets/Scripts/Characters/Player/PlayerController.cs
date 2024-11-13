using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    

    [Header("Keybinds")]
    private int placeholder;

    

    void Update()
    {
        GetInput();

        if (IsControllable())
        {
            if (Input.GetButtonDown("Jump"))
            {
                movementComponentGround.Jump();
            }
            if (Input.GetButtonUp("Jump"))
            {
                movementComponentGround.JumpCancel();
            }
            if (Input.GetButtonDown("Fire3"))
            {
                dashComponent.Dash(new Vector2(horizontal, vertical));
            }
        }
    }

    private void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (IsControllable())
        {
            movementComponentGround.Move(horizontal);
        }
    }
}
