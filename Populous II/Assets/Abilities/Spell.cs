using UnityEngine;

public class Spell : ScriptableObject
{
    enum SpellState
    {
        READY,
        COOLDOWN
    }

    public string spell_name;
    public float cooldown_time;
    public float spell_duration;
    public int mana_cost;
    SpellState state = SpellState.READY;

    private float spell_cooldown = 0.0f;

    public void Update()
    {
        if (state == SpellState.COOLDOWN && spell_cooldown > 0.0f)
        {
            spell_cooldown -= Time.deltaTime;
        }
        else if (state == SpellState.COOLDOWN && spell_cooldown <= 0.0f)
        {
            state = SpellState.READY;
            spell_cooldown = 0.0f;
            Debug.Log(spell_name + " is ready to use again");
        }
    }

    public int GetSpellCost()
    {
        return mana_cost;
    }

    public bool IsActive()
    {
        return state == SpellState.READY;
    }

    public virtual void Activate()
    {
        state = SpellState.COOLDOWN;
        spell_cooldown = cooldown_time;
        // The code here should instantiate a Spell game object.
    }
}

