using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScript : MonoBehaviour {
    public PlayerController player;
    public int hp;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("enter " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            player.health.value += hp;

        }
        Destroy(gameObject);
    }
}
