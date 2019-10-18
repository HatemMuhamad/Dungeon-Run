using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gem;
    [SerializeField]
    protected Transform pointA, pointB;
    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isHit = false;
    protected Player player;
    protected bool isDead = false;
    [SerializeField]
    protected GameObject _diamond;
    //Initialize components
    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        Init();
    }
    protected virtual void Update()
    {
        //If in Idle or in combat do not move.
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("incombat")==false)
        {
            return;
        }
        //if dead do not move.
        if (isDead == false)
        {
            Moving();
            AnimateIdle();
        }

    }
    //Movement of enemy.
    protected virtual void Moving()
    {
        //If current postion is Point A then idle then move to point B.
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            sprite.flipX = false;
        }
        //If current position is point B then idle then flip then move to point A. 
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            sprite.flipX = true;
        }
        //If enemy character is not hit then keep moving else do not move. 
        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        //If distance between enemy and player is greater than 2 then enemy should move on and stop fighting.
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("incombat", false);
        }
        //Flip enemy to face the player.
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x > 0 && anim.GetBool("incombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("incombat") == true)
        {
            sprite.flipX = true;
        }

    }
    //Animate idle when at pointA or B.
    protected virtual void AnimateIdle()
    {
        if(transform.position == pointA.position || transform.position == pointB.position)
        {
            anim.SetTrigger("Idle");
        }
    }

}
    

