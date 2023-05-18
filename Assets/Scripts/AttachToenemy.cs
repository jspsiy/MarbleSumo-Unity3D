using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToenemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject enemy;  
    void Start()
    {
        enemy = GameObject.FindWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = enemy.transform.position;
    }
}
