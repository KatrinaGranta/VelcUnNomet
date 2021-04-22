using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objekti : MonoBehaviour
{
    //GameObejct, kas uzglabā visus velkamos objektus
    public GameObject atkritumuMasina;
    public GameObject atroMasinaa;
    public GameObject autobuss;
    public GameObject ugunsDz;
    public GameObject traktors1;
    public GameObject traktors2;
    public GameObject policija;
    public GameObject ekskavators;
    public GameObject masina1;
    public GameObject masina2;
    public GameObject cementaMas;
    public GameObject uzvarasLogs;

    /*Uzglabā velkamo objektu sākotnējās pozīcijas
    koordinātes (lai zinātu, kur aizmest objektu, AndroidJavaClass tas nolikts nepareizajā vietā)*/

    //Objekts paliek Public, taču paslēpj no inspector Loga
    [HideInInspector]
    public Vector2 atkrKoord;
    [HideInInspector]
    public Vector2 atroKoord;
    [HideInInspector]
    public Vector2 bussKoord;
    [HideInInspector]
    public Vector2 ugunsKoord;
    [HideInInspector]
    public Vector2 trakKoord;
    [HideInInspector]
    public Vector2 trak2Koord;
    [HideInInspector]
    public Vector2 poliKoord;
    [HideInInspector]
    public Vector2 ekskaKoord;
    [HideInInspector]
    public Vector2 mas1Koord;
    [HideInInspector]
    public Vector2 cemKoord;
    [HideInInspector]
    public Vector2 mas2Koord;
    //uzglabā ainā esošo kanvu
    public Canvas kanva;
    //Uzglab;a skaņas avotu, kurā atskaņot audio failu
    public AudioSource skanasAvots;
    //Masīivs, kas uzglabā visas skaņas
    public AudioClip[] skanaKoAskanot;
    [HideInInspector]
    //Uzglabā objektu, kurš ir pēdejais vilktais
    public GameObject pedejaisVilktais = null;
    //Mainigais atbil par to vai objekts ir nolikts pareizi vai nepareizi
    [HideInInspector]
    public bool vaiIstajaVieta = false;

    //Funkcija nostrādā tiklīdz nospiesta play poga
    private void Awake()
    {
        atkrKoord = atkritumuMasina.GetComponent<RectTransform>().localPosition;
        atroKoord = atroMasinaa.GetComponent<RectTransform>().localPosition;
        bussKoord = autobuss.GetComponent<RectTransform>().localPosition;
        ugunsKoord = ugunsDz.GetComponent<RectTransform>().localPosition;
        trakKoord = traktors1.GetComponent<RectTransform>().localPosition;
        trak2Koord = traktors2.GetComponent<RectTransform>().localPosition;
        poliKoord = policija.GetComponent<RectTransform>().localPosition;
        ekskaKoord = ekskavators.GetComponent<RectTransform>().localPosition;
        mas1Koord = masina1.GetComponent<RectTransform>().localPosition;
        cemKoord = cementaMas.GetComponent<RectTransform>().localPosition;
        mas2Koord = masina2.GetComponent<RectTransform>().localPosition;
    }
}
