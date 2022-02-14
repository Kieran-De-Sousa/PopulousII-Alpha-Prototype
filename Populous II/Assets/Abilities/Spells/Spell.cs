using UnityEngine;

[CreateAssetMenu]
public class Spell : ScriptableObject
{
    public string spell_name;
    public float spell_duration;
    public int mana_cost;
    public SpellEffect spell_effect;

    public void Update()
    {
       
    }

    public int GetSpellCost()
    {
        return mana_cost;
    }

    public virtual void Activate()
    {
        Debug.Log(spell_name);
    }
}

