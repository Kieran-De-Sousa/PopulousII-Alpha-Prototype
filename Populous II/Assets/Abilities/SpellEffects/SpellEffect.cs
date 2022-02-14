using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellEffect : ScriptableObject
{
    public SpellEffect (string name, float dur)
    {
        spell_name = name;
        duration = dur;
    }

    ~SpellEffect()
    {
        Debug.Log(name + " is expired");
    }

    public string spell_name = "Spell Name";
    public ParticleSystem spell_effect;
    public float duration = 0.0f;

    public abstract void Activate();

    public abstract void ApplyEffect();

    public void Update()
    {
        if (duration > 0.0f)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            Destroy(this);
        }
    }
}

