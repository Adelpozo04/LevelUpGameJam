using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject _menuNormasCartas;
    [SerializeField] private GameObject _menuNormasFe;
    [SerializeField] private GameObject _menuNormasBarras;
    [SerializeField] private GameObject _menuNormasMejoras;

    [SerializeField] private GameObject _botones;
    [SerializeField] private GameObject _botonesNormas;
    [SerializeField] private GameObject _botonesInicio;

    [SerializeField] private InputActionAsset _ControlJug_Input;

    [SerializeField] private GameObject _deckJ1;
    [SerializeField] private GameObject _deckJ2;

    [SerializeField] private GameObject _cronoJ1;
    [SerializeField] private GameObject _cronoJ2;

    private Scene m_Scene;
    private string sceneName;

    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
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

    public void LlamadaAbrirMenuOpciones()
    {
        _menuOpciones.SetActive(true);
        _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _ControlJug_Input;
        _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botones.transform.GetChild(0).gameObject);

        _inputManager.GetComponent<InputManager>().CambiarEstadoMenu();
    }

    public void Continuar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menuOpciones.SetActive(false);
            _menuControles.SetActive(false);
            _menuIconos.SetActive(false);
            _menuNormasCartas.SetActive(false);
            _menuNormasFe.SetActive(false);
            _menuNormasBarras.SetActive(false);
            _menuNormasMejoras.SetActive(false);
            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _ControlJug_Input;
            _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J1");

            _inputManager.GetComponent<InputManager>().CambiarEstadoMenu();

            if (sceneName == "EscenaDiegoTitulo")
            {
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botonesInicio.transform.GetChild(0).gameObject);
            }

            if (sceneName == "EscenaDiego")
            {
                if (_inputManager.GetComponent<InputManager>()._currentPlayer == Players.Player1)
                {
                    _cronoJ1.GetComponent<TimeManager>().enabled = true;
                    UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ1.transform.GetChild(0).gameObject);
                }
                else
                {
                    _cronoJ2.GetComponent<TimeManager>().enabled = true;
                    UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ2.transform.GetChild(0).gameObject);
                }
            }

            _menuControles.SetActive(false);
            _menuIconos.SetActive(false);
        }
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

    public void LlamadaContinuarInicio()
    {
        _menuOpciones.SetActive(false);

        _inputManager.GetComponent<InputManager>().CambiarEstadoMenu();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botonesInicio.transform.GetChild(1).gameObject);

        _menuControles.SetActive(false);
        _menuIconos.SetActive(false);
    }

    public void Controles()
    {
        _menuOpciones.SetActive(true);
        _menuControles.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuControles.transform.GetChild(3).gameObject);
    }

    public void Iconos()
    {
        _menuOpciones.SetActive(true);
        _menuIconos.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botonesNormas.transform.GetChild(0).gameObject);
    }

    public void NormasCartas()
    {
        _menuNormasCartas.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuNormasCartas.transform.GetChild(3).gameObject);
    }

    public void NormasFe()
    {
        _menuNormasFe.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuNormasFe.transform.GetChild(3).gameObject);
    }

    public void NormasBarras()
    {
        _menuNormasBarras.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuNormasBarras.transform.GetChild(3).gameObject);
    }

    public void NormasMejoras()
    {
        _menuNormasMejoras.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_menuNormasMejoras.transform.GetChild(3).gameObject);
    }

    public void Volver()
    {
        _menuControles.SetActive(false);
        _menuIconos.SetActive(false);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botones.transform.GetChild(0).gameObject);
    }

    public void VolverANormas()
    {
        _menuIconos.SetActive(true);
        _menuControles.SetActive(false);
        _menuNormasCartas.SetActive(false);
        _menuNormasFe.SetActive(false);
        _menuNormasBarras.SetActive(false);
        _menuNormasMejoras.SetActive(false);

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botonesNormas.transform.GetChild(0).gameObject);
    }

    public void VolverInicio()
    {
        _menuOpciones.SetActive(false);
        _menuControles.SetActive(false);
        _menuIconos.SetActive(false);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_botonesInicio.transform.GetChild(0).gameObject);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("EscenaDiegoJuego");
    }

    public void SalirAInicio()
    {
        SceneManager.LoadScene("EscenaDiegoTitulo");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
