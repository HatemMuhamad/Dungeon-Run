using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagable
{
    public int Health { get; set; }
    public void Damage()
    {
        Debug.Log("Damage called on Moss Giant");
        Health = Health - 1;
        anim.SetTrigger("Hit");         //Animate the hit animation.
        isHit = true;                   //Set is hit bool to true so sprite stops moving.
        anim.SetBool("incombat", true); //Animate the attack animation.
        //If health is less than 1 then play death animation and destroy the sprite after.
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(this.gameObject,anim.GetCurrentAnimatorStateInfo(0).length);
            GameObject diamond = Instantiate(_diamond, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>()._gems = base.gem;
        }
    }
    protected override void Moving()
    {
        base.Moving();
    }
    protected override void Init()
    {
        base.Init();
        Health = base.health;
    }
}


