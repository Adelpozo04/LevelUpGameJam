using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static GameManager;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;

    private float _tiempoPulsando = 0f;
    public float _tiempoNecesario = 3f;

    private bool _enterPulsado = false;

    public Vector2 _posCartaGuardada;

    private Button _botonSeleccionado;

    private Players _currentPlayer = Players.Player1;

    private void Start()
    {
        _botonSeleccionado = GetComponent<Button>();
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
                    }
                    else
                    {
                        _currentPlayer = Players.Player1;
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
    }

    public void GuardarCarta(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _botonSeleccionado.GetComponent<RectTransform>().localPosition = _posCartaGuardada;//posicion de carta guardada
        }
    }

    public void JugarCarta(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _botonSeleccionado.GetComponent<RectTransform>().localPosition += transform.up * 100 * Time.deltaTime;//posicion de carta jugada
        }
    }
}
