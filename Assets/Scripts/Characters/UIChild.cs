using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChild : MonoBehaviour
{
    public Slider slider;
    private float offset;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.parent.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.WorldToScreenPoint(new Vector2(transform.parent.transform.position.x, transform.parent.transform.position.y + offset));
        slider.transform.position = pos;
    }
}
