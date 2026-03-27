
using System.Runtime.InteropServices.Marshalling;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personaje : MonoBehaviour
{
    public float velocidad = 0.5f ;
    public Vector3 inicioPersonaje = new Vector3(1,1,0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        this.transform.position = inicioPersonaje;

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        this.transform.Translate(moveInput.x*velocidad,moveInput.y*velocidad, 0);
        

    }

}

