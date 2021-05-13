
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Route : MonoBehaviour
{
    private Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tileColor();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void tileColor()
    {
        tilemap = gameObject.GetComponent<Tilemap>() as Tilemap;
        tilemap.CompressBounds();
        List<string> coordinates = new List<string>();
        Vector3Int oldPos = new Vector3Int(0,0,0);
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPlace);
            TileBase tile = tilemap.GetTile(pos);
            if (tilemap.HasTile(localPlace) && tile.name.Equals("tileset-sliced_317"))
            {
                //tileWorldLocations.Add(place);
                //Debug.LogFormat("x: {0} y: {1} tile: {2}", pos.x,pos.y,tile.name);
                tilemap.SetTileFlags(localPlace, TileFlags.None);
                //tilemap.SetColor(localPlace, Color.blue);


                coordinates.Add(pos.x + " " + pos.y);
            }
            if(pos.x == 0 && pos.y == 0)
            {
                tilemap.SetTileFlags(localPlace, TileFlags.None);
                tilemap.SetColor(localPlace, Color.green);
            }
        }
    }
}
