using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Erratic
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 2f;
    private float characterVelocity = 4f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Rigidbody2D g;
    private bool inRange;
    private float triggerLength = 4f;
    private float chaseLength = 4f;
    private float attackLength = 0.16f;
    private GameObject chasingP;
    private bool chasing;
    public GameManager gameManager;



    public List<GameObject> players = new List<GameObject>();
    protected override void Start()
    {
        players = GameManager.instance.settlers;
        InvokeRepeating("h", 0, 2f);
        g.freezeRotation = true;
    }

    private void h()
    {
        movementDirection = new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
        g.velocity = movementPerSecond * Time.deltaTime;
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log("Voici le nombre de joueurs " + GameManager.instance.settlers.Count);
        if (chasing == false)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (Vector3.Distance(players[i].transform.position, transform.position) < chaseLength)
                {
                    chasing = true;
                    inRange = true;
                    chasingP = players[i];
                    CancelInvoke();
                    g.velocity = new Vector2(players[i].transform.position.x - transform.position.x, players[i].transform.position.y - transform.position.y).normalized * characterVelocity * Time.deltaTime*7;
                    continue;
                }
            }
        }
        else
        {
            if (Vector3.Distance(chasingP.transform.position, transform.position) < chaseLength)
            {
                g.velocity = new Vector2(chasingP.transform.position.x - transform.position.x, chasingP.transform.position.y - transform.position.y).normalized * characterVelocity * Time.deltaTime*7;
                if (Vector3.Distance(chasingP.transform.position, transform.position) < attackLength)
                { 
                    Debug.Log("ATTACK");
                }
            }
            else
            {
                chasingP = null;
                chasing = false;
                inRange = false;
                InvokeRepeating("h", 0, 2f);
            }
        }

    }

}
