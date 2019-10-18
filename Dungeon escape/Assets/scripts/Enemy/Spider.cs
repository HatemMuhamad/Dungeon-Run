using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamagable {
    public GameObject acidEffectPrefab; 
    public int Health { get; set; }

    public void Damage()
    {
        Health = Health - 1;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(this.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            GameObject diamond = Instantiate(_diamond, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>()._gems = base.gem;
        }
    }
    protected override void Init()
    {
        base.Init();
        Health = base.health;
    }
    protected override void Moving()
    {
     
    }
    public void Attack()
    {
        
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
        
    }
  
    protected override void Update()
    {
       
    }
}

