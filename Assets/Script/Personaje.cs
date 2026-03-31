
using UnityEngine;
using UnityEngine.InputSystem;

public class Personaje : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float impulsoSalto = 5;
    public GameObject senyal;

    bool puedoSaltar = false;

    Rigidbody2D rb;

    public Vector3 inicioPersonaje = new Vector3(1,1,0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        this.transform.position = inicioPersonaje;

        rb = GetComponent<Rigidbody2D>();

        senyal = GameObject.Find("sign");

        senyal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        //caminar izquierda - derecha
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        this.transform.Translate(moveInput.x*velocidad, 0 , 0);


        //Flipear al caminar

        if(moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(moveInput.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        //Esto para que al saltar determine donde está el suelo desde el personaje con un rayo


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down*0.5f, Color.red);

        if(hit.collider == true)
        {
            puedoSaltar = true;
        }
        else
        {
            puedoSaltar = false;
        }

        Debug.Log(puedoSaltar);

        //Saltar

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if(salto == true && puedoSaltar == true)
        {
            rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
        }

        
        //Cualquier cambio de estado durante el salto:

        if(puedoSaltar == true)
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            senyal.SetActive(false);

        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            senyal.SetActive(true);

        }

        //Disparar

        bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

        if (disparo)
        {
            Instantiate(senyal, new Vector3 (0,0,0), Quaternion.identity);
        }

    }

}

