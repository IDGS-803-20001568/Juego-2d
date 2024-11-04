using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugadorArea : MonoBehaviour
{
    public float radioBusqueda;           // Radio de b�squeda para detectar al jugador
    public LayerMask capaJugador;         // Capa del jugador
    public Transform transformJugador;     // Transform del jugador
    public float velocidadMovimiento;      // Velocidad a la que se mover� el enemigo

    private void Update()
    {
        // Verifica si el jugador est� dentro del radio de b�squeda
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
            MoverHaciaJugador(); // Llama al m�todo para mover hacia el jugador
        }
    }

    // M�todo para mover al enemigo hacia el jugador
    private void MoverHaciaJugador()
    {
        // Calcula la direcci�n hacia el jugador
        Vector2 direccion = (transformJugador.position - transform.position).normalized;

        // Mueve el enemigo en la direcci�n del jugador
        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);
    }

    // M�todo para dibujar el �rea de b�squeda en el editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
    }
}
