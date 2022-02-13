using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile greenTile;
    public Tile waterTile;
    private Tile checkTile;
    public Vector3Int location;
    private Color tileColor;
    private Color darken = new Color(10f, 10f, 10f);


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tilemap.WorldToCell(position);
            checkTile = tilemap.GetTile<Tile>(location);
            if(checkTile == waterTile)
            {
            tilemap.SetTile(location, greenTile);
            Debug.Log("Change to green block");
            tilemap.RefreshTile(location);
            }
            else if(checkTile == greenTile)
            {
                tileColor = tilemap.GetColor(location);
                tilemap.SetColor(location, (tileColor - darken));
                tilemap.RefreshTile(location);
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tilemap.WorldToCell(position);
            checkTile = tilemap.GetTile<Tile>(location);
            tilemap.SetTile(location, waterTile);
            Debug.Log("Change to water block");
            tilemap.RefreshTile(tilemap.WorldToCell(location));
        } 
    }
}
