using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCoin : MonoBehaviour
{

    private RectTransform _myTransform;

    private Image _image;

    private bool _reducing = true;

    private int _turnsCoin;

    private int _contador;

    [SerializeField] float _speed = 1;

    private bool _startAnimation = false;

    private bool _gameManagerAdvice = false;

    [SerializeField] private GameObject _pantallaJug1;
    [SerializeField] private GameObject _pantallaJug2;


    public void StartSelection()
    {

        _turnsCoin = Random.Range(4, 6);

        _contador = 0;

        _startAnimation = true;
    }

    private void StartMatchCall()
    {

        if (_image.color == Color.blue)
        {
            GameManager.Instance.StartMatch(GameManager.Players.Player1);
            _pantallaJug1.SetActive(false);
        }
        else
        {
            GameManager.Instance.StartMatch(GameManager.Players.Player2);
            _pantallaJug2.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        _myTransform= GetComponent<RectTransform>();

        _image= GetComponent<Image>();

        _image.color = Color.blue;

    }

    // Update is called once per frame
    void Update()
    {
        if (_startAnimation)
        {
            if (_contador < _turnsCoin)
            {
                if (_reducing)
                {
                    _myTransform.sizeDelta -= new Vector2(0, _speed) * Time.deltaTime;
                }
                else
                {
                    _myTransform.sizeDelta += new Vector2(0, _speed) * Time.deltaTime;
                }

                if (_myTransform.sizeDelta.y <= 0f)
                {
                    _reducing = false;

                    if (_image.color == Color.blue)
                    {
                        _image.color = Color.red;
                    }
                    else
                    {
                        _image.color = Color.blue;
                    }
                }
                else if (_myTransform.sizeDelta.y >= 100f)
                {
                    _reducing = true;
                    _contador++;
                }
            }
            else
            {
                if (!_gameManagerAdvice)
                {
                    Invoke("StartMatchCall", 5);
                    _gameManagerAdvice = true;

                    if (_image.color == Color.blue)
                    {
                        Invoke("ActivarPantallaJ1", 1f);
                    }
                    else
                    {
                        Invoke("ActivarPantallaJ2", 1f);
                    }                    
                }
            }
        }
    }

    public void ActivarPantallaJ1()
    {
        _pantallaJug1.SetActive(true);
    }

    public void ActivarPantallaJ2()
    {
        _pantallaJug2.SetActive(true);
    }
}
