﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] ParticleSystem explodeParticle;

    [SerializeField] PlayerBehavior playerCar;
    private float speed = 2f;
    public NPCBehaviour target;
    
    public GameObject[] projectiles;
    [SerializeField] float projectileSpeed;

    public Transform particleOffset;
    [SerializeField] float rotationLimitPositive = 80;
    [SerializeField] float rotationLimitNegative = 270;

    [SerializeField] ScriptableSoundObject m_Firing;
    [SerializeField] ScriptableFloat m_totalTeaCount;
    [SerializeField] ScriptableInt m_comboObject;

    [SerializeField] ScriptableFloat BritishTeaAmount;
    [SerializeField] ScriptableFloat ChineseTeaAmount;
    [SerializeField] ScriptableFloat IndianTeaAmount;

    [SerializeField] GameEvent m_pickupEvent;

    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.localEulerAngles.y < rotationLimitNegative && transform.localEulerAngles.y > rotationLimitPositive)
        {
            target = null;
        }

        if (target != null)
        {
            speed = 10;
            Vector3 dirToTarget = target.transform.position - transform.position;
            dirToTarget.y = 0f;

            Quaternion lookAt = Quaternion.LookRotation(dirToTarget);
            lookAt.eulerAngles += new Vector3(0, 90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * speed);
        }
        else
        {
            speed = 2;
            Quaternion lookAt = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && target == null)
        {
            m_comboObject.Reset();
        }

        if (Input.GetKeyDown(KeyCode.Space) && target != null)
        {
            
            if (target.beenDelivered == false)
            {
                m_Firing.Play();
                target.beenDelivered = true;
                
                Destroy(Instantiate(smokeParticle.gameObject, particleOffset.position, particleOffset.rotation), 1); 
                Destroy(Instantiate(explodeParticle.gameObject, particleOffset.position, particleOffset.rotation), 1);


                if (target.tag == "Customer")
                {
                    LoadProjectile(0);
                }
                else if (target.tag == "BritishCustomer" && BritishTeaAmount.m_Value > 0)
                {
                    LoadProjectile(1);
                    BritishTeaAmount.m_Value--;
                }
                else if (target.tag == "ChineseCustomer" && ChineseTeaAmount.m_Value > 0)
                {
                    LoadProjectile(2);
                    ChineseTeaAmount.m_Value--;
                }
                else if (target.tag == "IndianCustomer" && IndianTeaAmount.m_Value > 0)
                {
                    LoadProjectile(3);
                    IndianTeaAmount.m_Value--;
                }
                else
                    LoadProjectile(0);

                //playerCar.teaAmount++;
                m_pickupEvent.Raise();
                m_totalTeaCount.m_Value++;
                target.GetComponent<CustomerLogic>().UpdateScore();
                target = null;
            }
        }
    }
    private void LoadProjectile(int whichTea)
    {
        GameObject temp = Instantiate(projectiles[whichTea], transform.position, transform.rotation);

        Projectile giveTarget = temp.GetComponent<Projectile>();
        giveTarget.projectileTarget = target.gameObject;
        giveTarget.shootSpeed = projectileSpeed;
    }
}
