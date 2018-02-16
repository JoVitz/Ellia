using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour {
    public bool controlled;
    public int type;
    private Transform target;
    private Vector3 adjust;
    public bool collide;
    public float timeLeft;

	// Use this for initialization
	void Start () {
        controlled = false;
        target = GameObject.Find("MainCharacter").transform;
        adjust = new Vector3(0.8f, 1, 0);
        collide = false;
	}
    //todo fix rock speed

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("SoulBall"))//col.gameObject.name.Equals("MainCharacter") || col.gameObject.name.Contains("Enemy1"))
        {

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic ;
        }
        else
            collide = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("SoulBall")) //col.gameObject.name.Equals("MainCharacter") || col.gameObject.name.Contains("Enemy1"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
        else
            collide = false;
    }



    // Update is called once per frame
    void Update () {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            controlled = false;
        }
        if (controlled && !collide)
        {
            switch(type)
            {
                case 0:
                    if (Vector3.Distance(transform.position, target.position + adjust) < 3 )

                        transform.position += Time.deltaTime * (transform.position - target.position - adjust);
                    Debug.Log("move");
                    break;
                default:
                    break;
            }
        }
		
	}



}
