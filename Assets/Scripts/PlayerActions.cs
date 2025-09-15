using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActions : MonoBehaviour
{
    [Header("Growth Values")]
    public float growthTime;

    [Header("Tilemaps & Tiles")]
    public Tilemap groundTilemap;
    public Tilemap treesTilemap;
    public TileBase tileDirt;
    
    [Header("Player")]
    public Transform player;
    public int maxPlantDistance = 5;

    [Header("Lists")]
    public List<Vector3Int> plantedTrees = new List<Vector3Int>();
    public TileBase[] growthTreeTiles;
    private static readonly Vector3Int[] neighbourOffsets = new Vector3Int[]
    {
        new Vector3Int( 1, 0, 0),
        new Vector3Int( 1, 1, 0),
        new Vector3Int( 0, 1, 0),
        new Vector3Int(-1, 1, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(-1, -1, 0),
        new Vector3Int( 0, -1, 0),
        new Vector3Int( 1, -1, 0)
    };

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = groundTilemap.WorldToCell(mouseWorldPos);
            TileBase clickedTile = groundTilemap.GetTile(cellPos);

            if (clickedTile != null && clickedTile == tileDirt)
            {
                Vector3Int playerCell = groundTilemap.WorldToCell(player.position);
                int distance = Mathf.Max(Mathf.Abs(cellPos.x - playerCell.x), Mathf.Abs(cellPos.y - playerCell.y));

                if (distance > maxPlantDistance)
                {
                    Debug.Log("Trop loin pour planter un arbre ! Distance = " + distance);
                    return;
                }

                if (!plantedTrees.Contains(cellPos))
                {
                    foreach (var offset in neighbourOffsets)
                    {
                        Vector3Int neighbourPos = cellPos + offset;
                        if (plantedTrees.Contains(neighbourPos))
                        {
                            Debug.Log("Impossible de planter : un arbre est déjà à côté !");
                            return;
                        }
                    }

                    StartCoroutine(GrowthTree(cellPos));
                    plantedTrees.Add(cellPos);

                    Debug.Log("Tree added! : " + cellPos);
                }
            }
        }
    }

    public IEnumerator GrowthTree (Vector3Int cellPos)
    {
        for (int i = 0; i < growthTreeTiles.Length; i++)
        {
            treesTilemap.SetTile(cellPos, growthTreeTiles[i]);
            yield return new WaitForSeconds(growthTime);
        }

        yield break;
    }
}
