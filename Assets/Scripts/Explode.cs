using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public Debris debris;
    public int totalDebris = 10;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Spikes")
        {
            OnExplode();
        }
    }


    public void OnExplode()
    {
        var t = transform;

        for (int i = 0; i< totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(debris, t.position, Quaternion.identity);
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
            body2D.AddForce(Vector3.up * Random.Range(500, 2000));

        }
        Destroy(gameObject);
    }
}