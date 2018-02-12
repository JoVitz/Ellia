using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {
    private DialogueManager dial;
    public string content;

	// Use this for initialization
	void Start () {
        dial = GameObject.Find("Level").GetComponent<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(content);
            dial.SetDialogue(content);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(content);
            dial.SetDialogue(content);
        }
    }*/

}
