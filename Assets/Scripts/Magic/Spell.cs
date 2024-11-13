using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spell instance used by the spell manager
public class Spell : MonoBehaviour
{ 
    public string spellName = "";

    [SerializeField]
    private int castInput = 0;
    
    
    public void Activate()
    {
        Debug.Log(spellName);
    }
}
