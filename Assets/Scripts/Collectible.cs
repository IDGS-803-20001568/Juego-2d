using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; // Mantén esto solo si necesitas usar Tilemaps

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player")) // Usando CompareTag para mayor eficiencia
        {
            Destroy(gameObject);
        }
    }
}
