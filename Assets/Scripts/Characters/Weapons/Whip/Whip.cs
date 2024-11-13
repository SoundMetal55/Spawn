using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    public float timeSinceLastAttack;

    public float cooldown;
    public bool attackPrepared;
    public float lightAttackCooldown;
    public float heavyAttackCooldown;

    public float heavyAttackTimeThreshold;

    public float comboTimer;

    public int combo;
    public int maxCombo;

    public GameObject lightAttack;
    public GameObject heavyAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && cooldown <= 0)
        {
            if (timeSinceLastAttack < comboTimer && combo < maxCombo)
            {
                combo++;
            }
            else
            {
                combo = 0;
            }
            attackPrepared = true;
            timeSinceLastAttack = 0f;
        }
        if (Input.GetKeyUp(KeyCode.E) && cooldown <= 0 && attackPrepared)
        {
            
            if (timeSinceLastAttack <= heavyAttackTimeThreshold)
            {
                LightAttack();
            }
            else
            {
                HeavyAttack();
            }
            attackPrepared = false;
        }
    }

    public void Attack()
    {

    }

    public void LightAttack()
    {
        Vector2 pos = new Vector2(transform.parent.transform.position.x + transform.localScale.x, transform.parent.transform.position.y);
        cooldown = lightAttackCooldown;
        var attack = Instantiate(lightAttack, pos, Quaternion.identity);
        attack.transform.parent = gameObject.transform;
    }
    public void HeavyAttack()
    {
        cooldown = heavyAttackCooldown;
        Instantiate(heavyAttack, new Vector2(0, 0), Quaternion.identity);
    }
}
