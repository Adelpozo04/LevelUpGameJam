using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{


    #region parameters

    private GameManager.CardStateValues _currentState;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
