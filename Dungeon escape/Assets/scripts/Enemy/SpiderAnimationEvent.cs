using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour {

    private Spider sp;

    private void Start()
    {
        sp = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        StartCoroutine(Breathe());
        sp.Attack();
        
    }
    private IEnumerator Breathe()
    {
        yield return new WaitForSeconds(5.0f);
    } 
}
