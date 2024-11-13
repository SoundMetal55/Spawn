using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipLight : MonoBehaviour
{
    private int team;
    private HashSet<GameObject> hitCharacters = new HashSet<GameObject>();
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        DestroySelf();
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        DestroySelf();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<HealthComponent>() != null && hitCharacters.Contains(other.gameObject) != true)
        {
            other.gameObject.GetComponent<HealthComponent>().TakeDamage(15);
            hitCharacters.Add(other.gameObject);
        }
    }

    private void DealDamage()
    {

    }

    private void DestroySelf()
    {
        if (timer >= 0.3f)
        {
            Destroy(transform.gameObject);
        }
    }
}
