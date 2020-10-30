using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] PlayerBehavior playerCar;
    private float speed = 2f;
    public GameObject target;
    private Quaternion normalDirection;
    public GameObject projectile;
    [SerializeField] float projectileSpeed;
    public bool newCustomer = true;

    private void Start()
    {
        normalDirection = transform.rotation;
    }

    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space) && target != null && newCustomer == true)
        {
            
            Vector3 tempPos = transform.position;
            Quaternion tempRotate = transform.rotation;

            GameObject temp = Instantiate(projectile, tempPos, tempRotate);
            Projectile giveTarget = temp.GetComponent<Projectile>();
            giveTarget.projectileTarget = target;
            giveTarget.shootSpeed = projectileSpeed;
            newCustomer = false;
            playerCar.teaAmount++;
        }
    }
}
