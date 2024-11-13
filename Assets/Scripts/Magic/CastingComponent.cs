using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// applied to a character to give them the ability to cast spells.
public class CastingComponent : MonoBehaviour
{
    public List<Spell> Spells;
    private Spell activeSpell;

    [SerializeField]
    private float maxBlood;
    private float blood;

    [Header("CastingAttributes")]
    private float castingSpeedModifier;
    private float castingPowerModifier;
    

    void Start()
    {
        activeSpell = Spells[0];
    }

    void SetStats()
    {
        blood = maxBlood;
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown("space"))
        {
            CastActiveSpell();
        }
        */
    }
    //allow multicasting and keybinding spells. build ui for preselection
    private void ChangeActiveSpell(int spellIndex)
    {
        activeSpell = Spells[spellIndex];
    }

    public void CastActiveSpell()
    {
        activeSpell.Activate();
    }
}
