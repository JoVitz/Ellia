using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour {

    BoxCollider2D _collider;
    public int nbEnemy1;
    public Enemy1Manager enemy;


    void Awake()
    {
        _collider = gameObject.GetComponent<BoxCollider2D>();
    }

    void SetNewCameraBounds()
    {
        CameraManager cam = Camera.main.gameObject.GetComponent<CameraManager>();
        cam.SetNewBounds(_collider.bounds);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            SetNewCameraBounds();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("coll: " + collision.name);
        if (collision.gameObject.tag == "Player")
        {
            //while (GameObject.FindWithTag("Enemy") != null) Destroy(GameObject.FindWithTag("Enemy"));
            //Destroy(GameObject.FindWithTag("Enemy"));
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
        }
    }

}
