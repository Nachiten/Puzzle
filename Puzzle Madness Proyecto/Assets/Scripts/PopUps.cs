﻿using UnityEngine;
using UnityEngine.UI;
using System;

public class PopUps : MonoBehaviour
{
    int popUpOpen = 0;
    int currentImage = 0;

    public Texture[] Textura;
    RawImage simbolo;

    GameObject botonNo;
    GameObject popUp;
    GameObject inputField;

    Text textoPrincipal;
    Text TextoBanner;
    Text inputFieldTexto;
    Text botonSiTexto;

    void Start()
    {
        popUp = GameObject.Find("Pop Up");
        botonNo = GameObject.Find("Boton No");
        inputField = GameObject.Find("URL Imagen");

        inputFieldTexto = GameObject.Find("TextoURL").GetComponent<Text>();
        TextoBanner = GameObject.Find("Texto Banner").GetComponent<Text>();
        botonSiTexto = GameObject.Find("BotonSiTexto").GetComponent<Text>();
        textoPrincipal = GameObject.Find("Texto Principal").GetComponent<Text>();

        simbolo = GameObject.Find("Icono").GetComponent<RawImage>();


        inputField.SetActive(false);
        popUp.SetActive(false);
        
    }

    public void abrirPopUp(int num) {

        popUpOpen = num;
        popUp.SetActive(true);
        botonNo.SetActive(false);

        currentImage = 0;

        botonSiTexto.text = "Ok";

        switch (num)
        {
        case 1:
            TextoBanner.text = "Respetar Orden";
            textoPrincipal.text = "Debes seleccionar primero una imagen y luego un tamaño antes de comenzar.";

            break;
        case 2:
            TextoBanner.text = "Respetar Orden";
            textoPrincipal.text = "Debes primero seleccionar una imagen antes de seleccionar el tamaño.";
                
            break;
        case 3:
            botonNo.SetActive(true);
            
            TextoBanner.text = "Respetar Orden";
            textoPrincipal.text = "Para cambiar el tamaño que ya fue elegido previamente se debe reiniciar el nivel en este momento.";
            botonSiTexto.text = "Si";

            break;
        case 4:
            inputField.SetActive(true);

            currentImage = 3;
            TextoBanner.text = "Seleccionar imagen a usar [Se recomienda el sitio imgur.com]";
            textoPrincipal.text = "Por favor ingresar el link de una imagen en uno de los siguientes formatos:         .PNG .JPG .JPEG.";
            botonSiTexto.text = "Listo";

            break;
        case 5:
            currentImage = 1;
            TextoBanner.text = "Seleccionar Imagen Correcta";
            textoPrincipal.text = "Debes seleccionar una imagen valida en formato .PNG .JPG o .JPEG.";
           
            break;
        }

        simbolo.texture = Textura[currentImage];
    }

    public void cerrarPopUp( bool boton) // TRUE = si FALSE = no
    {
        string path = "";

        popUp.SetActive(false);

        switch (popUpOpen)
        {
            case 3:
                if (boton) FindObjectOfType<LevelLoader>().cargarNivel(6);
                
                break;
            case 4:
                path = (inputFieldTexto.text).ToString();

                if (path != "" && ( path.Substring(Math.Max(0, path.Length - 4)) == ".png" || path.Substring(Math.Max(0, path.Length - 4)) == ".jpg" || path.Substring(Math.Max(0, path.Length - 4)) == "jpeg") )
                    FindObjectOfType<CustomLevel>().asignTexture();
                else
                    abrirPopUp(5);
                
                break;
        }

        inputField.SetActive(false);
        popUpOpen = 0;
    }
}