using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public event EventHandler MuerteJugador;
    public int health = 3;

    public RectTransform heartUI;

    private float heartSize = 16f;

    public TextMeshProUGUI textLifeCount;

    private Explode explode;

    void Start()
    {
        explode = GetComponent<Explode>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health -= 1;
            if (health == 0)
            {
                // Invocamos el evento de muerte antes de destruir el objeto
                MuerteJugador?.Invoke(this, EventArgs.Empty);

                // Llamamos a la animación de explosión
                explode.OnExplode();

                // Destruimos el objeto del jugador después
                Destroy(gameObject);
            }

            // Actualizamos la interfaz de vida
            heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
            textLifeCount.text = health.ToString();
        }

        if (collision.tag == "Life")
        {
            Destroy(collision.gameObject);
            health = Mathf.Min(health + 1, 3); // Limitamos la vida máxima a 3
            heartUI.sizeDelta = new Vector2(heartSize * health, heartUI.sizeDelta.y);
            textLifeCount.text = health.ToString();
        }
    }
    public void TakeFatalDamage()
    {
        MuerteJugador?.Invoke(this, EventArgs.Empty);
        explode.OnExplode();
        Destroy(gameObject);
    }

}
