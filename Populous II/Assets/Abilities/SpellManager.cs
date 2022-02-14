using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public enum SpellGroup : int
    {
        PEOPLE = 0,
        VEGETATION = 1,
        EARTH = 2,
        AIR = 3,
        WATER = 4,
        FIRE =5,
        NONE = 6
    }

    private SpellGroup spell_selected;
    private int spell_level = 0;
    public SpellCategory[] spell_categories = new SpellCategory[6];

    void Update()
    {
        //foreach(SpellCategory spell in spell_categories)
        //{
        //    spell.Update();
        //}
    }

    public void SelectSpell(SpellGroup category)
    {
        spell_selected = category;
    }

    public void SelectSpellLevel(int level)
    {
        spell_level = level;
    }

    public void CastSpell(Vector3 mouse_pos)
    {
        //SpellGroup group = (SpellGroup)spell_level;

        switch (spell_selected)
        {
            case SpellGroup.PEOPLE:
                spell_categories[0].Activate(spell_level, mouse_pos);
                break;
            case SpellGroup.VEGETATION:
                spell_categories[1].Activate(spell_level, mouse_pos);
                break;
            case SpellGroup.EARTH:
                spell_categories[2].Activate(spell_level, mouse_pos);
                break;
            case SpellGroup.AIR:
                spell_categories[3].Activate(spell_level, mouse_pos);
                break;
            case SpellGroup.WATER:
                spell_categories[4].Activate(spell_level, mouse_pos);
                break;
            case SpellGroup.FIRE:
                spell_categories[5].Activate(spell_level, mouse_pos);
                break;
            case SpellGroup.NONE:
                Debug.Log("No spells selected");
                break;
            default:
                break;
        }
    }
}
