using UnityEngine;
using System.Collections;

public class Enemy : Erratic
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime =  2f;
    private float characterVelocity = 3f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Rigidbody2D g;

    void Start()
    {
        InvokeRepeating("h", 0, 2f);
        g.freezeRotation = true;
    }

    private void h()
    {
        movementDirection = new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
        g.velocity = movementPerSecond * Time.deltaTime;
        Debug.Log(g.velocity.x+" et "+ g.velocity.y);
    }
    
}
