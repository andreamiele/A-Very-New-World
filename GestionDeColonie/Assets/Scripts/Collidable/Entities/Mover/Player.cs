using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : Mover
{
    // ... ------------------------------------------
    public string playerName;

    public bool onMouseOver = true;
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
    public Animator animator;


    public bool active;

    float speed = 1f;
    Vector2 lastClickedPos;
    bool moving;
    //public GameObject Stats;




    // Start and Update functions ------------------------------------------

    protected override void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.updateRotation = false;
        myAgent.updateUpAxis = false;
        //Stats.GetComponent<TextMesh>().text = nameu;
        //Stats.AddComponent<Rigidbody2D>();
        //Stats.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    protected override void Update()
    {
        base.Update();
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.updateRotation = false;
        myAgent.updateUpAxis = false;
        //Stats.GetComponent<TextMesh>().text = nameu;
        //Stats.AddComponent<Rigidbody2D>();
        //Stats.GetComponent<Rigidbody2D>().freezeRotation = true;

        if (active)
        {
            animator.SetFloat("H", myAgent.velocity.x);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    lastClickedPos = GetWorldPositionOnPlane(Input.mousePosition, 0);
                    //lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    moving = true;
                }
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

    // Hover effect on colons. ------------------------------------------
    private void OnMouseOver() 
    {
        //Stats.SetActive(true);
        onMouseOver = false;
    }

    private void OnMouseExit()
    {
        //Stats.SetActive(false);
        onMouseOver = true;
    }


    // On click effects on colons ------------------------------------------
    protected void OnMouseDown()
    {
        GameManager.instance.GUIPlayer.SetActive(true);
        GameManager.instance.justClickedPlayer = this;

    }
}
