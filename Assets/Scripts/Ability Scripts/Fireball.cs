﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Fireball : MonoBehaviour
{
    //sound
    public AudioClip fireballsnd;
    public AudioSource Playersnd;


    public RawImage fireballCooldown;
    public GameObject projectile;
    float timer = 0;
    bool active = false;
    [SerializeField] float cooldown;
    Vector3 Empty = new Vector3(0, 1, 1);
    Vector3 Full= new Vector3(1, 1, 1);
    AbilityManager theManager;

    [HideInInspector] public float fireballSpeed = 40f;
    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
        // get audio source
        Playersnd.clip = fireballsnd;

        theManager = GameObject.Find("ElementalPlayer").GetComponent<AbilityManager>();
    }
    /// <summary>
    /// this triggers the fireball.
    /// </summary>
    public void Fire()
    {
        if(!active)
        {
            Debug.Log("Fireball");
          
            // play sound for fireball
            Playersnd.Play();
            Playersnd.pitch = Random.Range(0.7f, 3f);

            //fireballCooldown.rectTransform.localScale = Empty;

            GameObject fireballHandler;
            Vector3 fireDirection;
            /*
            Vector3 mousePos = new Vector3((Input.mousePosition.x - gameObject.transform.position.x), (Input.mousePosition.y - gameObject.transform.position.y), 0f);
            Vector3 worldPos;
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
            */
            fireDirection = transform.forward;
            Vector3 center = transform.position;
            center.y += 4;

            fireballHandler = Instantiate(projectile, center, projectile.transform.rotation) as GameObject;

            float fireballHeight = .15f;
            fireballHandler.GetComponent<Rigidbody>().velocity = projectile.transform.TransformDirection(fireDirection.x * fireballSpeed, fireDirection.y * fireballHeight, fireDirection.z * fireballSpeed);
            timer = 0;
            active = true;
            theManager.currentMana -= theManager.FireballMana;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <= cooldown)
        {
            timer += Time.deltaTime;
        }
        if (timer >= cooldown && active)
        {
            
            //fireballCooldown.rectTransform.localScale = Full;
            active = false;
        }
        float ratio = timer/cooldown;
        fireballCooldown.rectTransform.localScale= new Vector3(ratio, 1, 1);
    }

}
