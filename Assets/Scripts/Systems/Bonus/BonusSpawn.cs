using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BonusSpawn : MonoBehaviour
{
    public GameObject bonusPrefab;
    public Tilemap tilemap;
    public TileBase bonusSpawnTile;

    private Vector3 bonusSpawnPosition;

    private void Start()
    {
        // Find the position of the bonus spawn tile
        Vector3Int bonusSpawnTilePosition = Vector3Int.zero;
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.GetTile(pos) == bonusSpawnTile)
            {
                bonusSpawnTilePosition = pos;
                break;
            }
        }

        // Get the world position of the center of the tile
        bonusSpawnPosition = tilemap.GetCellCenterWorld(bonusSpawnTilePosition);

    }

    public void SpawnBonus()
    {
        // Spawn the bonus gameObject at the tile center position
        Instantiate(bonusPrefab, bonusSpawnPosition, Quaternion.identity);
    }
}
