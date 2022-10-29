using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porteria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    void OnTriggerEnter2D(Collider2D bola)
    {
        if(bola.name == "Bola")
        {
            // si esla porteria izquierda
            if(this.name == "Izquierda")
            {
                // Cuento el gol y reinicio la bola
                bola.GetComponent<Bola>().reiniciarBola("Derecha");
            }
            // Si es la porteria derecha
            else if (this.name == "Derecha")
            {
                // cuento el gol y reinicio la bola
                bola.GetComponent<Bola>().reiniciarBola("Izquierda");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
