using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nueva carta", menuName ="Carta")]
public class Carta : ScriptableObject{
    public Sprite diseño;

    public int locura;
    public int locura_propia;
    public int avance;
    public int avance_propio;
    public int cost_fe;
    public int num_cartas;
    public int num_turnos;
    public GameManager.CardType tipo_carta;
    public bool afecta_a_rival;
    public bool me_afecta;
    public bool saltar_turno;
    public bool ataque_menos_50;
    public bool ataque_mas_50;
    public bool aumento_locura;
    public bool bloqueo_avance;
    public bool aumento_fe;
    public bool aumento_avance;
    public bool cambio_carta;
}
