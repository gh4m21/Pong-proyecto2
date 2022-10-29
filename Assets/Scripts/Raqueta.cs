using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    // velocidad
    public float velocidad = 30.0f;

    // eje vertical
    public string eje;
    public string horizontal;
    public GameObject raquetaIzquierda;
    public GameObject raquetaDerecha;

// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
void FixedUpdate()
{
    // capto el valor del eje vertical de la raqueta
    float v = Input.GetAxisRaw(eje);

    // capto el valor horizontal de la raqueta
    float h = Input.GetAxisRaw(horizontal);

    // modifico la velocidad de la raqueta
    if(v!=0){
         GetComponent<Rigidbody2D>().velocity=new Vector2(0,v*velocidad);
    }else {
            GetComponent<Rigidbody2D>().velocity=new Vector2(h*velocidad,0);
    }
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
