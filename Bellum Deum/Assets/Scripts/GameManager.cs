using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class GameManager : MonoBehaviour
{

    #region properties

    static private GameManager _instance;

    #endregion


    #region references

    [SerializeField] private GameObject _crazyBarJ1;
    [SerializeField] private GameObject _crazyBarJ2;
    [SerializeField] private GameObject _advanceBarJ1;
    [SerializeField] private GameObject _advanceBarJ2;

    [SerializeField] private InputActionAsset _J1_Input;
    [SerializeField] private InputActionAsset _J2_Input;

    [SerializeField] private GameObject _eventSystem;

    [SerializeField] private GameObject _startCardJ1;
    [SerializeField] private GameObject _startCardJ2;

    [SerializeField] private GameObject _cronoJ1;
    [SerializeField] private GameObject _cronoJ2;

    #endregion

    public enum Players{
        Player1,
        Player2
    }

    public enum CardStateValues
    {
        Guardado,
        Normal,
        Jugado
    }

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

    }

    public void EndTurn(Players pEnded)
    {
        Debug.Log("Entra en EndTurn");
        if(Players.Player1 == pEnded)
        {
            _cronoJ1.GetComponent<TimeManager>().enabled = false;
            _cronoJ2.GetComponent<TimeManager>().enabled = true;

            _crazyBarJ1.GetComponent<CrazyBarComponent>().changeTurn(pEnded);
            _advanceBarJ1.GetComponent<AdvanceBarComponent>().changeTurn(pEnded);

            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_startCardJ2);

            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J2_Input;
            Debug.Log("Entra en EndTurn Player1");
        }
        else
        {
            _cronoJ2.GetComponent<TimeManager>().enabled = false;
            _cronoJ1.GetComponent<TimeManager>().enabled = true;

            _crazyBarJ2.GetComponent<CrazyBarComponent>().changeTurn(pEnded);
            _advanceBarJ2.GetComponent<AdvanceBarComponent>().changeTurn(pEnded);

            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_startCardJ1);

            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J1_Input;
            Debug.Log("Entra en EndTurn Player2");
        }
    }

    public void TimeEnded(Players pEnded)
    {

        if(Players.Player1 == pEnded)
        {
            _crazyBarJ1.GetComponent<CrazyBarComponent>().startMuerteSubita();
        }
        else
        {
            _crazyBarJ2.GetComponent<CrazyBarComponent>().startMuerteSubita();
        }

    }

    public void CheckCardPlayed()
    {
        int crazyPoints;

        int advancePoints;

        //revision de puntos de cada carta
        //revision de efectos



    }

    public void EndGame(Players player, bool isWinner)
    {
        if(player == Players.Player1)
        {
            if (isWinner)
            {
                //victoria jugador 1
            }
            else
            {
                //victoria jugador 2
            }


        }
        else
        {

            if (isWinner)
            {
                //victoria jugador 2
            }
            else
            {
                //victoria jugador 1
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_startCardJ1);
        _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J1_Input;

        _cronoJ2.GetComponent<TimeManager>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
