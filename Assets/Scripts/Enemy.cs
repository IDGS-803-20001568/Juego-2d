using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D body2D;
    private bool movingRight = true;

    // Referencias para la detecci�n de colisi�n
    public Transform sightStart, sightEnd;
    public LayerMask solidLayer;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento hacia adelante en funci�n de la direcci�n
        body2D.velocity = new Vector2(movingRight ? -1 : 1, 0) * speed;

        // Detectar colisi�n en el frente del enemigo para cambiar direcci�n
        DetectarColision();
    }

    private void DetectarColision()
    {
        // Hacer una Linecast entre sightStart y sightEnd para detectar colisiones
        bool collision = Physics2D.Linecast(sightStart.position, sightEnd.position, solidLayer);

        // Dibujar la l�nea en el editor para depuraci�n
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (collision)
        {
            // Si hay colisi�n, cambiar de direcci�n
            CambiarDireccion();
        }
    }

    private void CambiarDireccion()
    {
        // Invertir la direcci�n
        movingRight = !movingRight;

        // Voltear el enemigo en el eje X para que "d� la vuelta" visualmente
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
