using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Tilemaps;

// Manages NPCs 5head
public class NpcManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Text friendlyNpcCount;
    [SerializeField] Text enemyNpcCount;

    [Header("Npc Prefab")]
    [SerializeField] GameObject npc;
    [SerializeField] Tilemap groundMap;
    [SerializeField] Tilemap wallMap;

    NpcMovement[] npcs;

    void Start()
    {
        UpdateNpcCount();
    }

    void Update()
    {
        // This is definity not the play but I can't be asked to debug rn
        UpdateNpcCount();
    }

    // Updates every NPCs state
    public void UpdateNPCState(NpcMovement.MoveState newState)
    {
        foreach (NpcMovement npc in npcs)
        {
            npc.SetNpcMoveState(newState);
        }
    }

    // Counts the number of friendly and enemy npcs in the scene and updates the count. This is not perfomant at all
    public void UpdateNpcCount()
    {
        npcs = FindObjectsOfType<NpcMovement>();
        int friendlyNpcs = 0;
        int enemyNpcs = 0;

        foreach (NpcMovement npc in npcs)
        {
            if (npc.GetNpcType() == NpcMovement.NpcType.FRIENDLY)
            {
                friendlyNpcs++;
            }
            else
            {
                enemyNpcs++;
            }
        }

        friendlyNpcCount.text = "Friendly Npcs: " + friendlyNpcs.ToString();
        enemyNpcCount.text = "Enemy Npcs: " + enemyNpcs.ToString();
    }

    // Makes a stronger npc out of two other NPCs
    public void MergeNpcs(NpcMovement npc1, NpcMovement npc2)
    {
        if (!(npcs.Contains(npc1) && npcs.Contains(npc2))) return;
  
        Destroy(npc1.gameObject);
        Destroy(npc2.gameObject);

        NpcMovement newNpc = Instantiate(npc, npc1.transform.position, Quaternion.identity).GetComponent<NpcMovement>();
        newNpc.Setup(this, npc1.GetNpcType(), groundMap, wallMap);
        newNpc.LevelUp(npc1.GetCurrentLevel() + npc2.GetCurrentLevel());
    }
}
