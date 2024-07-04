using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class CardManager : MonoBehaviour
{
    private Carta carta_a_barajar;

    [SerializeField] private List<Carta> baraja;

    public void Barajar_cartas()
    {
        
        for (int i = 0; i < 3; i++) {
            if (i == 0){
                for (int j = 1; j<=3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Ataque/aum_loc_dism_avan_"+j);

                    for(int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }

                    
                }
            }
            else if (i == 1) {
                for (int j = 1; j <= 8; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Ataque/aumentar_locura_"+j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else
            {
                for (int j = 1; j <= 8; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Ataque/disminuir_avance_"+j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (i == 0)
            {
                for (int j = 1; j <= 3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/ambos_escudos_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 1)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/aumentar_escudo_avan_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 2)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/aumentar_escudo_loc_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 3)
            {
                for (int j = 1; j <= 3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/inmunidad_ataque_menos_50_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 4)
            {
                for (int j = 1; j <= 3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/inmunidad_aumento_locura_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 5)
            {
                for (int j = 1; j <= 3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/inmunidad_bloqueo_avance_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else
            {
                for (int j = 1; j <= 3; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Mejora/inmunidad_saltar_turno_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            if (i == 0)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/ataque_mas_50_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 1)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/ataque_menos_50_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 2)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/aumentar_avance_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 3)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/aumentar_fe_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 4)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/aumento_locura_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 5)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/bloquear_avance_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else if (i == 6)
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/cambiar_carta_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            else
            {
                for (int j = 1; j <= 6; j++)
                {
                    var carta_a_barajar = Resources.Load<Carta>("Efectos/saltar_turno_" + j);
                    for (int k = 0; k < carta_a_barajar.num_cartas; k++)
                    {
                        baraja.Add(carta_a_barajar);
                    }
                }
            }
            
        }

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
        baraja = new List<Carta>();

        Barajar_cartas();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
