using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public Spell[] spells = new Spell[3];
    public KeyCode[] keys = new KeyCode[3];

    void Update()
    {
        foreach(Spell spell in spells)
        {
            spell.Update();
        }

        int key_index = 0;
        foreach (KeyCode key in keys)
        {           
            if (Input.GetKeyDown(key))
            {
                if (spells[key_index].IsActive())
                {
                    spells[key_index].Activate();
                }
                else
                {
                    Debug.Log(spells[key_index] + " spell is on cooldown");
                }
            }
            ++key_index;
        }
    }
}
