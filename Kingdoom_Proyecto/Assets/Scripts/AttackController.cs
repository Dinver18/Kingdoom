using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController contralador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack("atk_1");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Attack("atk_2");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack("atk_3");
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Attack("atk_sp");
        }

    }

    void Attack(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
