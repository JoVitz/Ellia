using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int levelX=1;
    public int levelY=1;
    public GameObject region;

	// Use this for initialization
	void Start () {
        for(int x = 0; x < levelX; x++)
        {
            for(int y = 0; y<levelY; y++)
            {
                Instantiate(region, new Vector3(x*16, y*12, 0), Quaternion.identity);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
