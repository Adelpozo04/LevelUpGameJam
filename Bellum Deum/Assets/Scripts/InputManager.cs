using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using static GameManager;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;

    private float _tiempoPulsando = 0f;
    public float _tiempoNecesario = 3f;

    private bool _enterPulsado = false;

    private Players _currentPlayer = Players.Player1;

    [SerializeField] private GameObject _deck1, _deck2;

    private int _contadorCartas = 0;

    private void Start()
    {
        
    }

    void Update()
    {
        if (!_enterPulsado)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                _tiempoPulsando += Time.deltaTime;

                if (_tiempoPulsando >= _tiempoNecesario)
                {
                    _enterPulsado = true;
                    GameManager.Instance.EndTurn(_currentPlayer);
                    if (_currentPlayer == Players.Player1)
                    {
                        _currentPlayer = Players.Player2;
                        _contadorCartas = 0;
                    }
                    else
                    {
                        _currentPlayer = Players.Player1;
                        _contadorCartas = 0;
                    }
                    _tiempoPulsando = 0.0f;
                    Debug.Log("tiempo pulsando cumplido");
                }
            }
            else
            {
                _tiempoPulsando = 0.0f;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                _enterPulsado = false;
            }
        }

        if (_currentPlayer == Players.Player1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_contadorCartas > 0)
                {
                    _contadorCartas--;
                }
                else
                {
                    _contadorCartas = _deck1.transform.GetChildCount() - 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _contadorCartas = (_contadorCartas + 1) % (_deck1.transform.GetChildCount());
            }
        }

        if (_currentPlayer == Players.Player2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_contadorCartas > 0)
                {
                    _contadorCartas--;
                }
                else
                {
                    _contadorCartas = _deck2.transform.GetChildCount() - 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _contadorCartas = (_contadorCartas + 1) % (_deck2.transform.GetChildCount());
            }
        }
    }

    public void GuardarCarta(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Llega");
            if (_currentPlayer == Players.Player1)
            {
                _deck1.transform.GetChild(_contadorCartas).GetComponent<TweenManager>().MoveArriba();
            }
            else
            {
                _deck2.transform.GetChild(_contadorCartas).GetComponent<TweenManager>().MoveAbajo();
            }
        }
    }

    public void JugarCarta(InputAction.CallbackContext context)
    {
        if (_currentPlayer == Players.Player1)
        {
            _deck1.transform.GetChild(_contadorCartas).GetComponent<TweenManager>().MoveAbajo();
        }
        else
        {
            _deck2.transform.GetChild(_contadorCartas).GetComponent<TweenManager>().MoveArriba();
        }
    }
}
