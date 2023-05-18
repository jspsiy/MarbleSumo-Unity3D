using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyrb;
    private bool grounded = false;
    public float speed;
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyrb = GetComponent<Rigidbody>();
        parent = GameObject.FindWithTag("EnemyFocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.transform.position);
        float multiplier = 1f;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < 2)
        {
            multiplier = 2f;
        }
        else
        {
            multiplier = 1f;
        }
        Vector3 direction = (player.transform.position - transform.position);
        if (direction.x > 1) direction.x = 1;
        direction.y = 0;
        if (direction.z > 1) direction.z = 1;

        enemyrb.AddForce(direction*enemyrb.mass* speed * multiplier);

        grounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Island")
        {
            grounded = true; ;
        }
    }
}
