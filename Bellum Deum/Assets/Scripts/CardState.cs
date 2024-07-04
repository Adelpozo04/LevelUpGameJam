using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{


    #region parameters

    [SerializeField] private GameManager.CardStateValues _currentState = GameManager.CardStateValues.Normal;

    [SerializeField] private Carta _cardStats;

    #endregion


    public void ChangeState(bool cartaLaMesa)
    {

        if (cartaLaMesa)
        {

            if (_currentState == GameManager.CardStateValues.Guardado)
            {
                _currentState = GameManager.CardStateValues.Normal;
            }
            else if(_currentState == GameManager.CardStateValues.Normal)
            {
                _currentState = GameManager.CardStateValues.Jugado;
            }

        }
        else
        {

            if (_currentState == GameManager.CardStateValues.Jugado)
            {
                _currentState = GameManager.CardStateValues.Normal;
            }
            else if (_currentState == GameManager.CardStateValues.Normal)
            {
                _currentState = GameManager.CardStateValues.Guardado;
            }

        }

        
    }

    public GameManager.CardStateValues GetState()
    {
        return _currentState;
    }

    public Carta GetStats()
    {
        return _cardStats;
    }

    public void AddCardStats(Carta card)
    {
        _cardStats = card;
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
