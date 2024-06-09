using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float attackCooldown = 2f; // Tiempo de espera entre ataques
    private float lastAttackTime =0f;

    void Update()
    {
        float tiempo = Time.time;
        //Debug.Log(tiempo-lastAttackTime);

            if (tiempo - lastAttackTime >= attackCooldown)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //Debug.Log("Se realizó un ataque con el trigger: Q");

                    StartAttack("atk_1");
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    //Debug.Log("Se realizó un ataque con el trigger: W");

                    StartAttack("atk_2");
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                   // Debug.Log("Se realizó un ataque con el trigger: E");

                    StartAttack("atk_3");
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    //Debug.Log("Se realizó un ataque con el trigger: R");

                    StartAttack("atk_sp");
                }
            }
        
    }

    void StartAttack(string trigger)
    {
        animator.SetTrigger(trigger);
        lastAttackTime = Time.time;
    }

}