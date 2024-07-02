using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyBarComponent : MonoBehaviour
{

    #region parameters

    [SerializeField] private float amount;

    [SerializeField] private float maxAmount;

    [SerializeField] private GameManager.Players playerNumber;

    [SerializeField] private float resistence;

    private List<float> resistenceValues = new List<float>();

    private List<int> resistenceTurns = new List<int>();

    #endregion

    public void changeTurn(GameManager.Players pEnded)
    {

        if (pEnded == playerNumber)
        {

            for (int i = 0; i < resistenceTurns.Count; i++)
            {
                resistenceTurns[i]--;

                if (resistenceTurns[i] <= 0)
                {

                    resistence -= resistenceValues[i];

                    resistenceValues.Remove(i);
                    resistenceTurns.Remove(i);

                }
            }

        }

    }

    public void addResistence(float res, int turns)
    {

        resistence += res;

        resistenceValues.Add(res);
        resistenceTurns.Add(turns);

    }


    private void DecreaseCrazy(float n)
    {

        if (resistence > 0)
        {
            amount += n;
        }
        else
        {
            amount += n * (1 - (resistence / 100));
        }

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
