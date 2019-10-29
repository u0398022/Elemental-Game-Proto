﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AoeBlast : MonoBehaviour
{
    public GameObject aoeRing;
    [SerializeField] GameObject AoeObject;
    float timer = 0;
    bool active = false;
    [SerializeField] float cooldown;
    GameObject Blast;

    public RawImage AoeCooldown;

    Vector3 Empty = new Vector3(0, 1, 1);
    Vector3 Full = new Vector3(1, 1, 1);
    AbilityManager theManager;
    // Start is called before the first frame update
    void Start()
    {
        theManager = GameObject.Find("ElementalPlayer").GetComponent<AbilityManager>();
    }
    public void Fire()
    {
        if (!active)
        {
            Debug.Log("AoeBlast");
            timer = cooldown;
            Blast = Instantiate(AoeObject, transform.position, AoeObject.transform.rotation) as GameObject;
            //aoeRing.SetActive(true);
            active = true;
            theManager.currentMana -= theManager.AoeMana;
            AoeCooldown.rectTransform.localScale = Empty;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && active)
        {
            aoeRing.SetActive(false);
            active = false;
            AoeCooldown.rectTransform.localScale = Full;
        }
    }
}
