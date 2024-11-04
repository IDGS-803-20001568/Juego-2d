using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitVideogame()
    {
        Application.Quit();
        Debug.Log("Salimos del juego");
    }
}
