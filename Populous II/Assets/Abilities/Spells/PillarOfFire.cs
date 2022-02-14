using UnityEngine;

[CreateAssetMenu]
public class PillarOfFire : Spell
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("Player uses Pillar of Fire.... it burns everything...");
    }
}
