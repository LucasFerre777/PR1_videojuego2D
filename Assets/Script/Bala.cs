using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{

    public GameObject disparo; 

    GameObject Personaje;

    bool direccionPersonaje;

    public float velocidadBala = 0.05f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Personaje = GameObject.Find("Personaje");

        direccionPersonaje = Personaje.GetComponent<Personaje>().direcBalaDcha;



    }

    // Update is called once per frame
    void Update()
    {
       
       
       
       
        if (direccionPersonaje)
        {
            disparo.transform.Translate(velocidadBala,0,0);
            transform.Rotate(0,0,0.5f);
        }
        else
        {
            disparo.transform.Translate(velocidadBala*-1,0,0);
            transform.Rotate(0,0,-0.5f);
        }



       


    }
}
