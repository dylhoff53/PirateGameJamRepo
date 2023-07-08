using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float shootRate;
    public float timeCounter;
    public bool canShoot;
    public LayerMask mask;
    public Transform cannon;
    public Transform launchPosition;
    public GameObject missle;
    public float forcePower;
    public AudioSource cannonfire;

    public Camera cam;

    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= shootRate)
        {
            canShoot = true;
        }
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            cannonfire.Play();
            GameObject missleObj = Instantiate(missle, launchPosition.position, Quaternion.identity);
            missleObj.GetComponent<Rigidbody>().AddForce(transform.forward * forcePower);
            canShoot = false;
            timeCounter = 0;
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 250f, mask))
        {
            cannon.LookAt(hit.point);
        }
    }
}
