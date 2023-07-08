using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public GameObject thing;
    public float lifeTime;
    public float counter;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Death", 0.5f);
        if(collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage();
        }
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if(lifeTime <= counter)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
