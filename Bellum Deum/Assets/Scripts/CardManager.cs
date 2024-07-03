using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class CardManager : MonoBehaviour
{
    private Carta carta_a_barajar;

    private List<Carta> baraja = new List<Carta>();

    public List<Carta> Barajar_cartas()
    {
        
        for (int i = 0; i < 3; i++) {
            if (i == 0){
                for (int j = 1; j==3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Ataque/aum_loc_dism_avan_"+j);
                    baraja.Add(carta_a_barajar);
                }
            }
            else if (i == 1) {
                for (int j = 1; j == 8; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Ataque/aumentar_locura_"+j);
                    baraja.Add(carta_a_barajar);
                }
            }
            else
            {
                for (int j = 1; j == 8; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Ataque/disminuir_avance_"+j);
                    baraja.Add(carta_a_barajar);
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                for (int j = 1; j == 3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/ambos_escudos_" + j);
                    baraja.Add(carta_a_barajar);
                }
            }
            else if (i == 1)
            {
                for (int j = 1; j == 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/aumentar_escudo_avan_" + j);
                    baraja.Add(carta_a_barajar);
                }
            }
            else
            {
                for (int j = 1; j == 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/aumentar_escudo_loc_" + j);
                    baraja.Add(carta_a_barajar);
                }
            }
        }
        return baraja;
    }

    public Carta AskCard()
    {

        int cardIndex = Random.Range(0, baraja.Count);

        Carta card = baraja[cardIndex];

        baraja.Remove(card);

        return card;

    }

    // Start is called before the first frame update
    void Start()
    {
        baraja = Barajar_cartas();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
