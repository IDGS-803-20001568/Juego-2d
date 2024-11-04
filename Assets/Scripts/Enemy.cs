using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D body2D;
    private bool movingRight = true;

    // Referencias para la detección de colisión
    public Transform sightStart, sightEnd;
    public LayerMask solidLayer;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento hacia adelante en función de la dirección
        body2D.velocity = new Vector2(movingRight ? -1 : 1, 0) * speed;

        // Detectar colisión en el frente del enemigo para cambiar dirección
        DetectarColision();
    }

    private void DetectarColision()
    {
        // Hacer una Linecast entre sightStart y sightEnd para detectar colisiones
        bool collision = Physics2D.Linecast(sightStart.position, sightEnd.position, solidLayer);

        // Dibujar la línea en el editor para depuración
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (collision)
        {
            // Si hay colisión, cambiar de dirección
            CambiarDireccion();
        }
    }

    private void CambiarDireccion()
    {
        // Invertir la dirección
        movingRight = !movingRight;

        // Voltear el enemigo en el eje X para que "dé la vuelta" visualmente
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
