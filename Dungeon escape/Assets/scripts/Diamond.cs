using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    public int _gems = 1;
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.AddGems(_gems);
                Destroy(this.gameObject);
            }
            
        }
    }
}
