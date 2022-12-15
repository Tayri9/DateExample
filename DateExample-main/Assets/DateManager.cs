using System;  //Para DateTime
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoBehaviour
{
    string hourHambreString;
    string ultimaHoraQueRestoPuntosPorHambre;
    DateTime time;
    [SerializeField]
    int pointsLove = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ahora mismo = " + DateTime.Now.ToString());

        //Para probar el funcionamiento lo primero que hago
        //es calcular cuando va a tener hambre para simplificarlo 
        //le digo que será en 15 segundos....
        DateTime cuandoTendraHambre = DateTime.Now.AddSeconds(15);
        time = cuandoTendraHambre.AddSeconds(10);
        
        //Almaceno en un string la hora de cuando tendrá hambre
        //esto lo hago para poder guardar como string en playerprefs
        //las diferentes fechas.
        hourHambreString = cuandoTendraHambre.ToString();
        Debug.Log("Tendra hambre a las " + hourHambreString);


        ultimaHoraQueRestoPuntosPorHambre = DateTime.Now.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Carga desde un string (podría ser un string sacado desde player prefs...) la fecha (con hora mes y dias...)

        DateTime cuandoTendraHambre = DateTime.Parse(hourHambreString);
        DateTime ultimaVezRestado = DateTime.Parse(ultimaHoraQueRestoPuntosPorHambre);

        //Comparo la fecha de cuando tendrá hambre con la actual.
        //En caso de haberse pasado la hora de comer, se mostrará el mensaje.

        if (IsHungry() && PuedePerderPuntos())
        {
            Debug.Log("Tiene Hambre");
            pointsLove--;
            ultimaHoraQueRestoPuntosPorHambre = DateTime.Now.ToString();
        }


        /*
        if (cuandoTendraHambre < DateTime.Now)
        {         
            Debug.Log("Tiene Hambre");
            if (time < DateTime.Now)
            {
                pointsLove--;
                time = DateTime.Now.AddSeconds(10);
            }
        }*/


    }

    public bool PuedePerderPuntos()
    {
        //ultima vez que le resté puntos
        DateTime ultimaVezRestado = DateTime.Parse(ultimaHoraQueRestoPuntosPorHambre);
        return ultimaVezRestado.AddSeconds(10) < DateTime.Now;
    }

    public bool IsHungry()
    {
        DateTime cuandoTendraHambre = DateTime.Parse(hourHambreString);
        return cuandoTendraHambre < DateTime.Now;
    }

    public void GiveFood()
    {
        if (IsHungry())
        {
            DateTime cuandoTendraHambre = DateTime.Now.AddSeconds(15);
            hourHambreString = cuandoTendraHambre.ToString();
            pointsLove += 10;
        }
        else
        {
            Debug.Log("Estoy engordando...");
        }
    
    }
}
