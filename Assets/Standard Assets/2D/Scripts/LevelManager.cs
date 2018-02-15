using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int levelX=1;
    public int levelY=1;
    public GameObject region;
    public int[] enemy1list;


	// Use this for initialization
	void Start () {
        //populate the map with Regions
        int i = 0;
        for(int x = 0; x < levelX; x++)
        {
            for(int y = 0; y<levelY; y++)
            {
                GameObject obj = Instantiate(region, new Vector3(x*21.4f, y*16, 0), Quaternion.identity);
                obj.GetComponent<RegionManager>().nbEnemy1 = enemy1list[i];//todo complete
                i++;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
