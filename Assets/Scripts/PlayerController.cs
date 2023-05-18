using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Transform focalTransform;
    private GameObject focalPoint;
    private int multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
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
}
