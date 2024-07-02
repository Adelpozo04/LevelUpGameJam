using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region properties

    static private GameManager _instance;

    #endregion


    #region references

    [SerializeField] private GameObject _barJ1;
    [SerializeField] private GameObject _barJ2;

    #endregion

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
