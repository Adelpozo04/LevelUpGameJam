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
        _botonSelTransform.DOMoveY(posFinal, 0.6f);
    }

    public void MoveArriba()
    {
        float posFinal = _botonSelTransform.position.y + 100;
        _botonSelTransform.DOMoveY(posFinal, 0.6f);
    }

    public void AumentarCartaSeleccionada()
    {
        _botonSelTransform.DOScale(new Vector2(1.3f, 1.3f), 0.5f);
    }

    public void ReducirCartaDeseleccionada()
    {
        _botonSelTransform.DOScale(new Vector2(1f, 1f), 0.5f);
    }
}
