using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        this.transform.position = new Vector2(parent.transform.position.x, parent.transform.position.y - parent.transform.localScale.y / 2);
        this.transform.localScale = new Vector3(parent.transform.localScale.x, 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
