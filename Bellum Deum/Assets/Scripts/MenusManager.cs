using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEditor;
using static GameManager;

public class MenusManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private GameObject _eventSystem;
    [SerializeField] private GameObject _inputManager;

    [SerializeField] private GameObject _menuOpciones;
    [SerializeField] private GameObject _menuControles;
    [SerializeField] private GameObject _menuIconos;

    [SerializeField] private GameObject _botones;

    [SerializeField] private InputActionAsset _ControlJug_Input;

    [SerializeField] private GameObject _deckJ1;
    [SerializeField] private GameObject _deckJ2;

    [SerializeField] private GameObject _cronoJ1;
    [SerializeField] private GameObject _cronoJ2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AbrirMenuOpciones(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menuOpciones.SetActive(true);
            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _ControlJug_Input;
            _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botones.transform.GetChild(0).gameObject);

            _inputManager.GetComponent<InputManager>().CambiarEstadoMenu();

            _cronoJ1.GetComponent<TimeManager>().enabled = false;
            _cronoJ2.GetComponent<TimeManager>().enabled = false;
        }
    }

    public void Continuar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menuOpciones.SetActive(false);
            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _ControlJug_Input;
            _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J1");

            _inputManager.GetComponent<InputManager>().CambiarEstadoMenu();

            if (_inputManager.GetComponent<InputManager>()._currentPlayer == Players.Player1)
            {
                Debug.Log("es j1");
                _cronoJ1.GetComponent<TimeManager>().enabled = true;
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ1.transform.GetChild(0).gameObject);
            }
            else
            {
                Debug.Log("es j2");
                _cronoJ2.GetComponent<TimeManager>().enabled = true;
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ2.transform.GetChild(0).gameObject);
            }

            _menuControles.SetActive(false);
            _menuIconos.SetActive(false);
        }
    }

    public void Controles()
    {
        _menuControles.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuControles.transform.GetChild(2).gameObject);
        
        
    }

    public void Iconos()
    {
        _menuIconos.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuIconos.transform.GetChild(2).gameObject);      
    }

    public void Sonido()
    {
        
    }

    public void PantallaCompleta()
    {
        
    }

    public void Volver()
    {
        _menuControles.SetActive(false);
        _menuIconos.SetActive(false);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botones.transform.GetChild(0).gameObject);
    }

    public void LlamadaContinuar()
    {
        _menuOpciones.SetActive(false);
        _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _ControlJug_Input;
        _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J1");

        _inputManager.GetComponent<InputManager>().CambiarEstadoMenu();

        if (_inputManager.GetComponent<InputManager>()._currentPlayer == Players.Player1)
        {
            Debug.Log("es j1");
            _cronoJ1.GetComponent<TimeManager>().enabled = true;
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ1.transform.GetChild(0).gameObject);
        }
        else
        {
            Debug.Log("es j2");
            _cronoJ2.GetComponent<TimeManager>().enabled = true;
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ2.transform.GetChild(0).gameObject);
        }

        _menuControles.SetActive(false);
        _menuIconos.SetActive(false);
    }

    //public void Salir()
    //{
    //    if (/*_currentScene == nombre de la escena de juego*/)
    //    {
    //        SceneManager.LoadScene(""/*"nombre de la escena inicial"*/);
    //    }
    //    else
    //    {
    //        Application.Quit();
    //    }
    //}

    //public void EscPorEscenas(InputAction.CallbackContext context)
    //{
    //    if (/*_currentScene == nombre de la escena de juego*/)
    //    {
    //        AbrirMenuOpciones(context);
    //    }
    //}
}
