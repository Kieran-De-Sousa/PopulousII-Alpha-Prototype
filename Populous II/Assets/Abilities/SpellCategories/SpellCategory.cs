using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellCategory : ScriptableObject
{
    // Update is called once per frame
    public Spell[] spells = new Spell[6];

    public void Update()
    { 
        foreach (Spell spell in spells)
        {
            spell.Update();
        }
    }

    public void Activate (int spell_level)
    {
        Debug.Log("Spell level " + spell_level + " is cast");
    }
}
