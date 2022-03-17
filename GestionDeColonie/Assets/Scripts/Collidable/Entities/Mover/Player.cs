using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Mover
{
    public bool hhh = true;
    public LayerMask whatCanBeClickedOn;
    public string nameu;
    private NavMeshAgent myAgent;
    public Animator animator;
    //public GameObject Stats;
    public GameObject tile;
    

    protected override void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.updateRotation = false;
        myAgent.updateUpAxis = false;
        //Stats.GetComponent<TextMesh>().text = nameu;
        //Stats.AddComponent<Rigidbody2D>();
        //Stats.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void FixedUpdate()
    {
        
    }
    public bool active;
    protected void OnMouseDown()
    {
        if (!active)
            active = true;
        else
            active = false;
    }
    float speed = 1f;
    Vector2 lastClickedPos;
    bool moving;

    private void Update()
    {
        
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.updateRotation = false;
        myAgent.updateUpAxis = false;
        //Stats.GetComponent<TextMesh>().text = nameu;
        //Stats.AddComponent<Rigidbody2D>();
        //Stats.GetComponent<Rigidbody2D>().freezeRotation = true;

        if (active)
        {
            animator.SetFloat("H", myAgent.velocity.x);
            if(myAgent.velocity.x>= 0.01f)
            {
                tile.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (myAgent.velocity.x <= -0.01f)
            {
                tile.transform.localScale = new Vector3(-1f, 1f, 1f);
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                lastClickedPos = GetWorldPositionOnPlane(Input.mousePosition, 0);
                //lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }
            if (moving && (Vector2) transform.position != lastClickedPos)
            {
                myAgent.SetDestination(lastClickedPos);
                //float step = speed * Time.deltaTime;
                //transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

            }
            else
            {
                moving=false;
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


    private void OnMouseOver()
    {
        //Stats.SetActive(true);

        hhh = false;
    }

    private void OnMouseExit()
    {
        //Stats.SetActive(false);
        hhh = true;
    }
}
