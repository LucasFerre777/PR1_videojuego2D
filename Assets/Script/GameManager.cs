
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int vidas = 3;

    public static int puntos = 0;

    GameObject TextVidas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextVidas = GameObject.Find("TextVidas");
    }

    // Update is called once per frame
    void Update()
    {

        //vidas

        Debug.Log("Vidas: " + vidas);

        TextVidas.GetComponent<TextMeshProUGUI>().text = vidas.ToString();



        //puntos

        Debug.Log("Puntos: " + puntos);
    }
}
