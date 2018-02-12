using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Manager : MonoBehaviour {
    private Animator animator;
    private Rigidbody2D rbody;
    public Vector2 movement_vector;
    private bool move;
    private float timer;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        movement_vector = new Vector2();
        InitTimer();
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer > 0 && movement_vector.magnitude > 0)
        {
            animator.SetBool("enemy1_isWalking", true);
            animator.SetFloat("input_x_enemy1", movement_vector.x);
            animator.SetFloat("input_y_enemy1", movement_vector.y);



            rbody.MovePosition(rbody.position + movement_vector / 10);

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            //todo empecher passage autre écran avec joueur
        }
        else if (timer < 0)
            InitTimer();
    }

    void InitTimer()
    {
        timer = Random.Range(0f, 2f);

        movement_vector = Random.insideUnitCircle;
        movement_vector.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Contains("Region"))
        {
            Debug.Log("region");
            InitTimer();
        }
    }

}
