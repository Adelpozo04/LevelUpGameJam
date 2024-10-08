using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeComponent : MonoBehaviour
{

    #region parameters

    [SerializeField] private int _feAmount;

    [SerializeField] private int _maxFeAmount = 3;

    #endregion

    #region references

    [SerializeField] private GameObject _textAmount;

    [SerializeField] private GameManager.Players _currentPlayer;

    #endregion


    public bool UseFe(int fe)
    {

        if(_feAmount - fe >= 0)
        {
            _feAmount -= fe;

            _textAmount.GetComponent<TextMeshProUGUI>().text = _feAmount.ToString();

            return true;
        }


        return false;
    }

    public void RestoreFe(int fe)
    {

        _feAmount += fe;

        _textAmount.GetComponent<TextMeshProUGUI>().text = _feAmount.ToString();

    }

    public void RestartFe()
    {

        if(GameManager.Instance.CheckEffect(_currentPlayer, GameManager.Effects.AumentoFe))
        {
            _feAmount = _maxFeAmount + 1;
        }
        else
        {
            _feAmount = _maxFeAmount;
        }
        

        _textAmount.GetComponent<TextMeshProUGUI>().text = _feAmount.ToString();

    }

    public void UpgradeFeAmount()
    {
        _maxFeAmount++;
        _textAmount.GetComponent<TextMeshProUGUI>().text = _feAmount.ToString();
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
