using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable
{
    public int damagePoint = 1;
    public float pushForce = 2f;

    private SpriteRenderer sprite;

    // Swing
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "mob")
        {
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
            Debug.Log("DAMGE");
        }
        Debug.Log(coll.name);
    }
}
