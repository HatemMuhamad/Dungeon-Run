using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator anim;
    private Animator _swordAnimator;
	void Start () {
        anim = GetComponentInChildren<Animator>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void move(float move)
    {
        anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jump(bool status)
    {
        anim.SetBool("Jump", status);
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
        _swordAnimator.SetTrigger("SwordAnimation");
    }
    public void Death()
    {
        anim.SetTrigger("Death");
    }
}
