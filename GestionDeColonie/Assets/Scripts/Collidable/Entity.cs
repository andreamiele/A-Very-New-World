using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
    //
    public int mx;

    public float health=10f;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune> immuneTime)
        {
            lastImmune = Time.time;
            health -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 30, Color.red, transform.position, Vector3.zero, 0.5f);
            if (health <= 0)
            {
                health = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
