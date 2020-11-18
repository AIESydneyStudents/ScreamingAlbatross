using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] ParticleSystem explodeParticle;

    [SerializeField] PlayerBehavior playerCar;
    private float speed = 2f;
    public NPCBehaviour target;
    
    public GameObject projectile;
    [SerializeField] float projectileSpeed;

    public Transform particleOffset;

    


    private void Start()
    {
        
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(Instantiate(smokeParticle.gameObject, particleOffset.position, particleOffset.rotation),1);
            Destroy(Instantiate(explodeParticle.gameObject, particleOffset.position, particleOffset.rotation), 1);
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
        if (Input.GetKeyDown(KeyCode.Space) && target != null)
        {
            if (target.beenDelivered == false)
            {
                target.beenDelivered = true;
                
                Destroy(Instantiate(smokeParticle.gameObject, particleOffset.position, particleOffset.rotation), 1); 
                Destroy(Instantiate(explodeParticle.gameObject, particleOffset.position, particleOffset.rotation), 1);
                
                GameObject temp = Instantiate(projectile, transform.position, transform.rotation);
                Projectile giveTarget = temp.GetComponent<Projectile>();
                giveTarget.projectileTarget = target.gameObject;
                giveTarget.shootSpeed = projectileSpeed;
                playerCar.teaAmount++;
                target = null;
            }
        }
    }
}
