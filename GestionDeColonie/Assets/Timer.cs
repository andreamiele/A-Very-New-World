using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Tilemaps;

public class Timer 
{
    public static Timer Create(Action<Vector3Int,Tilemap> action, float timer, Vector3Int vector3Int, Tilemap tilemap)
    {
        GameObject gameobject = new GameObject("Timer", typeof(MonoBehaviourHood));
        Timer timer1 = new Timer(action, timer, gameobject, vector3Int, tilemap);

        gameobject.GetComponent<MonoBehaviourHood>().onUpdate = timer1.Update;

        return timer1;
    }

    private class MonoBehaviourHood : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    
    }

    private Action<Vector3Int, Tilemap> action;
    private float timer;
    private bool isDestroyed;
    private GameObject gameObject;
    private Vector3Int vector3Int;
    Tilemap tilemap;

    private Timer(Action<Vector3Int, Tilemap> action, float timer, GameObject gameObject, Vector3Int vector3Int, Tilemap tilemap)
    {
        this.action = action;
        this.timer = timer;
        this.gameObject = gameObject;
        this.tilemap = tilemap;
        this.vector3Int = vector3Int;
        isDestroyed = false;
    }


    public void Update()
    {
        if (!isDestroyed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                action(vector3Int,tilemap);
                DestroySelf();
            }
        }
    }

    private void DestroySelf()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
    }
}