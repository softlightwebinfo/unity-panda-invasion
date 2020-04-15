using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{
    [Tooltip("Vida del panda")]
    public float health;
    [Tooltip("Velocidad del panda")]
    public float speed;
    [Tooltip("Daño que hacemos a la tarta cuando el panda llega a ella")]
    public int cakeEatenPerBite;

    private Animator animator;
    private Rigidbody2D m_rigidbody;

    private int animatorDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int animatorEatTriggerHash = Animator.StringToHash("EatTrigger");
    private int animatorHitTriggerHash = Animator.StringToHash("HitTrigger");

    private static GameManager gameManager;

    private const float waypointThreshold = 0.001f;
    private Waypoint currentWaypoint;

    private bool isEating = false;

    private void Start()
    {
        if (!gameManager)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        this.animator = this.GetComponent<Animator>();
        this.m_rigidbody = this.GetComponent<Rigidbody2D>();
        this.currentWaypoint = gameManager.firstWaypoint;
    }

    private void FixedUpdate()
    {
        if (!this.currentWaypoint && !isEating)
        {
            this.Eat();
            return;
        }

        float distance = Vector2.Distance(this.transform.position, currentWaypoint.GetPosition());

        if (distance < waypointThreshold)
        {
            currentWaypoint = currentWaypoint.GetNextWaypoint();
        }
        else
        {
            this.MoveTowards(currentWaypoint.GetPosition());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            this.Hit(collision.GetComponent<ProjectileScript>().damage);
        }
    }

    private void MoveTowards(Vector3 destination)
    {
        // s = v * t
        float step = this.speed * Time.fixedDeltaTime;
        this.m_rigidbody.MovePosition(Vector3.MoveTowards(this.transform.position, destination, step));
    }

    private void Hit(float damage)
    {
        // Resto el daño de mi vida actual
        this.health -= damage;

        if (this.health > 0)
        {
            this.animator.SetTrigger(this.animatorHitTriggerHash);
            return;
        }
        this.animator.SetTrigger(this.animatorDieTriggerHash);

        gameManager.OnMoreEnemyInHell();
    }

    private void Eat()
    {
        this.animator.SetTrigger(this.animatorEatTriggerHash);
        isEating = true;
        gameManager.BiteTheCake(cakeEatenPerBite);
    }

}
