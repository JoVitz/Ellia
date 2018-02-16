using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDemo : MonoBehaviour {
    private RegionManager region;
    public TriggerManager book;
    public string content;
    private bool pop;
    private TriggerManager b;
    private PlayerController player;

    // Use this for initialization
    void Start () {
        pop = false;
        player = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(region.nbEnemy1 == 0 && !pop)
        {
            b =  Instantiate(book);
            b.content = content;
            pop = true;
            
        }

        if(pop && b == null)
        {
            Debug.Log("destroying");
            player.knowSoul = true;
            Destroy(this);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Region"))
        {
            region = collision.gameObject.GetComponent<RegionManager>();
            Debug.Log(region + "reg");
        }
    }
}
