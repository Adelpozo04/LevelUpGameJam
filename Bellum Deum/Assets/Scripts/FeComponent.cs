using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeComponent : MonoBehaviour
{

    #region parameters

    [SerializeField] private int _feAmount;

    [SerializeField] private int _maxFeAmount = 3;

    #endregion


    public bool UseFe(int fe)
    {

        if(_feAmount - fe >= 0)
        {
            _feAmount -= fe;
            return true;
        }


        return false;
    }

    public void RestartFe()
    {

        _feAmount = _maxFeAmount;

    }

    public void UpgradeFeAmount()
    {
        _maxFeAmount++;
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
