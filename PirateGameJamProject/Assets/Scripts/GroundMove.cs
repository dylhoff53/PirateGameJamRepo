using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(gameObject.transform.position.x - moveSpeed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.position = movement;
    }
}
