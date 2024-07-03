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
                        _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
                        _currentPlayer = Players.Player2;
                        _contadorCartas = 0;
                        _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();
                    }
                    else
                    {
                        _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
                        _currentPlayer = Players.Player1;
                        _contadorCartas = 0;
                        _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();
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
                _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
                if (_contadorCartas > 0)
                {
                    _contadorCartas--;
                }
                else
                {
                    _contadorCartas = _deck1.transform.childCount - 1;
                }
                _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
                _contadorCartas = (_contadorCartas + 1) % (_deck1.transform.childCount);
                _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();
            }
        }

        if (_currentPlayer == Players.Player2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
                if (_contadorCartas > 0)
                {
                    _contadorCartas--;
                }
                else
                {
                    _contadorCartas = _deck2.transform.childCount - 1;
                }
                _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
                _contadorCartas = (_contadorCartas + 1) % (_deck2.transform.childCount);
                _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();
            }
        }
    }

    public void GuardarCarta(InputAction.CallbackContext context)
    {
        GameObject _carta;
        if (context.started)
        {
            if (_currentPlayer == Players.Player1)
            {
                _carta = _deck1.transform.GetChild(_contadorCartas).gameObject;
                if (_carta.GetComponent<CardState>().GetState() != GameManager.CardStateValues.Guardado)
                {
                    _carta.GetComponent<TweenManager>().MoveArriba();
                    _carta.GetComponent<CardState>().ChangeState(false);
                }
            }
            else
            {
                _carta = _deck2.transform.GetChild(_contadorCartas).gameObject;
                if (_carta.GetComponent<CardState>().GetState() != GameManager.CardStateValues.Guardado)
                {
                    _carta.GetComponent<TweenManager>().MoveAbajo();
                    _carta.GetComponent<CardState>().ChangeState(false);
                }
            }
        }
    }

    public void JugarCarta(InputAction.CallbackContext context)
    {
        GameObject _carta;
        if (context.started)
        {
            if (_currentPlayer == Players.Player1)
            {
                _carta = _deck1.transform.GetChild(_contadorCartas).gameObject;
                if (_carta.GetComponent<CardState>().GetState() != GameManager.CardStateValues.Jugado)
                {
                    _carta.GetComponent<TweenManager>().MoveAbajo();
                    _carta.GetComponent<CardState>().ChangeState(true);
                }
            }
            else
            {
                _carta = _deck2.transform.GetChild(_contadorCartas).gameObject;
                if (_carta.GetComponent<CardState>().GetState() != GameManager.CardStateValues.Jugado)
                {
                    _carta.GetComponent<TweenManager>().MoveArriba();
                    _carta.GetComponent<CardState>().ChangeState(true);
                }
            }
        }
            
    }
}
