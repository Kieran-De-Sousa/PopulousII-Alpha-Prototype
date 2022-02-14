using UnityEngine;

[CreateAssetMenu]
public class Flood : Spell
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("Player uses Flood.... The water level is rising.");
    }
}