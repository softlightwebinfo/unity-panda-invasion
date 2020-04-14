using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{
    [Tooltip("Vida del panda")]
    public float health;
    [Tooltip("Velocidad del panda")]
    public float speed;

    private Animator animator;

    private int animatorDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int animatorEatTriggerHash = Animator.StringToHash("EatTrigger");
    private int animatorHitTriggerHash = Animator.StringToHash("HitTrigger");

    private void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    private void MoveTowards(Vector3 destination)
    {
        // s = v * t
        float step = this.speed * Time.deltaTime;

        this.transform.position = Vector3.MoveTowards(this.transform.position, destination, step);
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
        this.health = 0;
        this.animator.SetTrigger(this.animatorDieTriggerHash);
    }

    private void Eat()
    {
        this.animator.SetTrigger(this.animatorEatTriggerHash);
    }

}
