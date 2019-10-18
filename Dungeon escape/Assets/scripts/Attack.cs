using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    bool canAttack = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("hit:" + other.name);
        IDamagable hit = other.GetComponent<IDamagable>();
        if(hit != null)
        {
            if(canAttack == true)
            {
                hit.Damage();
                canAttack = false;
            }     
        }
        StartCoroutine(ResetAttack());
    }
    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
