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

    public enum Players{
        Player1,
        Player2
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

    public void CheckCardPlayed()
    {
        int crazyPoints;

        int advancePoints;

        //revision de puntos de cada carta
        //revision de efectos



    }

    public void EndGame(Players player, bool isWinner)
    {
        if(player == Players.Player1)
        {
            if (isWinner)
            {
                //victoria jugador 1
            }
            else
            {
                //victoria jugador 2
            }


        }
        else
        {

            if (isWinner)
            {
                //victoria jugador 2
            }
            else
            {
                //victoria jugador 1
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
