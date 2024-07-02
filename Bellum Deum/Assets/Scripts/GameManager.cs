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

    #endregion

    public enum Players{
        Player1,
        Player2
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

        if(Players.Player1 == pEnded)
        {

            _crazyBarJ1.GetComponent<CrazyBarComponent>().changeTurn(pEnded);
            _advanceBarJ1.GetComponent<AdvanceBarComponent>().changeTurn(pEnded);

            _eventSystem.GetComponent<EventSystem>().firstSelectedGameObject = _startCardJ2;

            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J2_Input;

        }
        else
        {

            _crazyBarJ2.GetComponent<CrazyBarComponent>().changeTurn(pEnded);
            _advanceBarJ2.GetComponent<AdvanceBarComponent>().changeTurn(pEnded);

            _eventSystem.GetComponent<EventSystem>().firstSelectedGameObject = _startCardJ1;

            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J1_Input;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
