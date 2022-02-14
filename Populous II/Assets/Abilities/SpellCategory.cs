using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCategory : ScriptableObject
{
    // Update is called once per frame
    public void Update()
    { 
        
    }

    public void Activate (int spell_level)
    {
        Debug.Log("Spell level " + spell_level + " is cast");
    }
}
