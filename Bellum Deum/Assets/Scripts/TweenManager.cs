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

    private RectTransform _botonMejorarFe;

    private Vector2 _originalPos;

    void Start()
    {
        _botonSelTransform = gameObject.GetComponent<RectTransform>();

        _botonMejorarFe = gameObject.GetComponent<RectTransform>();

        _originalPos = _botonSelTransform.localPosition;
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

    public void AumentarMejoraSeleccionada()
    {
        _botonMejorarFe.DOScale(new Vector2(1.2f, 1.2f), 0.5f);
    }

    public void ReducirMejora()
    {
        _botonMejorarFe.DOScale(new Vector2(1f, 1f), 0.5f);
    }

    public void AumentarCartaSeleccionada()
    {
        _botonSelTransform.DOScale(new Vector2(1.2f, 1.2f), 0.5f);
    }

    public void ReducirCartaDeseleccionada()
    {
        _botonSelTransform.DOScale(new Vector2(1f, 1f), 0.5f);
    }

    public void CartaSeVaPorArriba()
    {

        float posFinal = _botonSelTransform.position.y + 200;
        _botonSelTransform.DOMoveY(posFinal, 0.6f);
        //_botonSelTransform.DOMove(_originalPos, 0.6f);

    }

    public void CartaSeVaPorAbajo()
    {

        float posFinal = _botonSelTransform.position.y - 200;
        _botonSelTransform.DOMoveY(posFinal, 0.6f);

    }

    public void CartaSeVaPorArriba(int distance)
    {

        float posFinal = _botonSelTransform.position.y + distance;
        _botonSelTransform.DOMoveY(posFinal, 0.6f);
        //_botonSelTransform.DOMove(_originalPos, 0.6f);

    }

    public void CartaSeVaPorAbajo(int distance)
    {

        float posFinal = _botonSelTransform.position.y - distance;
        _botonSelTransform.DOMoveY(posFinal, 0.6f);

    }
}
