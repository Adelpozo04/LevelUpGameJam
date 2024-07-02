using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceBarComponent : MonoBehaviour
{
    #region parameters

    [SerializeField] private float amount;

    [SerializeField] private float maxAmount;

    [SerializeField] private GameManager.Players playerNumber;

    #endregion


    private void DecreaseAdvance(float n)
    {

        amount -= n;

        if (amount <= 0)
        {
            amount = 0;
        }

    }

    private void IncreaseAdvance(float n)
    {

        amount += n;

        if (amount >= maxAmount)
        {
            GameManager.Instance.EndGame(playerNumber, true);
        }

    }
}
