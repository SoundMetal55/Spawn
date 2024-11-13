using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public enum MovementMode { Ground, Flying };
    public MovementMode currentMovementMode;

    public GameObject characterGameObject;
    public MovementComponentGround movementComponentGround;
    public MovementComponentFlying movementComponentFlying;
    public CastingComponent castingComponent;
    public HealthComponent healthComponent;
    public DashComponent dashComponent;

    public float horizontal;
    public float vertical;

    void Start()
    {
        movementComponentGround = GetComponent<MovementComponentGround>();
        movementComponentFlying = GetComponent<MovementComponentFlying>();
        castingComponent = GetComponent<CastingComponent>();
        healthComponent = GetComponent<HealthComponent>();
        characterGameObject = this.gameObject;

        //placeholder
        currentMovementMode = MovementMode.Ground;
    }

    public bool IsControllable()
    {
        if (dashComponent != null)
        {
            if (dashComponent.isDashing == true)
            {
                return false;
            }
        }
        return true;
    }

    public void ChangeMovementMode(MovementMode newMovementMode)
    {
        currentMovementMode = newMovementMode;
    }
}
