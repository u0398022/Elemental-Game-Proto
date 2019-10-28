﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject projectile;
    float timer = 0;
    bool active = false;
    [SerializeField] float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /// <summary>
    /// this triggers the fireball.
    /// </summary>
    public void Fire()
    {
        
        if(!active)
        {
            Debug.Log("Fireball");

            GameObject fireballHandler;
            Vector3 mousePos = new Vector3((Input.mousePosition.x - gameObject.transform.position.x), (Input.mousePosition.y - gameObject.transform.position.y), 0f);
            Vector3 worldPos;
            Vector3 fireDirection;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f)) //click hit something
            {
                worldPos = hit.point;
            }
            else //click missed the world
            {
                worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            }
            fireDirection = (worldPos - transform.position);//.normalized;
            fireDirection *= 0.1f; //normalizing it without limiting range to exactly 1;
            fireDirection.y = transform.position.y; //might matter for different height enviornments
            fireDirection.Normalize();
            fireDirection *= 2.1f;

            fireballHandler = Instantiate(projectile, transform.position, projectile.transform.rotation) as GameObject;

            int fireballSpeed = 20;
            int fireballHeight = 1;
            fireballHandler.GetComponent<Rigidbody>().velocity = projectile.transform.TransformDirection(fireDirection.x * fireballSpeed, fireDirection.y * fireballHeight, fireDirection.z * fireballSpeed);

        }
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && active)
        {
            active = false;
        }
    }
}
