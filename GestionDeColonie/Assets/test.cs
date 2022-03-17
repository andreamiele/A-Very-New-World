using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("h", 10, 60);
    }

    public NavMeshSurface2d surface;

    private void h()
    {
        surface.BuildNavMeshAsync();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
