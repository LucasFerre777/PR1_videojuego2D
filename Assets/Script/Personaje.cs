
using UnityEngine;
using UnityEngine.InputSystem;

public class Personaje : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float impulsoSalto = 5;
    public GameObject senyal;
    GameObject respawn;

    bool puedoSaltar = false;

    Rigidbody2D rb;

    Animator controlAnimacion;

    public Vector3 inicioPersonaje = new Vector3(1,1,0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        this.transform.position = inicioPersonaje;

        rb = GetComponent<Rigidbody2D>();

        senyal = GameObject.Find("sign");

        senyal.SetActive(false);

        controlAnimacion = GetComponent<Animator>();

        respawn = GameObject.Find("respawn");

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

        //animacion caminado

        if(moveInput.x != 0)
        {
            controlAnimacion.SetBool("activaCamina", true);
        }
        else
        {
            controlAnimacion.SetBool("activaCamina", false);
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

    }

    // para hacer que un objeto cambie de estado cuando lo toca el pj

    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colision con: " + col.gameObject.name);

        if(col.gameObject.name == "ladrillo")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }

    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger con: " + col.gameObject.name);

        if(col.gameObject.name == "pincho")
        {
            GameManager.vidas -= 1;
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            transform.position = respawn.transform.position;
        }

        if(col.gameObject.name == "coin")
        {
            GameManager.puntos += 10;
            Destroy(col.gameObject, 0.3f);
        }
    }
    


    //Hacer que la moneda suba y desaparezca animandolo
    //descargar .net 10.0 (aun no se para que sirve)
    /*meter al script de coin:
     if(col.gameObject.name == "personaje")
        {
            GameManager.puntos += 10;
            gameObject.GetComponent<animator>().SetBool("obtenerCoin"), true); <- esto es para que la animacion idle dela coin pase a la nueva
            Destroy(this.gameObject, 0.3f);
        }
        recuerda eliminar esto de este script
        */


}

