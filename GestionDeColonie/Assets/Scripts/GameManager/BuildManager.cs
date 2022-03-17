using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;
using UnityEngine.AI;

public class BuildManager : MonoBehaviour
{
    public NavMeshSurface2d surface;
    public Tilemap tilemapBuildable;
    public Tilemap tilemapCollision;
    public Tilemap tilemapOccupied;
    public Tile[] tilesBuild;
    public Tile[] tilesCollision;
    public List<GameObject> UITiles;
    public static bool active;
    public int selectedTile = 0;

    public Transform tileGridUI;

    private void Start()
    {
        active = false;
        int i = 0;
        foreach (Tile tile in tilesBuild)
        {
            GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f, 1f, 1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;

            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile)
            {
                tileColor.a = 1f;
            }
            i++;
        }
    }

    private void Update()
    {
        surface.BuildNavMesh();
        if (active)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Vector3 pos = GetWorldPositionOnPlane(Input.mousePosition, 0);
                tilemapBuildable.SetTile(tilemapBuildable.WorldToCell(pos), tilesBuild[0]);
                tilemapCollision.SetTile(tilemapCollision.WorldToCell(pos), tilesCollision[0]);
                Debug.Log("fdsfds");
                active = false;
                surface.BuildNavMesh();

            }

        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                surface.BuildNavMesh();
            }
        }
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    public void Activation()
    {
        if (active == false) { active = true; }
            
        else { active = false; }
            
    }

    public void HHH()
    {
        Debug.Log("wtf");
    }
    
}
