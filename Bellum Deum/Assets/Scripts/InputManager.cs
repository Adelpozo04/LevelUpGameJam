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
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject inputManager;

    private float _tiempoPulsando = 0f;
    public float _tiempoNecesario = 3f;

    private bool _enterPulsado = false;

    public Players _currentPlayer = Players.Player1;

    [SerializeField] private GameObject _deck1, _deck2;

    private int _contadorCartas = 0;

    public bool _active = true;

    public bool _menuOpcionesActive = false;

    private bool _cartaGuardada = false;

    private void Start()
    {
        
    }

    void Update()
    {
        if (_menuOpcionesActive == false)
        {
            if (!_enterPulsado)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    _tiempoPulsando += Time.deltaTime;

                    if (_tiempoPulsando >= _tiempoNecesario)
                    {
                        _enterPulsado = true;

                        CambioDeTurno();

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

        }
        
    }

    public void CambioDeTurno()
    {

        _cartaGuardada = false;

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

    }

    public void MoveLeftJ1(InputAction.CallbackContext context)
    {

        if (context.started)
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

    }

    public void MoveLeftJ2(InputAction.CallbackContext context)
    {

        if (context.started)
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

    }

    public void MoveRightJ1(InputAction.CallbackContext context)
    {

        if (context.started)
        {

            _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
            _contadorCartas = (_contadorCartas + 1) % (_deck1.transform.childCount);
            _deck1.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();

        }

    }

    public void MoveRightJ2(InputAction.CallbackContext context)
    {

        if (context.started)
        {

            _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().ReducirCartaDeseleccionada();
            _contadorCartas = (_contadorCartas + 1) % (_deck2.transform.childCount);
            _deck2.transform.GetChild(_contadorCartas).gameObject.GetComponent<TweenManager>().AumentarCartaSeleccionada();

        }

    }



    public void StartMatch(GameManager.Players p)
    {

        _currentPlayer = p;

    }

    public void MejorarFe(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameManager.Instance.MejoraFe(_currentPlayer);
        }
    }

    public void MejoraAvance(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameManager.Instance.MejoraAvance(_currentPlayer);
        }
    }

    public void GuardarCarta(InputAction.CallbackContext context)
    {
        if (_active == true)
        {
            GameObject _carta;
            if (context.started)
            {
                if (_currentPlayer == Players.Player1)
                {
                    
                    _carta = _deck1.transform.GetChild(_contadorCartas).gameObject;


                    if (_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Normal &&
                        !_cartaGuardada &&
                        GameManager.Instance.SaveCard(_carta.GetComponent<CardState>().GetStats(), _currentPlayer))
                    {
                        _cartaGuardada = true;
                        _carta.GetComponent<TweenManager>().MoveArriba();
                        _carta.GetComponent<CardState>().ChangeState(false);
                        DesctivarMovCarta();
                    }
                    else if(_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Jugado)
                    {
                        GameManager.Instance.CancelJugada(_carta.GetComponent<CardState>().GetStats(), _currentPlayer);
                        _carta.GetComponent<TweenManager>().MoveArriba();
                        _carta.GetComponent<CardState>().ChangeState(false);
                        DesctivarMovCarta();

                    }
                    

                }
                else
                {
                    _carta = _deck2.transform.GetChild(_contadorCartas).gameObject;

                    if (_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Normal && GameManager.Instance.SaveCard(_carta.GetComponent<CardState>().GetStats(), _currentPlayer))
                    {
                        _carta.GetComponent<TweenManager>().MoveAbajo();
                        _carta.GetComponent<CardState>().ChangeState(false);
                        DesctivarMovCarta();
                    }
                    else if (_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Jugado)
                    {
                        GameManager.Instance.CancelJugada(_carta.GetComponent<CardState>().GetStats(), _currentPlayer);
                        _carta.GetComponent<TweenManager>().MoveAbajo();
                        _carta.GetComponent<CardState>().ChangeState(false);
                        DesctivarMovCarta();

                    }


                }
            }
        }
    }

    public void JugarCarta(InputAction.CallbackContext context)
    {
        if (_active == true)
        {
            GameObject _carta;
            if (context.started)
            {
                if (_currentPlayer == Players.Player1)
                {
                    _carta = _deck1.transform.GetChild(_contadorCartas).gameObject;

                    if (_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Normal && GameManager.Instance.PlayCard(_carta.GetComponent<CardState>().GetStats(), _currentPlayer))
                    {
                        _carta.GetComponent<TweenManager>().MoveAbajo();
                        _carta.GetComponent<CardState>().ChangeState(true);
                        DesctivarMovCarta();
                    }
                    else if (_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Guardado)
                    {
                        _cartaGuardada = false;
                        GameManager.Instance.CancelGuardado(_carta.GetComponent<CardState>().GetStats(), _currentPlayer);
                        _carta.GetComponent<TweenManager>().MoveAbajo();
                        _carta.GetComponent<CardState>().ChangeState(true);
                        DesctivarMovCarta();

                    }

                }
                else
                {
                    _carta = _deck2.transform.GetChild(_contadorCartas).gameObject;

                    if (_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Normal && GameManager.Instance.PlayCard(_carta.GetComponent<CardState>().GetStats(), _currentPlayer))
                    {
                        _carta.GetComponent<TweenManager>().MoveArriba();
                        _carta.GetComponent<CardState>().ChangeState(true);
                        DesctivarMovCarta();
                    }
                    else if (_carta.GetComponent<CardState>().GetState() == GameManager.CardStateValues.Guardado)
                    {
                        GameManager.Instance.CancelGuardado(_carta.GetComponent<CardState>().GetStats(), _currentPlayer);
                        _carta.GetComponent<TweenManager>().MoveArriba();
                        _carta.GetComponent<CardState>().ChangeState(true);
                        DesctivarMovCarta();

                    }
                }
            }
        }
    }
    
    public void DesctivarMovCarta()
    {
        _active = false;
        Invoke("ActivarCarta", 0.6f);
    }

    public void ActivarCarta()
    {
        _active = true;
    }

    public void CambiarEstadoMenu()
    {
        if (_menuOpcionesActive == true)
        {
            _menuOpcionesActive = false;
        }
        else
        {
            _menuOpcionesActive = true;
        }
    }
}
