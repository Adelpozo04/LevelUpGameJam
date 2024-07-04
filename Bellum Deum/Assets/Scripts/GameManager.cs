using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
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

    [SerializeField] private GameObject _eventSystem;

    [SerializeField] private InputActionAsset _J1_Input;
    [SerializeField] private InputActionAsset _J2_Input;

    [SerializeField] private GameObject _deckJ1;
    [SerializeField] private GameObject _deckJ2;

    [SerializeField] private GameObject _cronoJ1;
    [SerializeField] private GameObject _cronoJ2;

    [SerializeField] private FeComponent _feJ1;
    [SerializeField] private FeComponent _feJ2;

    [SerializeField] private CardManager _cardManager;
    [SerializeField] private GameObject _inputManager;

    [SerializeField] private GameObject _flipCoin;

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
    public enum CardType { 
        Ataque,
        Mejora,
        Estado
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
            AttackPlayerCalculation(Players.Player1);

            StartTurnPlayer(Players.Player2);   
        }
        else
        {
            AttackPlayerCalculation(Players.Player2);

            StartTurnPlayer(Players.Player1);
        }
    }

    private void StartTurnPlayer(Players p)
    {
        if(p == Players.Player1)
        {
            Debug.Log("empieza el 1");

            //Cambio tiempo cronos
            _cronoJ2.GetComponent<TimeManager>().enabled = false;
            _cronoJ1.GetComponent<TimeManager>().enabled = true;

            //Se aplican efectos a las barras
            _crazyBarJ2.GetComponent<CrazyBarComponent>().changeTurn(Players.Player2);
            _advanceBarJ2.GetComponent<AdvanceBarComponent>().changeTurn(Players.Player2);

            //Se cambia la carta de comienzo
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ1.transform.GetChild(0).gameObject);

            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J1_Input;
            _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J1");

            _feJ1.RestartFe();

            AssignCards(Players.Player1);
        }
        else
        {
            Debug.Log("empieza el 2");

            //Cambio tiempo cronos
            _cronoJ1.GetComponent<TimeManager>().enabled = false;
            _cronoJ2.GetComponent<TimeManager>().enabled = true;

            //Se aplican efectos a las barras
            _crazyBarJ1.GetComponent<CrazyBarComponent>().changeTurn(Players.Player1);
            _advanceBarJ1.GetComponent<AdvanceBarComponent>().changeTurn(Players.Player1);

            //Se cambia la carta de comienzo
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ2.transform.GetChild(0).gameObject);

            _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J2_Input;
            _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J2");

            _feJ2.RestartFe();

            AssignCards(Players.Player2);
        }
    }

    private void AssignCards(Players currentPlayer)
    {

        if(currentPlayer == Players.Player1)
        {

            for (int i = 0; i < _deckJ1.transform.childCount; i++)
            {
                _deckJ1.transform.GetChild(i).gameObject.GetComponent<CardState>().AddCardStats(_cardManager.AskCard());
            }

        }
        else
        {

            for (int i = 0; i < _deckJ2.transform.childCount; i++)
            {
                _deckJ2.transform.GetChild(i).gameObject.GetComponent<CardState>().AddCardStats(_cardManager.AskCard());
            }

        }

    }

    private void AttackPlayerCalculation(GameManager.Players p)
    {

        CardType typeCard;

        int crazy = 0;

        int avance = 0;

        int ownCrazy = 0;

        int ownAvance = 0;

        int turnsEffect = 0;

        if(p == Players.Player1)
        {

            for(int i = 0; i < _deckJ1.transform.childCount; ++i)
            {

                GameObject card = _deckJ1.transform.GetChild(i).gameObject;

                if(card.GetComponent<CardState>().GetState() == CardStateValues.Jugado)
                {
                    Carta cardStats = card.GetComponent<CardState>().GetStats();

                    typeCard = cardStats.tipo_carta;

                    crazy += cardStats.locura;

                    avance += cardStats.avance;

                    if (typeCard == CardType.Ataque)
                    {

                        

                        ownCrazy += cardStats.locura_propia;

                        ownAvance += cardStats.avance_propio;

                        _crazyBarJ2.GetComponent<CrazyBarComponent>().IncreaseCrazy(crazy);

                        _advanceBarJ2.GetComponent<AdvanceBarComponent>().DecreaseAdvance(avance);

                        _crazyBarJ1.GetComponent<CrazyBarComponent>().IncreaseCrazy(ownCrazy);

                        _advanceBarJ1.GetComponent<AdvanceBarComponent>().DecreaseAdvance(ownAvance);

                    }
                    else if(typeCard == CardType.Mejora)
                    {

                        Debug.Log("Aumento de resistencia");

                        turnsEffect = cardStats.num_turnos;

                        _crazyBarJ1.GetComponent<CrazyBarComponent>().addResistence(crazy, turnsEffect);

                        _advanceBarJ1.GetComponent<AdvanceBarComponent>().addResistence(avance, turnsEffect);
                    }
                    

                    

                    
                }

            }

        }
        else
        {

            for (int i = 0; i < _deckJ2.transform.childCount; ++i)
            {

                GameObject card = _deckJ2.transform.GetChild(i).gameObject;

                if (card.GetComponent<CardState>().GetState() == CardStateValues.Jugado)
                {
                    Carta cardStats = card.GetComponent<CardState>().GetStats();

                    typeCard = cardStats.tipo_carta;

                    crazy += cardStats.locura;

                    avance += cardStats.avance;

                    if (typeCard == CardType.Ataque)
                    {       

                        ownCrazy += cardStats.locura_propia;

                        ownAvance += cardStats.avance_propio;

                        _crazyBarJ1.GetComponent<CrazyBarComponent>().IncreaseCrazy(crazy);

                        _advanceBarJ1.GetComponent<AdvanceBarComponent>().DecreaseAdvance(avance);

                        _crazyBarJ2.GetComponent<CrazyBarComponent>().IncreaseCrazy(ownCrazy);

                        _advanceBarJ2.GetComponent<AdvanceBarComponent>().DecreaseAdvance(ownAvance);

                    }
                    else if (typeCard == CardType.Mejora)
                    {

                        Debug.Log("Aumento de resistencia");

                        turnsEffect = cardStats.num_turnos;

                        _crazyBarJ1.GetComponent<CrazyBarComponent>().addResistence(crazy, turnsEffect);

                        _advanceBarJ1.GetComponent<AdvanceBarComponent>().addResistence(avance, turnsEffect);
                    }


                }

            }

        }

    }

    public bool PlayCard(Carta card, Players p)
    {
        if(p == Players.Player1)
        {
            return _feJ1.UseFe(card.cost_fe);
        }
        else
        {
            return _feJ2.UseFe(card.cost_fe);
        }
        
    }

    public bool SaveCard(Carta card, Players p)
    {

        if (p == Players.Player1)
        {
            return _feJ1.UseFe(Mathf.CeilToInt(card.cost_fe / 2.0f));
        }
        else
        {
            return _feJ2.UseFe(Mathf.CeilToInt(card.cost_fe / 2.0f));
        }

    }

    public void CancelJugada(Carta card, Players p)
    {

        if (p == Players.Player1)
        {
            _feJ1.RestoreFe(card.cost_fe);
        }
        else
        {
            _feJ2.RestoreFe(card.cost_fe);
        }

    }

    public void CancelGuardado(Carta card, Players p)
    {

        if (p == Players.Player1)
        {
            _feJ1.RestoreFe(Mathf.CeilToInt(card.cost_fe / 2.0f));
        }
        else
        {
            _feJ2.RestoreFe(Mathf.CeilToInt(card.cost_fe / 2.0f));
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

    public void StartMatch(Players starter)
    {

        _inputManager.SetActive(true);

        _inputManager.GetComponent<InputManager>().StartMatch(starter);

        _cronoJ1.SetActive(true);

        _cronoJ2.SetActive(true);

        _flipCoin.SetActive(false);

        if (starter == Players.Player1) 
        {

            StartTurnPlayer(Players.Player1);

        }
        else
        {

            StartTurnPlayer(Players.Player2);

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        _inputManager.SetActive(false);

        _cronoJ1.SetActive(false);

        _cronoJ2.SetActive(false);

        _flipCoin.GetComponent<FlipCoin>().StartSelection();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
