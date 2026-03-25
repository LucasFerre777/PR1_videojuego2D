
using UnityEngine;

public class Personaje : MonoBehaviour
{

    int miNumero = 1;

    float miNumeroFlotante = 0.8f;

    string miCadenaDeTexto = "Hola, esto es una cadena de texto";

    bool miBoolean = true;


    public Vector3 inicioPersonaje = new Vector3(1,1,0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SumaEntreDecenas = Sumar(10,20,3.8f);

        Debug.Log(this.transform.position.x);
        Debug.Log(SumaEntreDecenas);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hola");

        /*
        if(miVida == 3 && miVida >= 0 && miNumeroFlotante == 0.8f)
        {
            Debug.Log("Estoy vivo")
        }
        else
        {
            Debug.Log("Estoy muerto")
        }
        */
    }
  

    float Sumar(int num1, int num2, float num3)
    {
        
        float suma = num1 + num2 + num3;

        return suma;
    }

    //Esto es un mensaje para los humanos

    /*
    todo esto
    tambien es un mensaje
    para los humanos 
    */
    
}

