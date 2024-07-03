using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

public class TweenManager : MonoBehaviour
{
    private RectTransform _botonSelTransform;

    void Start()
    {
        _botonSelTransform = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        
    }

    public void MoveAbajo()
    {
        float posFinal = _botonSelTransform.position.y - 100;
        _botonSelTransform.DOMoveY(posFinal, 1f);
    }

    public void MoveArriba()
    {
        float posFinal = _botonSelTransform.position.y + 100;
        _botonSelTransform.DOMoveY(posFinal, 1f);
    }
}
