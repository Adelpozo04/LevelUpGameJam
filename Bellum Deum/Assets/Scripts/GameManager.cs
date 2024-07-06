using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class GameManager : MonoBehaviour
{


    #region properties

    static private GameManager _instance;
    private int _mejorafe1 = 0;
    private int _mejorafe2=0;
    private int _mejoraavan1 = 0;
    private int _mejoraavan2 = 0;
    private bool _mejorahecha = false;



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

    [SerializeField] private ParticleSystem _particulasJ1;
    [SerializeField] private ParticleSystem _particulasJ2;

    [SerializeField] private FeComponent _feJ1;
    [SerializeField] private FeComponent _feJ2;

    [SerializeField] private CardManager _cardManager;
    [SerializeField] private GameObject _inputManager;

    [SerializeField] private GameObject _flipCoin;

    [SerializeField] private GameObject _J1Shield;
    [SerializeField] private GameObject _J2Shield;

    [SerializeField] private GameObject _victoryMenu;

    [SerializeField] private int[] _turnsCurrentEffectsJ1 = new int[8];
    [SerializeField] private int[] _turnsCurrentEffectsJ2 = new int[8];

    [SerializeField] private GameObject _mejoras1;
    [SerializeField] private GameObject _mejoras2;

    private bool _J1Start = false;
    private bool _J2Start = false;


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

    public enum Effects
    {
        SaltarTurno,
        AtaqueMenos,
        AtaqueMas,
        AumentoLocura,
        BloqueoAvance,
        AumentoFe,
        AumentoAvance,
        CambioCarta
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
            _mejorahecha = false;
            AttackPlayerCalculation(Players.Player1);

            //Se aplican efectos a las barras
            _crazyBarJ2.GetComponent<CrazyBarComponent>().changeTurn(Players.Player2);
            _advanceBarJ2.GetComponent<AdvanceBarComponent>().changeTurn(Players.Player2);
            _mejoras1.transform.GetChild(0).gameObject.GetComponent<TweenManager>().ReducirMejora();
            _mejoras1.transform.GetChild(1).gameObject.GetComponent<TweenManager>().ReducirMejora();

            if (_J1Start)
            {
                //Se hace llaman a las animaciones de entrada y salida
                for (int i = 0; i < _deckJ1.transform.childCount; ++i)
                {

                    GameObject card = _deckJ1.transform.GetChild(i).gameObject;

                    if (card.GetComponent<CardState>().GetState() == CardStateValues.Jugado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorArriba(300);

                    }
                    else if (card.GetComponent<CardState>().GetState() == CardStateValues.Guardado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorArriba(100);

                    }
                    else
                    {
                        card.GetComponent<TweenManager>().CartaSeVaPorArriba();
                    }



                }
            }

            if (_J2Start)
            {
                for (int i = 0; i < _deckJ2.transform.childCount; ++i)
                {

                    GameObject card = _deckJ2.transform.GetChild(i).gameObject;

                    if (card.GetComponent<CardState>().GetState() == CardStateValues.Jugado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorArriba(100);

                    }
                    else if (card.GetComponent<CardState>().GetState() == CardStateValues.Guardado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorArriba(300);

                    }
                    else
                    {
                        card.GetComponent<TweenManager>().CartaSeVaPorArriba();
                    }



                }
            }
            


            StartTurnPlayer(Players.Player2);
             
        }
        else
        {
            AttackPlayerCalculation(Players.Player2);

            //Se aplican efectos a las barras
            _crazyBarJ1.GetComponent<CrazyBarComponent>().changeTurn(Players.Player1);
            _advanceBarJ1.GetComponent<AdvanceBarComponent>().changeTurn(Players.Player1);
            _mejoras2.transform.GetChild(0).gameObject.GetComponent<TweenManager>().ReducirMejora();
            _mejoras2.transform.GetChild(1).gameObject.GetComponent<TweenManager>().ReducirMejora();

            if (_J2Start)
            {
                //Se hace llaman a las animaciones de entrada y salida
                for (int i = 0; i < _deckJ2.transform.childCount; ++i)
                {

                    GameObject card = _deckJ2.transform.GetChild(i).gameObject;

                    if (card.GetComponent<CardState>().GetState() == CardStateValues.Jugado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorAbajo(300);

                    }
                    else if (card.GetComponent<CardState>().GetState() == CardStateValues.Guardado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorAbajo(100);

                    }
                    else
                    {
                        card.GetComponent<TweenManager>().CartaSeVaPorAbajo();
                    }
                }

            }

            if (_J1Start)
            {
                for (int i = 0; i < _deckJ1.transform.childCount; ++i)
                {

                    GameObject card = _deckJ1.transform.GetChild(i).gameObject;

                    if (card.GetComponent<CardState>().GetState() == CardStateValues.Jugado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorAbajo(100);

                    }
                    else if (card.GetComponent<CardState>().GetState() == CardStateValues.Guardado)
                    {

                        card.GetComponent<CardState>().ReturnNormal();

                        card.GetComponent<TweenManager>().CartaSeVaPorAbajo(300);

                    }
                    else
                    {
                        card.GetComponent<TweenManager>().CartaSeVaPorAbajo();
                    }

                }
            }      

            StartTurnPlayer(Players.Player1);
            
                
        }
    }

    private void StartTurnPlayer(Players p)
    {
        if(p == Players.Player1)
        {
            _J1Start = true;
            
            //Cambio tiempo cronos
            _cronoJ2.GetComponent<TimeManager>().enabled = false;
            _cronoJ1.GetComponent<TimeManager>().enabled = true;

            //Inicio particulas
            _particulasJ1.Play();

            //Se cambia la carta de comienzo
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ1.transform.GetChild(0).gameObject);

            if (!CheckEffect(Players.Player1, Effects.SaltarTurno))
            {
                //_eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J1_Input;
                _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J1");
            }
            else
            {
                _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("JumpTurn");
            }

     
            _feJ1.RestartFe();

            AssignCards(Players.Player1);
        }
        else
        {

            _J2Start = true;

            //Cambio tiempo cronos
            _cronoJ1.GetComponent<TimeManager>().enabled = false;
            _cronoJ2.GetComponent<TimeManager>().enabled = true;

            //Inicio particulas
            _particulasJ2.Play();

            //Se cambia la carta de comienzo
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_deckJ2.transform.GetChild(0).gameObject);

            if (!CheckEffect(Players.Player2, Effects.SaltarTurno))
            {
                //_eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J2_Input;
                _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("J2");
            }
            else
            {
                _inputManager.GetComponent<PlayerInput>().SwitchCurrentActionMap("JumpTurn");
            }
            
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

                    if(CheckEffect(Players.Player1, Effects.AtaqueMenos))
                    {
                        crazy += Mathf.CeilToInt(cardStats.locura / 2.0f);

                        avance += Mathf.CeilToInt(cardStats.avance / 2.0f);
                    }
                    else if (CheckEffect(Players.Player1, Effects.AtaqueMas))
                    {

                        crazy += Mathf.CeilToInt(cardStats.locura * 1.5f);

                        avance += Mathf.CeilToInt(cardStats.avance * 1.5f);

                    }
                    else
                    {
                        crazy += cardStats.locura;

                        avance += cardStats.avance;
                    }
                    

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

                        turnsEffect = cardStats.num_turnos;

                        _crazyBarJ1.GetComponent<CrazyBarComponent>().addResistence(crazy, turnsEffect);

                        _advanceBarJ1.GetComponent<AdvanceBarComponent>().addResistence(avance, turnsEffect);
                    }
                    else if(typeCard == CardType.Estado)
                    {

                        turnsEffect = cardStats.num_turnos;

                        if (cardStats.afecta_a_rival)
                        {

                            Debug.Log("Carta contra el rival: ");

                            if (cardStats.saltar_turno)
                            {
                                Debug.Log("saltar");
                                _turnsCurrentEffectsJ2[(int)Effects.SaltarTurno] = turnsEffect;
                            }
                            else if (cardStats.ataque_menos_50)
                            {
                                Debug.Log("-ataque");
                                _turnsCurrentEffectsJ2[(int)Effects.AtaqueMenos] = turnsEffect;
                            }
                            else if (cardStats.ataque_mas_50)
                            {
                                Debug.Log("+ataque");
                                _turnsCurrentEffectsJ2[(int)Effects.AtaqueMas] = turnsEffect;
                            }
                            else if (cardStats.aumento_locura)
                            {
                                Debug.Log("+loc");
                                _turnsCurrentEffectsJ2[(int)Effects.AumentoLocura] = turnsEffect;
                            }
                            else if (cardStats.bloqueo_avance)
                            {
                                Debug.Log("block");
                                _turnsCurrentEffectsJ2[(int)Effects.BloqueoAvance] = turnsEffect;
                            }
                            else if (cardStats.aumento_fe)
                            {
                                Debug.Log("+fe");
                                _turnsCurrentEffectsJ2[(int)Effects.AumentoFe] = turnsEffect;
                            }
                            else if (cardStats.aumento_avance)
                            {
                                Debug.Log("+avance");
                                _turnsCurrentEffectsJ2[(int)Effects.AumentoAvance] = turnsEffect;
                            }

                        }
                        
                        if (cardStats.me_afecta)
                        {

                            Debug.Log("Carta a mi");

                            if (cardStats.saltar_turno)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.SaltarTurno] = turnsEffect;
                            }
                            else if (cardStats.ataque_menos_50)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AtaqueMenos] = turnsEffect;
                            }
                            else if (cardStats.ataque_mas_50)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AtaqueMas] = turnsEffect;
                            }
                            else if (cardStats.aumento_locura)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AumentoLocura] = turnsEffect;
                            }
                            else if (cardStats.bloqueo_avance)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.BloqueoAvance] = turnsEffect;
                            }
                            else if (cardStats.aumento_fe)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AumentoFe] = turnsEffect;
                            }
                            else if (cardStats.aumento_avance)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AumentoAvance] = turnsEffect;
                            }

                        }


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

                    if (CheckEffect(Players.Player2, Effects.AtaqueMenos))
                    {
                        crazy += Mathf.CeilToInt(cardStats.locura / 2.0f);

                        avance += Mathf.CeilToInt(cardStats.avance / 2.0f);
                    }
                    else if(CheckEffect(Players.Player2, Effects.AtaqueMas))
                    {

                        crazy += Mathf.CeilToInt(cardStats.locura * 1.5f);

                        avance += Mathf.CeilToInt(cardStats.avance * 1.5f);

                    }
                    else
                    {
                        crazy += cardStats.locura;

                        avance += cardStats.avance;
                    }

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

                        turnsEffect = cardStats.num_turnos;

                        _crazyBarJ1.GetComponent<CrazyBarComponent>().addResistence(crazy, turnsEffect);

                        _advanceBarJ1.GetComponent<AdvanceBarComponent>().addResistence(avance, turnsEffect);
                    }
                    else if (typeCard == CardType.Estado)
                    {

                        turnsEffect = cardStats.num_turnos;

                        if (cardStats.afecta_a_rival)
                        {

                            if (cardStats.saltar_turno)
                            {
                                _turnsCurrentEffectsJ2[(int)Effects.SaltarTurno] = turnsEffect;
                            }
                            else if (cardStats.ataque_menos_50)
                            {
                                _turnsCurrentEffectsJ2[(int)Effects.AtaqueMenos] = turnsEffect;
                            }
                            else if (cardStats.ataque_mas_50)
                            {
                                _turnsCurrentEffectsJ2[(int)Effects.AtaqueMas] = turnsEffect;
                            }
                            else if (cardStats.aumento_locura)
                            {
                                _turnsCurrentEffectsJ2[(int)Effects.AumentoLocura] = turnsEffect;
                            }
                            else if (cardStats.bloqueo_avance)
                            {
                                _turnsCurrentEffectsJ2[(int)Effects.BloqueoAvance] = turnsEffect;
                            }
                            else if (cardStats.aumento_fe)
                            {
                                _turnsCurrentEffectsJ2[(int)Effects.AumentoFe] = turnsEffect;
                            }
                            else if (cardStats.aumento_avance)
                            {
                                _turnsCurrentEffectsJ2[(int)Effects.AumentoAvance] = turnsEffect;
                            }

                        }

                        if (cardStats.me_afecta)
                        {

                            if (cardStats.saltar_turno)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.SaltarTurno] = turnsEffect;
                            }
                            else if (cardStats.ataque_menos_50)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AtaqueMenos] = turnsEffect;
                            }
                            else if (cardStats.ataque_mas_50)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AtaqueMas] = turnsEffect;
                            }
                            else if (cardStats.aumento_locura)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AumentoLocura] = turnsEffect;
                            }
                            else if (cardStats.bloqueo_avance)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.BloqueoAvance] = turnsEffect;
                            }
                            else if (cardStats.aumento_fe)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AumentoFe] = turnsEffect;
                            }
                            else if (cardStats.aumento_avance)
                            {
                                _turnsCurrentEffectsJ1[(int)Effects.AumentoAvance] = turnsEffect;
                            }

                        }


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

    public void MejoraFe(Players p)
    {
        if (_mejorahecha == false) {
            if (p == Players.Player1)
            {
                int _cantidad1 = 10 + (10 * _mejorafe1);
                if (_mejorafe1 < 3 && _advanceBarJ1.GetComponent<AdvanceBarComponent>().CheckAdvance(_cantidad1))
                {
                    _mejoras1.transform.GetChild(0).gameObject.GetComponent<TweenManager>().AumentarMejoraSeleccionada();
                    _feJ1.UpgradeFeAmount();
                }
            }
            else
            {

                int _cantidad2 = 10 + (10 * _mejorafe2);
                if (_mejorafe2 < 3 && _advanceBarJ2.GetComponent<AdvanceBarComponent>().CheckAdvance(_cantidad2))
                {
                    _mejoras2.transform.GetChild(0).gameObject.GetComponent<TweenManager>().AumentarMejoraSeleccionada();
                    _feJ2.UpgradeFeAmount();
                }
            }
        }
        _mejorahecha = true;
    }

    public void MejoraAvance(Players p)
    {
        if (_mejorahecha == false) {
            if (p == Players.Player1)
            {
                int _cantidad1 = 10 + (10 * _mejoraavan1);
                if (_mejoraavan1 < 3 && _advanceBarJ1.GetComponent<AdvanceBarComponent>().CheckAdvance(_cantidad1))
                {
                    _mejoras1.transform.GetChild(1).gameObject.GetComponent<TweenManager>().AumentarMejoraSeleccionada();
                    _advanceBarJ1.GetComponent<AdvanceBarComponent>().UpgradeAdvanceIncrement();
                }
            }
            else
            {

                int _cantidad2 = 10 + (10 * _mejoraavan2);
                if (_mejoraavan2 < 3 && _advanceBarJ2.GetComponent<AdvanceBarComponent>().CheckAdvance(_cantidad2))
                {
                    _mejoras2.transform.GetChild(1).gameObject.GetComponent<TweenManager>().AumentarMejoraSeleccionada();
                    _advanceBarJ2.GetComponent<AdvanceBarComponent>().UpgradeAdvanceIncrement();
                }
            }
        }
        _mejorahecha = true;
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

    public bool CheckEffect(Players p, Effects e)
    {

        if(p == Players.Player1)
        {

            if (_turnsCurrentEffectsJ1[(int)e] > 0)
            {

                _turnsCurrentEffectsJ1[(int)e]--;

                return true;

            }
            else
            {
                return false;
            }

        }
        else
        {

            if (_turnsCurrentEffectsJ2[(int)e] > 0)
            {

                _turnsCurrentEffectsJ2[(int)e]--;

                return true;

            }
            else
            {
                return false;
            }

        }

    }

    public void EndGame(Players player, bool isWinner)
    {
        _victoryMenu.SetActive(true);

        if(player == Players.Player1)
        {
            if (isWinner)
            {
                _J2Shield.gameObject.SetActive(false);
            }
            else
            {
                _J1Shield.gameObject.SetActive(false);
            }


        }
        else
        {

            if (isWinner)
            {
                _J1Shield.gameObject.SetActive(false);
            }
            else
            {
                _J2Shield.gameObject.SetActive(false);
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

        _deckJ1.SetActive(true);

        _deckJ2.SetActive(true);

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

        _eventSystem.GetComponent<InputSystemUIInputModule>().actionsAsset = _J1_Input;

        _inputManager.SetActive(false);

        _cronoJ1.SetActive(false);

        _cronoJ2.SetActive(false);

        _deckJ1.SetActive(false);

        _deckJ2.SetActive(false);

        _flipCoin.GetComponent<FlipCoin>().StartSelection();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
