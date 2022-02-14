using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellCategory : ScriptableObject
{
    // Update is called once per frame
    public string cat_name;
    public Spell[] spells = new Spell[5];

    public void Update()
    { 
        //foreach (Spell spell in spells)
        //{
        //    spell.Update();
        //}
    }

    public void Activate (int spell_level)
    {
        Debug.Log("Spell " + cat_name +" level " + spell_level + " is cast");
        spells[spell_level].Activate();
    }
}
