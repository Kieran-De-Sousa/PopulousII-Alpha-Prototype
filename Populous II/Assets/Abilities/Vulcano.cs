using UnityEngine;

[CreateAssetMenu]
public class Vulcano : Spell
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("Player uses Vulcano.... The earth cracks and fire erupts from the depths...");
    }
}
