using Assets.Scripts.Models.Buildings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public class TileSystem : MonoBehaviour
{
    private PlayerSystem PlayerSystem;

    public Tilemap BuildingsTileMap;
    public Tilemap UITileMap;

    private Tile TentTile;
    private Tile OutlineTile;

    [Inject]
    private void Construct(PlayerSystem playerSystem)
    {
        PlayerSystem = playerSystem;
        Load();
    }

    private void Load()
    {
        //TentTile = Resources.Load<Tile>("Tiles/TentTile");
        OutlineTile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_24");
    }


    private void Start()
    { 
        Refresh();
    }

    public void Refresh()
    {
        SetBuildings(PlayerSystem.Player.Buildings);
        SetOutline(PlayerSystem.OutlineTilePos);
    }

    private void SetBuildings(List<BaseBuilding> buildings)
    {
        foreach (BaseBuilding building in buildings)
        {
            BuildingsTileMap.SetTile(building.Pos, building.Tile);
        }
    }

    private void SetOutline(Vector3Int pos)
    {
        UITileMap.ClearAllTiles();
        if (pos != null)
        {
            UITileMap.SetTile(pos, OutlineTile);
        }
    }
      
    public bool IfSpaceOccupied(Vector3Int pos)
    {
        Tile CurTile = BuildingsTileMap.GetTile<Tile>(pos);
        if (CurTile != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3Int GetTileByCurMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3Int position = BuildingsTileMap.WorldToCell(worldPoint);

        //TileBase tile = BuildingsTileMap.GetTile(position);
        return position;
    }
}
