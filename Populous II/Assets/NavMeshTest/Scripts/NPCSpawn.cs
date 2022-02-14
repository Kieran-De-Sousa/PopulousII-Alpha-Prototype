using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NPCSpawn : MonoBehaviour
{
    public GameObject player;
    public int spawnPop;
    public Tilemap topmap;
    public Tilemap botmap;

    void Start()
    {
        for(int i = 0; i < spawnPop; i++)
        {
            NpcMovement NPC = Instantiate(player).GetComponent<NpcMovement>();
            NPC.Setup(FindObjectOfType<NpcManager>(), Random.Range(0,2) == 0 ? NpcMovement.NpcType.FRIENDLY : NpcMovement.NpcType.ENEMY, topmap, botmap);
            NPC.transform.position = NPC.GetNewRandomDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
