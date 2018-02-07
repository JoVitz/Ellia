using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBall : MonoBehaviour {

    public float speed = 1;
    Vector3 dir = Vector2.zero;
    public float timer = 10f;

    public void Dir(Vector3 value)
    {
        if (value.Equals(Vector3.zero)) Destroy(gameObject);// if we have zero direction we destroy this gameojbect;
                                                            //rotate our sprite towards direction of moving
        float angle = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("enter " + col.gameObject.name);
        if (col.gameObject.tag == "Soulable")
        {
            col.gameObject.GetComponent<SoulController>().controlled = true;
            col.gameObject.GetComponent<SoulController>().timeLeft= timer;

        }
        Destroy(gameObject);
    }

}
