using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MenusManager : MonoBehaviour
{
    [SerializeField] private GameObject _eventSystem;
    [SerializeField] private GameObject _inputManager;

    [SerializeField] private GameObject _menuOpciones;
    [SerializeField] private GameObject _menuControles;
    [SerializeField] private GameObject _menuIconos;

    [SerializeField] private GameObject _botones;

    [SerializeField] private InputActionAsset _ControlJug_Input;

    [SerializeField] private GameObject _deckJ1;
    [SerializeField] private GameObject _deckJ2;

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
        }
        
    }

    public void Continuar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menuOpciones.SetActive(false);
            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _ControlJug_Input;
            _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J1");// o J2
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ1.transform.GetChild(0).gameObject);
        }
        
    }

    public void Controles(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menuControles.SetActive(true);
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ1.transform.GetChild(0).gameObject);
        }
        
    }

    public void Iconos(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menuIconos.SetActive(true);
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuIconos.transform.GetChild(0).gameObject);
        }
        
    }

    public void Sonido(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }
    }

    public void PantallaCompleta(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        }
    }

    public void Volver(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menuControles.SetActive(false);
            _menuIconos.SetActive(false);
        }
        
    }

    public void Salir(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }
    }
}
