using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashComponent : MonoBehaviour
{
    public Vector2 dashDirection;
    public float maxDashDuration;
    private float curDashDuration;
    public float maxDashCharges;
    private float curDashCharges;
    public float dashPower;
    public bool isDashing;

    public float dashRechargeTime;

    public Slider dashBar;


    // Start is called before the first frame update
    void Start()
    {
        dashBar.maxValue = maxDashCharges;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        ApplyDash(dashDirection);
        RechargeDash();
    }

    public void RechargeDash()
    {
        if (curDashCharges < maxDashCharges)
        {
            curDashCharges += Time.deltaTime/dashRechargeTime;
            dashBar.value = curDashCharges;
        }
    }

    public void Dash(Vector2 direction)
    {
        if (curDashCharges >= 1 && isDashing == false)
        {
            isDashing = true;
            curDashCharges--;
            curDashDuration = maxDashDuration;
            dashDirection = direction.normalized;

            /*
            if (dashDirection.magnitude == 0)
            {
                if (facingRight)
                {
                    dashDirection = new Vector2(1f, 0f);
                }
                else
                {
                    dashDirection = new Vector2(-1f, 0f);
                }
            }
            */
        }
    }

    public void ApplyDash(Vector2 direction)
    {
        if (curDashDuration > 0f)
        {
            curDashDuration -= Time.deltaTime;
            this.GetComponent<Rigidbody2D>().velocity = direction * dashPower;
        }
        if (isDashing && curDashDuration <= 0)
        {
            isDashing = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }
}
