using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nueva carta", menuName ="Carta")]
public class Carta : ScriptableObject{
    public Sprite dise�o;

    public int locura;
    public int cost_mana;
    public int num_cartas;
    public int num_turnos;
}
