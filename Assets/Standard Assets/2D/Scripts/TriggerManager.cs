using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {
    private DialogueManager dial;
    public string content;
    public bool pause=false;
    public bool destroy = false;

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
            dial.SetDialogue(content, pause);
            if (destroy)
                Destroy(gameObject);
        }
    }


}
