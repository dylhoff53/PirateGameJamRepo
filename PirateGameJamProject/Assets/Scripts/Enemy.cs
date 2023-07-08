using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public Rigidbody rig;
    public GameManager gm;
    public bool onObject;
    public GameObject obj;
    public int scoreValue;
    public int ObjectIndex;
    public AudioClip[] deathSounds;
    public AudioSource DeathSource;
    public int selectedDeathSound;
    public bool isTarget;

    public void TakeDamage()
    {
        HP--;
        if(HP == 0)
        {
            gm.addScore(scoreValue);
            //rig.useGravity = true;
            if (isTarget == false)
            {
                selectedDeathSound = Random.Range(0, 15);
                while (selectedDeathSound == gm.lastDeathSound)
                {
                    selectedDeathSound = Random.Range(0, 15);
                }
                DeathSource.clip = deathSounds[selectedDeathSound];
                gm.lastDeathSound = selectedDeathSound;
                DeathSource.Play();
            }

            Invoke("Death", 1.5f);
            if(ObjectIndex == 0)
            {
                obj.GetComponent<CrateMovement1>().TargetDown();
            } else if(ObjectIndex == 1)
            {
                obj.GetComponent<SloopMovement>().TargetDown();
            } else if (ObjectIndex == 2)
            {
                obj.GetComponent<GalleonMovement>().TargetDown();
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
