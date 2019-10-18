using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable {
    public int Health { get; set; }

    public void Damage()
    {
        Debug.Log("Damage");
        Health = Health - 1;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("incombat", true);
        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(this.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
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
