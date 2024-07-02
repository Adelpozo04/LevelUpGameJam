using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyBarComponent : MonoBehaviour
{

    #region parameters

    [SerializeField] private float amount;

    [SerializeField] private float maxAmount;

    [SerializeField] private GameManager.Players playerNumber;

    #endregion


    private void DecreaseCrazy(float n)
    {

        amount -= n;

        if (amount <= 0)
        {
            amount = 0;
        }

    }

    private void IncreaseCrazy(float n)
    {

        amount += n;

        if(amount >= maxAmount)
        {
            GameManager.Instance.EndGame(playerNumber, false);
        }

    }

}
