using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovePopUp : MonoBehaviour
{
    public float waitTime;
    public float counter;
    public float speed;
    public GameObject Enemy;
    public bool atPeak;
    public Vector3 movement;
    public int thing;

    public void Update()
    {
        counter += Time.deltaTime;
        if(counter >= waitTime)
        {
            atPeak = true;
            thing++;
            if (thing >= 2)
            {

            }
        }
        if (atPeak == false)
        {
            movement = new Vector3 (Enemy.transform.position.x, Enemy.transform.position.y + speed * Time.deltaTime, Enemy.transform.position.z);
            Enemy.transform.position = movement;
        } else if(atPeak == true)
        {
            Invoke("Down", 0.5f);
        }
    }

    public void Down()
    {
        speed = -speed;
        atPeak = false;
        counter = 0f;
    }
}
