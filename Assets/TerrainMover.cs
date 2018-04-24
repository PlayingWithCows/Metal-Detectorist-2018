using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMover : MonoBehaviour {

    public Terrain terrain;
    public Terrain originalTerrain;
    public float[,] terrainHeights;
    public float[,] originalTerrainHeights;
    public float modifyingHeight;
   

    private void Start()
    {
        terrain = transform.GetComponent<Terrain>();
        terrainHeights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight);
        originalTerrainHeights = originalTerrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight);
    }

    public void MoveTerrain(Vector3 location, float strength, int size)
    {

        location = location - terrain.gameObject.transform.position;
        location = new Vector3(location.x / terrain.terrainData.size.x, location.z / terrain.terrainData.size.z, 0);
        location = new Vector3(location.x * terrain.terrainData.heightmapWidth, location.y * terrain.terrainData.heightmapHeight,0);

        for (int y = -size; y <= size; y++)
        {
            for (int x = -size; x <= size; x++)
            {
               // Debug.Log("y: " + (Mathf.RoundToInt(location.y) + y) + " ; x: " + (Mathf.RoundToInt(location.x) + x));
                if (Mathf.Abs(x + y) <= size) { terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] = Mathf.Clamp(terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + strength, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x]- modifyingHeight, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + modifyingHeight); }
                else if (Mathf.Abs(x)+ Mathf.Abs(y) <= size*1.4f) { terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] = Mathf.Clamp(terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + strength*0.7f, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] - modifyingHeight, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + modifyingHeight); }
                else if (Mathf.Abs(x) + Mathf.Abs(y) <= size * 1.6f) { terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] = Mathf.Clamp(terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + strength * 0.4f, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] - modifyingHeight, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + modifyingHeight); }
                else if (Mathf.Abs(x) + Mathf.Abs(y) > size * 1.9f) { terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] = Mathf.Clamp(terrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + strength * 0.2f, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] - modifyingHeight, originalTerrainHeights[Mathf.RoundToInt(location.y) + y, Mathf.RoundToInt(location.x) + x] + modifyingHeight); }
            }
            
        }

        terrain.terrainData.SetHeights(0, 0, terrainHeights);
    }

}
