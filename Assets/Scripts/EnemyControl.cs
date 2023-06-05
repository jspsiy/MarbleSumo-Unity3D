using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyrb;
    public float speed;
    public GameObject powerUpIndicator;
    bool powered = false;
    private GameObject parent;
    private int counter = 0;
    private int gainDifficulty = 3;
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
        if (powered)
        {
            powerUpIndicator.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        }
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
        direction.x = direction.x * 1/ gainDifficulty;
        direction.y = 0;
        direction.z = direction.z * 1/gainDifficulty;
        counter++;
        enemyrb.AddForce(direction*enemyrb.mass* speed * multiplier);
        if (counter > 500)
        {
/*            enemyrb.velocity = Vector3.zero;
            enemyrb.angularVelocity = Vector3.zero;*/
            counter = 0;
        }
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUpIndicator.SetActive(true);
            powered = true;
            if (powered == false)
            {
                enemyrb.mass = enemyrb.mass * 2;
                speed = speed * 2;
            }
            powered = true;
            Destroy(other.gameObject);
        }
    }
    IEnumerator PowerUpCD()
    {
        yield return new WaitForSeconds(7);
        powerUpIndicator.SetActive(false);
        if (powered == true)
        {
            speed = speed / 2;
            enemyrb.mass = enemyrb.mass / 2;
        }
        powered = false;

    }
}
