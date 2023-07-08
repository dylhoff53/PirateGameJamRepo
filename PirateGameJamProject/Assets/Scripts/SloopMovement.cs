using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloopMovement : MonoBehaviour
{
    public float counter;
    public float waitTime;
    public int block;
    public bool atPeak;
    public Vector3 movement;
    public float speed;
    public bool gameStart;
    public Vector3 sideMovement;
    public float sideMoveSpeed;
    public int numberOfTargets;
    public bool timeToGo;


    public void Update()
    {
        if (gameStart == true)
        {
            counter += Time.deltaTime;

            if (counter >= waitTime)
            {
                block++;
                if (block == 1)
                {
                    atPeak = true;
                }
            }

            if (atPeak == false)
            {
                movement = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime, gameObject.transform.position.z);
                gameObject.transform.position = movement;
            }
            else if (atPeak == true && block == 1)
            {
                Down();
            }
            sideMovement = new Vector3(gameObject.transform.position.x + sideMoveSpeed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = sideMovement;
        }
    }

    public void Down()
    {
        if (timeToGo == false)
        {
            speed = -speed;
        }
        atPeak = false;
        counter = 0f;
        block = 0;
    }

    public void TargetDown()
    {
        numberOfTargets--;
        if (numberOfTargets <= 0)
        {
            Invoke("Leave", 1.0f);
        }
    }

    public void Leave()
    {
        timeToGo = true;
        if (speed > 0f)
        {
            speed = speed * -20f;
        }
        else if (speed < 0f)
        {
            speed = speed * 20f;
        }
        Invoke("Death", 4.0f);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
