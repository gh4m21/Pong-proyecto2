using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    // velocidad
public float velocidad=30.0f;

// contadores de goles
public int golesIzquierda = 0;
public int golesDerecha = 0;
private int cantGoles=0;

// fuente audio source
AudioSource fuenteDeAudio;

// clips de audio
public AudioClip audioGol, audioRaqueta, audioRebote, audioFin;

// cajas de texto de los contadores
public Text contadorIzquierda;
public Text contadorDerecha;
public Text textoResultado;

    // Start is called before the first frame update
    void Start()
    {
        
        // velocidad inicial hacia derecha
        GetComponent<Rigidbody2D>().velocity=Vector2.right*velocidad;

        // Recupero el componente audio source
        fuenteDeAudio = GetComponent<AudioSource>();

        // pongo los contadores a 0
        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();

        //Desactivo la caja de resultado
        textoResultado.enabled = false;
         
    }

    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    void OnCollisionEnter2D(Collision2D micolision)
    {
//Si la bola colisiona con la raqueta:
// micolision.gameObject es la raqueta
// micolision.transform.position es la posición de la raqueta

// si choca con la raqueta izquierda
if(micolision.gameObject.name=="Raqueta Izquierda")
{

int x = 1;
int y = direccionY(transform.position,micolision.transform.position);

// calculo direccion
Vector2 direccion = new Vector2(x,y);

// Aplico la velocidad
GetComponent<Rigidbody2D>().velocity=direccion*velocidad;

// Reproduzco el sonido de la raqueta
fuenteDeAudio.clip = audioRaqueta;
fuenteDeAudio.Play();
}

// si choca con la raqueta derecha
if(micolision.gameObject.name=="Raqueta Derecha")
{
int x = -1;
int y = direccionY(transform.position,micolision.transform.position);

// calculo direccion
Vector2 direccion = new Vector2(x,y);

// Aplico la velocidad
GetComponent<Rigidbody2D>().velocity=direccion*velocidad;

// Reproduzco el sonido de la raqueta
fuenteDeAudio.clip = audioRaqueta;
fuenteDeAudio.Play();
}

// para el sonido del rebote
if(micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo"){
    // Reproduzco el sonido del rebote
fuenteDeAudio.clip = audioRebote;
fuenteDeAudio.Play();
}

}

// Verifica si anota 5
bool comprobarFinal(){
    // Si la izquierda anota 5
    if(golesIzquierda==5){
          fuenteDeAudio.clip = audioFin;
        fuenteDeAudio.Play();
        // Escribo y muestro el resultado
        textoResultado.text = "Juzgador izquierda GANA! \n Espera un momentito por favor!";
        // Muestro el resultado
        textoResultado.enabled=true;
        // Time.timeScale=0;
        // StartCoroutine(Espera());
        return true;
    }else if(golesDerecha==5){
        fuenteDeAudio.clip = audioFin;
        fuenteDeAudio.Play();
        // Escribo y muestro el resultado
        textoResultado.text = "Juzgador derecha GANA! \n Espera un momentito por favor!";
        // Muestro el resultado
        textoResultado.enabled=true;
        // Time.timeScale=0; //pausa
        return true;
    }else{
        return false;
    }
}

// direccion y
    int direccionY(Vector2 posicionBola,Vector2 posicionRaqueta)
    {
        if(posicionBola.y > posicionRaqueta.y){
            return 1;
        } else if(posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }else
        {
            return 0;
        }
    }

    // Espera 3 segundos al fin de juego antes de ir al menu principal
    private IEnumerator Espera()
    {
         fuenteDeAudio.clip = audioFin;
        fuenteDeAudio.Play();
        yield return new WaitForSeconds(3f);
        // Time.timeScale = 1;
        // atras en el menu
        SceneManager.LoadScene("Inicio");
    }

    // Reinicio la posicion de la bola
    public void reiniciarBola(string direccion)
    {
        // posicion 0 de la bola
        transform.position = Vector2.zero;
        // Vector2.zero es lo mismo que new Vector2(0,0);

        // calcula cantidad de goles
        cantGoles = golesDerecha+golesIzquierda;
        if(cantGoles ==0){
            // velocidad inicial de la bola
            velocidad = 30+3f;
        }else if(cantGoles ==1){
            // velocidad inicial de la bola
            velocidad = 30+6f;
        }else if(cantGoles ==2){
            // velocidad inicial de la bola
            velocidad = 30+9f;
        }else if(cantGoles ==3){
            // velocidad inicial de la bola
            velocidad = 30+12f;
        }else if(cantGoles ==4){
            // velocidad inicial de la bola
            velocidad = 30+15f;
        }else if(cantGoles ==5){
            // velocidad inicial de la bola
            velocidad = 30+18f;
        }else if(cantGoles ==6){
            // velocidad inicial de la bola
            velocidad = 30+18f;
        }else if(cantGoles ==5){
            // velocidad inicial de la bola
            velocidad = 30+21f;
        }else if(cantGoles ==6){
            // velocidad inicial de la bola
            velocidad = 30+23f;
        }else if(cantGoles ==7){
            // velocidad inicial de la bola
            velocidad = 30+25f;
        }else if(cantGoles ==8){
            // velocidad inicial de la bola
            velocidad = 30+28f;
        }else if(cantGoles ==9){
            // velocidad inicial de la bola
            velocidad = 30+30f;
        }else if(cantGoles ==10){
            // velocidad inicial de la bola
            velocidad = 30+32f;
        }

        // velocidad y direccion
        if(direccion == "Derecha")
        {
            // Incremento goles al de la derecha
            golesDerecha++;
            // lo escribo en el marcador
            contadorDerecha.text = golesDerecha.ToString();
            //Reinicio la bola (si no ha llegado a 5)
            if (!comprobarFinal()){
                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
                //Vector2.right es lo mismo que new Vector2(1,0)
            }else{
                GetComponent<Rigidbody2D>().velocity = Vector2.right*0f;
                 StartCoroutine(Espera());
            }
        }else if(direccion=="Izquierda"){
            // Incremento goles al de la izquierda
            golesIzquierda++;
            // lo escribo en ell marcador
            contadorIzquierda.text = golesIzquierda.ToString();
            //Reinicio la bola (si no ha llegado a 5)
            if (!comprobarFinal()){
                GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
                //Vector2.left es lo mismo que new Vector2(-1,0)
            }else{
                fuenteDeAudio.clip = audioFin;
                fuenteDeAudio.Play();
                Debug.Log("audio played");
                GetComponent<Rigidbody2D>().velocity = Vector2.left*0f;
                 StartCoroutine(Espera());
            }
        }

        // Reproduzco el sonido del gol
        fuenteDeAudio.clip = audioGol;
        fuenteDeAudio.Play();

//         if(golesIzquierda==5){
//             SceneManager.LoadScene("Inicio");

// }

    }

    // Update is called once per frame
    void Update()
    {
    if(golesIzquierda==5||golesDerecha==5){
             fuenteDeAudio.clip = audioFin;
             fuenteDeAudio.Play();
        }
        // Regresa a la escena si un jugador anote 5 goles
        // Incremento la velocidad de la bola
        // velocidad = velocidad + 0.1f;
    }
}
