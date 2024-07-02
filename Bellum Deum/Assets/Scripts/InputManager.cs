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

    public Vector2 _posCartaGuardada;

    private Button _botonSeleccionado;

    private void Start()
    {
        _botonSeleccionado = GetComponent<Button>();
    }

    void Update()
    {
        // Verifica si la tecla está siendo presionada
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            _tiempoPulsando += Time.deltaTime;

            if (_tiempoPulsando >= _tiempoNecesario)
            {
                GameManager.Instance.EndTurn(Players.Player1);//CAMBIAR TURNO
                _tiempoPulsando = 0.0f;
                Debug.Log("tiempo pulsando cumplido");
            }
        }
        else
        {
            _tiempoPulsando = 0.0f;
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
