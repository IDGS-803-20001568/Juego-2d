using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;

    private Transform shootPoint;
    private void Awake()
    {
        shootPoint = transform.Find("shootPoint");

    }

    private void Start()
    {
        //InvokeRepeating("Shoot", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {

            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletPrefab != null && shootPoint != null && shooter != null)
        {
            GameObject bulletCloned = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity) as GameObject;
            PlayerBullet bulletComponent = bulletCloned.GetComponent<PlayerBullet>();

            if (shooter.transform.localScale.x < 0f) 
            {
                bulletComponent.direction = Vector2.left;
            }
            else
            {
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
