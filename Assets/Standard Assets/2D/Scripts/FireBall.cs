using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float speed = 1;
    Vector3 dir = Vector2.zero;
    public ManaScript mana;


    public void Dir(Vector3 value)
    {
        if (value.Equals(Vector3.zero))
            Destroy(gameObject);// if we have zero direction we destroy this gameojbect;
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
        if (col.gameObject.tag == "Flammable")
        {
            int r = Random.Range(0, 10);
            if (r > 6)
            {
                Instantiate(mana, col.transform.position, Quaternion.identity);
            }

            Destroy(col.gameObject);


        }
        else if(col.gameObject.name.Contains("Enemy1"))
        {
            Enemy1Manager manager = col.gameObject.GetComponent<Enemy1Manager>();
            manager.health -= 2;
            manager.Colored();
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
