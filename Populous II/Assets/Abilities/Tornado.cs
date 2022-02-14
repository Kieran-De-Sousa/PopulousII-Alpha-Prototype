using UnityEngine;

[CreateAssetMenu]
public class Tornado : Spell
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("Player uses Tornado.... There goes the house with Dorothy...");
    }
}
