using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap botMap;
    public Tile greenTile;
    public Tile waterTile;
    private Tile checkTile;
    private Tile newTile;
    public Vector3Int location;
    private Color tileColor;
    private Color darken = new Color(10f, 10f, 10f);
    private TileAutomata auto;
    private void Start()
    {
        auto = this.GetComponent <TileAutomata>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tilemap.WorldToCell(position);
            tilemap.SetTile(location, greenTile);
            Debug.Log("Change to green block");
            tilemap.RefreshTile(location);
            location = botMap.WorldToCell(position);
            botMap.SetTile(location, greenTile);
            Debug.Log("Change to green block");
            botMap.RefreshTile(location);
            auto.generateNavMesh();
        }
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tilemap.WorldToCell(position);
            tilemap.SetTile(location, waterTile);
            Debug.Log("Change to water block");
            tilemap.RefreshTile(tilemap.WorldToCell(location));
            location = botMap.WorldToCell(position);
            botMap.SetTile(location, waterTile);
            Debug.Log("Change to green block");
            botMap.RefreshTile(location);
            auto.generateNavMesh();
        } 
    }
}
