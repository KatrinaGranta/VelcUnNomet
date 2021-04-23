using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//jaīmporte lai varetu piesaistit IDropHandler interfeisu un lietot OnDrop funkciju
using UnityEngine.EventSystems;

public class NomesanasVieta : MonoBehaviour, IDropHandler
{
    //uzglaba velkama objekta rotaciju ap z asi un noliekamas vietas rotaciju
    //starpibu uzglabās, cik liela z ass rotācijas leņķa starpiba starp abiem objektiem
    private float vietasZrot, velkamaObjeZrot, rotacijasStarpiba;
    //uzglaba velkama objekta un nomesanas vietas izmerus
    private Vector2 vietasIzm, velkObjIzm;
    //uzglaba objektu x un y ass izmeru starpibu
    private float xIzmeruStarpiba, yIzmeruStarpiba;
    //norade uz skriptu objektu
    public Objekti objektuSkripts;

    //nostrada ja objektu cenšas nomest uz nometama lauka
    public void OnDrop(PointerEventData notikums)
    {
        //parbauda vai kads objekts tiek vilkts
        if (notikums.pointerDrag != null)
        {
            //ja nomešanas laukā uzmetā attela tags sakrit lauka tagu
            if ((notikums.pointerDrag.tag.Equals(tag)))
            {
                //iegust objekta rotaciju grados
                vietasZrot = notikums.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
                velkamaObjeZrot = GetComponent<RectTransform>().transform.eulerAngles.z;
                //aprekina rotacijas starpibu 
                rotacijasStarpiba = Mathf.Abs(vietasZrot - velkamaObjeZrot);
                //iegust objektu izmerus 
                vietasIzm = notikums.pointerDrag.GetComponent<RectTransform>().localScale;
                velkObjIzm = GetComponent<RectTransform>().localScale;
                xIzmeruStarpiba = Mathf.Abs(vietasIzm.x - velkObjIzm.x);
                yIzmeruStarpiba = Mathf.Abs(vietasIzm.y - velkObjIzm.y);

                //parbauda vai objektu savstarpeja rotacija neatsķiras vairāk par 9 grādiem 
                //un vai x un y izmeri neatšķiras vairak par 0.15
                if ((rotacijasStarpiba <= 9 || (rotacijasStarpiba >= 351 && rotacijasStarpiba <= 360))
                    && (xIzmeruStarpiba <= 0.15 && yIzmeruStarpiba <= 0.15))
                {
                    objektuSkripts.vaiIstajaVieta = true;
                    //nometamo objektu iecentre vieta
                    notikums.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        GetComponent<RectTransform>().anchoredPosition;
                    //pielago nosmesta objekta rotaciju
                    notikums.pointerDrag.GetComponent<RectTransform>().localRotation =
                        GetComponent<RectTransform>().localRotation;
                    //pielago nomesta obejkta rotaciju
                    notikums.pointerDrag.GetComponent<RectTransform>().localScale =
                        GetComponent<RectTransform>().localScale;

                    //Atrodot Uzvaras loga atrašanās vietu, tiek skaitīti punkti uz UzvarasLogs
                    GameObject.Find("PointsHandler").GetComponent<UzvarasLogs>().AddPoints();

                    /*parbauda pec tagiem kurs no objektiem ir pareizi nomests, 
                    tad atskano atbilsotsu skanu*/
                    switch (notikums.pointerDrag.tag)
                    {
                        case "Atkritumi":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[1]);
                            break;
                        case "Atrie":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[2]);
                            break;
                        case "Skola":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[4]);
                            break;
                        case "Uguns":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[3]);
                            break;
                        case "Traktors":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[5]);
                            break;
                        case "Traktors2":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[6]);
                            break;
                        case "Policija":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[7]);
                            break;
                        case "Ekskavators":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[8]);
                            break;
                        case "Masina1":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[9]);
                            break;
                        case "cementaMas":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[11]);
                            break;
                        case "Masina2":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[10]);
                            break;

                        default:
                            Debug.Log("nedefinets tag!");
                            break;
                    }
                }
                //ja objektu tagi nesakrit, nomet nepareizaja vieta
            }
            else
            {
                objektuSkripts.vaiIstajaVieta = false;
                //atskaņo skanu
                objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[0]);

                //atkariba no objektu taga kurs tika vilkts objekta
                //uzbida uz ta sakotneja kooardinatam
                switch (notikums.pointerDrag.tag)
                {
                    case "Atrie":
                        objektuSkripts.atkritumuMasina.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.atkrKoord;
                        break;
                    case "Atkritumi":
                        objektuSkripts.atroMasinaa.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.atroKoord;
                        break;
                    case "Skola":
                        objektuSkripts.autobuss.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.bussKoord;
                        break;
                    case "Uguns":
                        objektuSkripts.ugunsDz.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.ugunsKoord;
                        break;
                    case "Traktors":
                        objektuSkripts.traktors1.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.trakKoord;
                        break;
                    case "Traktors2":
                        objektuSkripts.traktors2.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.trak2Koord;
                        break;
                    case "Policija":
                        objektuSkripts.policija.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.poliKoord;
                        break;
                    case "Ekskavators":
                        objektuSkripts.ekskavators.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.ekskaKoord;
                        break;
                    case "Masina1":
                        objektuSkripts.masina1.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.mas1Koord;
                        break;
                    case "cementaMas":
                        objektuSkripts.cementaMas.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.cemKoord;
                        break;
                    case "Masina2":
                        objektuSkripts.masina2.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.mas2Koord;
                        break;

                    default:
                        Debug.Log("objektam nav noteikta parvietosanas vieta!");
                        break;
                }
                
            }
        }
    }
}