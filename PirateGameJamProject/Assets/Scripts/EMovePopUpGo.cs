using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovePopUpGo : MonoBehaviour
{
    public float waitTime;
    public float counter;
    public float speed;
    public GameObject Enemy;
    public bool atPeak;
    public Vector3 movement;
    public int thing;
    public int block;

    public void Update()
    {
        counter += Time.deltaTime;

        if(counter >= waitTime)
        {
            block++;
            if(block == 1)
            {
                thing++;
                atPeak = true;
                if (thing >= 2)
                {
                    Destroy(Enemy);
                }
            }
        }
        if (atPeak == false)
        {
            movement = new Vector3 (Enemy.transform.position.x, Enemy.transform.position.y + speed * Time.deltaTime, Enemy.transform.position.z);
            Enemy.transform.position = movement;
        } else if(atPeak == true && block == 1)
        {
            Invoke("Down", 1.5f);
        }
    }

    public void Down()
    {
        speed = -speed;
        Debug.Log("Down Speed =" + speed);
        atPeak = false;
        counter = 0f;
        block = 0;
    }
}
