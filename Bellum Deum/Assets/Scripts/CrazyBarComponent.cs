using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    #region properties


    private bool _muerteSubita = false;

    private float _muerteTurns;

    #endregion


    public void startMuerteSubita()
    {
        _muerteSubita = true;
    }

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

        if (_muerteSubita)
        {
            IncreaseCrazy(2 * _muerteTurns);
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

        transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = (amount / 100);

    }

    private void IncreaseCrazy(float n)
    {

        amount += n;

        if(amount >= maxAmount)
        {
            GameManager.Instance.EndGame(playerNumber, false);
        }

        transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = (amount / 100);

    }

    void Start()
    {

        transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = 0;

    }

}
