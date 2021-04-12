using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objekti : MonoBehaviour
{
    //GameObejct, kas uzglabā visus velkamos objektus
    public GameObject atkritumuMasina;
    public GameObject atroMasinaa;
    public GameObject autobuss;

    /*Uzglabā velkamo objektu sākotnējās pozīcijas
    koordinātes (lai zinātu, kur aizmest objektu, AndroidJavaClass tas nolikts nepareizajā vietā)*/

    //Objekts paliek Public, taču paslēpj no inspector Loga
    [HideInInspector]
    public Vector2 atkrKoord;
    [HideInInspector]
    public Vector2 atroKoord;
    [HideInInspector]
    public Vector2 bussKoord;
    //uzglabā ainā esošo kanvu
    public Canvas kanva;
    //Uzglab;a skaņas avotu, kurā atskaņot audio failu
    public AudioSource skanasAvots;
    //Masīivs, kas uzglabā visas skaņas
    public AudioClip[] skanaKoAskanot;
    //Uzglabā objektu, kurš ir pēdejais vilktais
    public GameObject pedejaisVilktais = null;
    //MAin;igais atbil par to vai objekts ir nolikts pareizi vai nepareizi
    [HideInInspector]
    public bool vaiIstajaVieta = false;

    //Funkcija nostrādā tiklīdz nospiesta play poga
    private void Awake()
    {
        atkrKoord = atkritumuMasina.GetComponent<RectTransform>().localPosition;
        atroKoord = atroMasinaa.GetComponent<RectTransform>().localPosition;
        bussKoord = autobuss.GetComponent<RectTransform>().localPosition;
    }
}
