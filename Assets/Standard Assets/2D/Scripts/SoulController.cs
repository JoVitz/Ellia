using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour {
    public bool controlled;
    public int type;
    private Transform target;
    private Vector3 adjust;

	// Use this for initialization
	void Start () {
        controlled = false;
        target = GameObject.Find("MainCharacter").transform;
        adjust = new Vector3(0.8f, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(controlled)
        {
            switch(type)
            {
                case 0:
                    Debug.Log("rock");
                    if (Vector3.Distance(transform.position, target.position + adjust) < 3)
                        transform.position += Time.deltaTime * (transform.position - target.position - adjust);
                    break;
                default:
                    break;
            }
        }
		
	}
}
