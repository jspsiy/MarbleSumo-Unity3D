using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public GameObject powerUpIndicator;
    private bool powered;
    private Transform focalTransform;
    private GameObject focalPoint;
    private float multiplier = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        powerUpIndicator.SetActive(false);
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (powered)
        {
            powerUpIndicator.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        }
        if (Input.GetKeyDown("space"))
        {
            multiplier = 2;
        }
        if (Input.GetKeyUp("space"))
        {
            multiplier = 1;
        }
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward *rb.mass* speed * multiplier * forwardInput);
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            powerUpIndicator.SetActive(true);
            if (powered == false) {
                rb.mass = rb.mass * 2;
                speed = speed * 2;
            }
            powered = true;

            Destroy(other.gameObject);
            StartCoroutine(PowerUpCD());
        }
    }
    IEnumerator PowerUpCD()
    {
        yield return new WaitForSeconds(7);
        powerUpIndicator.SetActive(false);
        if (powered == true) {
            speed = speed / 2;
            rb.mass = rb.mass / 2;
        }
        powered = false;
    }
}
