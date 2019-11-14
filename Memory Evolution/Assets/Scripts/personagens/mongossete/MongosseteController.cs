﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongosseteController : MonoBehaviour {

    //Basic Atacks Variables
    public Datas dados;
    public GameObject Enemy = null;
    public bool inAtack = false;

    // Walk Variables
    public bool wallCollision = false;
    float speed = 8f;
    float TimerToWalk = 5f;
    Vector3 MyPosition;
    Vector3 MyDestination;
    Rigidbody2D rg2d;
    // Use this for initialization
    void Start () {
        dados = GetComponent<Datas>();
        rg2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
            if (wallCollision)
            {
                DestinationGenerator();
                wallCollision = false;
            }
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (!wallCollision)
                rg2d.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), MyDestination, Time.deltaTime * speed));

            if (TimerToWalk <= 0)
            {
                DestinationGenerator();
                TimerToWalk = Random.Range(4f, 6f);
            }
            TimerToWalk -= Time.deltaTime;
    }

    private void DestinationGenerator()
    {
        MyDestination = new Vector3(Random.Range(transform.position.x - 6f, transform.position.x + 6f), Random.Range(transform.position.y - 6f, transform.position.y + 6f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CircleCollider2D>() == GetComponent<CircleCollider2D>())
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>() != null)
        {
            if (!collision.gameObject.GetComponent<Datas>().collision.collision)
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
            else
                wallCollision = true;
        }
        if (collision.gameObject.GetComponent<MongosseteController>() != null)
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
    }
}
