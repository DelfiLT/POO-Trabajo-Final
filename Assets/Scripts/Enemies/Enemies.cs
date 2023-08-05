using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected float velocity;
    [SerializeField] protected float range;
    [SerializeField] protected float minRange;
    [SerializeField] public int damage;

    public gameManager GM;

    protected float distanceFromPlayer1;
    protected float distanceFromPlayer2;

    protected Transform player1Transform;
    protected Transform player2Transform;
    
    protected Animator AnimEnemy;

    protected virtual void Die() { }

    protected virtual void FindPlayer()
    {
        player1Transform = GameObject.FindGameObjectWithTag("Player1").transform;
        player2Transform = GameObject.FindGameObjectWithTag("Player2").transform;
    }
}
