using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using UnityEngine.AI;

public class TileAutomata : MonoBehaviour
{
    [Range(0,100)]
    public int iniChance;
    [Range(0,8)]
    public int birthLimit;
    [Range(0, 8)]
    public int deathLimit;
    [Range(1, 10)]
    public int numR;
    private int count = 0;

    private int[,] terrainMap;
    public Vector3Int tmapSize;

    public Tilemap topmap;
    public Tilemap botmap;
    public Tile topTile;
    public Tile botTile;

    public NavMeshSurface2d[] navMesh;

    int width;
    int height;

    public void doSim(int numR)
    {
        clearMap(false);
        width = tmapSize.x;
        height = tmapSize.y;

        if(terrainMap == null)
        {
            terrainMap = new int[width, height];
            initPos();
        }
        for(int i = 0; i < numR; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1)
                    topmap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                    botmap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);

            }
        }
            }
    public int [,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width, height];
        int neighbour;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                neighbour = 0;
                foreach( var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if(x+b.x >= 0 &&  x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        neighbour += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighbour++;
                    }
                }
                if(oldMap[x,y] == 1)
                {
                    if (neighbour < deathLimit) newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;
                    }
                }
                if (oldMap[x, y] == 0)
                {
                    if (neighbour < birthLimit) newMap[x, y] = 1;
                    else
                    {
                        newMap[x, y] = 1;
                    }
                }
            }
        }

        return newMap;
    }
    public void initPos()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y =0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < iniChance ? 1 : 0;
            }
        }
    }
    public void clearMap(bool complete)
    {
        topmap.ClearAllTiles();
        botmap.ClearAllTiles();
        if(complete)
        {
            terrainMap = null;
        }
    }

    public void generateNavMesh()
    {
        navMesh[0].BuildNavMesh();
//        navMesh[1].BuildNavMesh();
    }
    




    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            doSim(numR);
            generateNavMesh();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            clearMap(true); 
        }

    }
}
