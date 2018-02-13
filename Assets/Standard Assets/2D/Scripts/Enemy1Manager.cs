using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Manager : MonoBehaviour {
    private Animator animator;
    private Rigidbody2D rbody;
    public Vector2 movement_vector;
    private bool move;
    private float timer;
    public int speedFactor = 15;
    public int health = 5;
    public int damage = 1;
    private Color startcolor;
    private float timeLeft;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        movement_vector = new Vector2();
        InitTimer();
        startcolor = GetComponent<Renderer>().material.color;
        timeLeft = 0;
    }
	
    public void Colored(){
        timeLeft = 0.3f;
        GetComponent<Renderer>().material.color = Color.red;
    }

	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

        if (health < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(health);

        timer -= Time.deltaTime;

        if (timer > 0 && movement_vector.magnitude > 0)
        {
            animator.SetBool("enemy1_isWalking", true);
            animator.SetFloat("input_x_enemy1", movement_vector.x);
            animator.SetFloat("input_y_enemy1", movement_vector.y);

            rbody.MovePosition(rbody.position + movement_vector / speedFactor);

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            float widthRel = this.transform.lossyScale.x / (Screen.width) / 2; //relative width
            float heightRel = this.transform.lossyScale.y / (Screen.height) / 2; //relative height


            pos.x = Mathf.Clamp(pos.x, widthRel, 1 - widthRel);
            pos.y = Mathf.Clamp(pos.y, heightRel, 1 - heightRel);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            //todo empecher passage autre écran avec joueur
            //todo empecher toucher bord écran + destruct + pop
        }
        else if (timer < 0)
            InitTimer();
        else
            animator.SetBool("enemy1_isWalking", false);
    }

    void InitTimer()
    {
        timer = Random.Range(0f, 2f);

        movement_vector = Random.insideUnitCircle;
        movement_vector.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().health.value -= damage;
        }
    }

}
