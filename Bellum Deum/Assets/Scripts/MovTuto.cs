using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MovTuto : MonoBehaviour
{
    [SerializeField] private Transform _posX;
    [SerializeField] private bool _active;

    void Awake()
    {
        _active = true;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    if (_posX.position == new Vector3(0, 0, 0)) //VOLVER AL MENU
        //    {
        //        SceneManager.LoadScene("EscenaDiegoTitulo");
        //    }
        //    else //IR IZQ
        //    {
        //        _posX.position += new Vector3(1920, 0, 0);
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (_posX.position == new Vector3(9600, 0, 0)) //PASAR AL JUEGO
        //    {
        //        SceneManager.LoadScene("Adrian");
        //    }
        //    else //IR DER
        //    {
        //        _posX.position -= new Vector3(1920, 0, 0);
        //    }
        //}

        if (_active == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_posX.localPosition == Vector3.zero) //VOLVER AL MENU
                {
                    SceneManager.LoadScene("EscenaDiegoTitulo");
                }
                else //IR IZQ
                {
                    float posFinal = _posX.position.x + 1920;
                    _posX.DOMoveX(posFinal, 0.65f);
                    DesctivarMov();
                }
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_posX.localPosition == new Vector3(-9600, 0, 0)) //PASAR AL JUEGO
                {
                    SceneManager.LoadScene("Adrian");
                }
                else //IR DER
                {
                    float posFinal = _posX.position.x - 1920;
                    _posX.DOMoveX(posFinal, 0.65f);
                    DesctivarMov();
                }
            }
        }
    }

    public void DesctivarMov()
    {
        _active = false;
        Invoke("ActivarMov", 0.75f);
    }

    public void ActivarMov()
    {
        _active = true;
    }
}
