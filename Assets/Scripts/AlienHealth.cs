using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHealth : MonoBehaviour
{
    public int health = 5;
    public GameObject enemyReference;
    public GameObject enemyExplosion;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            health--;
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                OnExplosion();
                Destroy(enemyReference.gameObject);
            }
        }
    }

    public void OnExplosion()
    {
        Instantiate(enemyExplosion, transform.position, Quaternion.identity);
    }
}
