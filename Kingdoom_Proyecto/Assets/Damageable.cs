using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;

    Animator animator;
    
    [SerializeField]
    private int _maxHealth = 100;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private int _health = 100;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if(_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;


    private float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set { 
            _isAlive = value;
            animator.SetBool(AnimationString.isAlive, value);
            Debug.Log("IsAlive set = " + value);
        }
    }


    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationString.lockVelocity);
        }
        private set
        {
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInvincible)
        {
            if(timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }
 
    }

    public bool Hit(int damaged, Vector2 knockback)
    {
        if(IsAlive && !isInvincible)
        {
            Health -= damaged;
            isInvincible = true;
            // Notify
            animator.SetTrigger(AnimationString.hitTrigger);
            damageableHit?.Invoke(damaged, knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damaged);
            LockVelocity = true;

            return true;
        }
        return false;
    }
}
