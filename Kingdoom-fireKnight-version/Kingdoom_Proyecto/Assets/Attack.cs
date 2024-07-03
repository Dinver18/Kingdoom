using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if it can be hit
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            Vector2 deliveredKnocback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            // hit the target
            bool gotHit = damageable.Hit(attackDamage, deliveredKnocback);

            if(gotHit)
                Debug.Log(collision.name + "hit for " + attackDamage);
        }
    }
}
