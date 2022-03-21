using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class Testingscripts : MonoBehaviour
{
    // Var
    public GameManager gameManager;
    public Tilemap tilemapObject;
    public Tilemap tilemapCollision;


    // Update method. Get a click and delete what the cursor is pointing with a delay (time to destroy for each object. 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 pos = GetWorldPositionOnPlane(mousePos, 0);
                Vector3Int pos2 = tilemapObject.LocalToCell(pos);
                TileBase t = tilemapObject.GetTile(pos2);

                // Timer creator (cf. Timer class)
                Timer.Create(DeleteTile, 5f, pos2, tilemapObject);
                Timer.Create(DeleteTile, 5f, pos2, tilemapCollision);

                if (t.name == "arbre3")
                {
                    gameManager.wood += 2;
                }
                else
                {
                    gameManager.cobble += 1;
                }
            }
            
        }
    }

    // Get a world position from a screenPosition

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    // Delete the tile at the position pos in the Tilemap tilemap.

    public void DeleteTile(Vector3Int pos, Tilemap tilemap)
    {
        tilemap.SetTile(pos, null);
        tilemap.RefreshAllTiles();
    }


}
