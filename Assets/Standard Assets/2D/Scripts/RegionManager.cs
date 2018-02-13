using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour {

    BoxCollider2D _collider;


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

        if (other.gameObject.tag == "Player")//&& !GetComponent<BoxCollider2D>().bounds.Intersects(other.bounds))
        {
            Debug.Log("yolo");
            SetNewCameraBounds();
        }
    }

}
