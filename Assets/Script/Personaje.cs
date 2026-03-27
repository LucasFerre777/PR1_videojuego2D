
using UnityEngine;
using UnityEngine.InputSystem;

public class Personaje : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float impulsoSalto = 5;

    Rigidbody2D rb;

    public Vector3 inicioPersonaje = new Vector3(1,1,0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        this.transform.position = inicioPersonaje;

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //caminar izquierda - derecha
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        this.transform.Translate(moveInput.x*velocidad, 0 , 0);

        //moveinput.x = (-1:A) (1:D)
        //Flipear al caminar

        if(moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(moveInput.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        //Saltar

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if(salto == true)
        {
            Debug.Log("salto");
            rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
        }

    }

}

