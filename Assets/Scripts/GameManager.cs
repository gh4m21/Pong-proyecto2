using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // fuente audio source
    AudioSource fuenteDeAudio;

    public AudioClip audioInicio;
    // Start is called before the first frame update
    void Start()
    {
        // Recupero el componente audio source
        fuenteDeAudio = GetComponent<AudioSource>();

        fuenteDeAudio.clip = audioInicio;
        fuenteDeAudio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        // Si pulsa la tecla P o hace clic izquierdo empieza el juego
        if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0)){
            // cargo la escena de juego
            // Nombre de la sccene del juego, en mi caso es Juego
            SceneManager.LoadScene("Juego");
        }
    }
}
