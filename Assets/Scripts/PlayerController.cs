using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Transform focalTransform;
    private GameObject focalPoint;
    private float multiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            rb.mass = rb.mass * 2;
            speed = speed * 2;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCD());
        }
    }
    IEnumerator PowerUpCD()
    {
        yield return new WaitForSeconds(7);
        speed = speed / 2;
        rb.mass = rb.mass / 2;
    }
}
