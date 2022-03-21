using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Entity
{
    // Start is called before the first frame update
    protected BoxCollider2D BoxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;



    protected virtual void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
    }
    
    protected virtual void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0) ;

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Make sure when can move into this direction by carting a box there first if the box returns null wer're free to move.
        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Make sure when can move into this direction by carting a box there first if the box returns null wer're free to move.
        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
