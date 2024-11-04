using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugadorArea : MonoBehaviour
{
    public float radioBusqueda;           // Radio de búsqueda para detectar al jugador
    public LayerMask capaJugador;         // Capa del jugador
    public Transform transformJugador;     // Transform del jugador
    public float velocidadMovimiento;      // Velocidad a la que se moverá el enemigo

    private void Update()
    {
        // Verifica si el jugador está dentro del radio de búsqueda
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
            MoverHaciaJugador(); // Llama al método para mover hacia el jugador
        }
    }

    // Método para mover al enemigo hacia el jugador
    private void MoverHaciaJugador()
    {
        // Calcula la dirección hacia el jugador
        Vector2 direccion = (transformJugador.position - transform.position).normalized;

        // Mueve el enemigo en la dirección del jugador
        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);
    }

    // Método para dibujar el área de búsqueda en el editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
    }
}
