using UnityEngine;

// Makes all of the friendly NPCs move towards one point 
public class PapalMagnet : MonoBehaviour
{
    [SerializeField] GameObject magnet;

    // Checks for left mouse button input
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the click position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // Check that we actually clicked the map
            if (hit.collider != null && hit.collider.CompareTag(TagManager.MAP_TAG))
            {
                UsePapalMagnet(mousePos2D);
            }
        }
    }

    // Makes all friendly NPCs move to the position of the Papal Magnet 
    public void UsePapalMagnet(Vector2 magnetPosition)
    {
        Instantiate(magnet, magnetPosition, Quaternion.identity);

        foreach (NpcMovement npc in FindObjectsOfType<NpcMovement>())
        {
            if (npc.GetNpcType() == NpcMovement.NpcType.FRIENDLY)
            {
                npc.SetDestination(magnetPosition, true);
            }
        }
    }
}
