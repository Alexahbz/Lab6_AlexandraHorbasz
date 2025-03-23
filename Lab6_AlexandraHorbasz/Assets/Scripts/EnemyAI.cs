using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float visibilityRange = 15f;
    public float audibleRange = 10f;
    public float attackRange = 5f;
    public float moveSpeed = 3f;

    private bool isVisible;
    private bool isAudible;
    private bool isOnFlank;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

    }
    void Update()
    {
        isVisible = Vector2.Distance(transform.position, player.position) <= visibilityRange;
        isAudible = Vector2.Distance(transform.position, player.position) <= audibleRange;
        isOnFlank = Mathf.Abs(Vector2.Dot(transform.forward, (player.position - transform.position).normalized)) < 0.5f;

        DecideAction();
    }

    void DecideAction()
    {
        if (isVisible)
        {
            if (Vector2.Distance(transform.position, player.position) < attackRange)
            {
                Attack();
            }
            else
            {
                Move();
            }
        }
        else
        {
            if (!isAudible)
            {
                Creep();
            }
            else
            {
                if (isOnFlank)
                {
                    Move();
                }
                else
                {
                    Attack();
                } 
                
            }
        }
    }

    void Attack()
    {
        Debug.Log("Attack!");
    }
    void Move()
    {
        Debug.Log("Move!");
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
    void Creep()
    {
        Debug.Log("Creeps!");
    }
}
