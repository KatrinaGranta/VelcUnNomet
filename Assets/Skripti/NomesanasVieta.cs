using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lai varētu piesaistīt IDropHAndler interfeisu un lietot OnDrop funkciju
using UnityEngine.EventSystems;


public class NomesanasVieta : MonoBehaviour, IDropHandler
{
    //Uzglabās velkamā objekta rotāciju ap z asi un noliekamās vietas rotāciju
    //Starpību uzglabās, cik liela z ass rotācijas leņķa starpība starp abiem objektiem
    private float vietasZrot, velkamaObejktaZrot, rotacijasStarpiba;
    //ucglabās velkmaā objekta un nomešanas vietas izmērus
    private Vector2 vietasIzm, velkObjIzm;
    //Uzglabās obejktu x un y ass izmēru starpību
    private float xIzmeruStarpiba, yIzmeruStarpiba;
    //Norāde uz skriptu objektu
    public Objekti objektuSkripts;

    //Nostrādā, ja objektu cenšas nomest uz nometāmā lauka
    public void OnDrop(PointerEventData notikums)
    {
        //Pārabuada vai kāds obejekts tiek vilkts un nomests
        if(notikums.pointerDrag != null)
        {
            //Ja nomešanas laukā uzmestā attēla tags sakrīt ar lauka tagu
            if ((notikums.pointerDrag.Equals(tag)))
            {
                //Iegūst objektu rotāciju grādos
                vietasZrot = notikums.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
                velkamaObejktaZrot = GetComponent<RectTransform>().transform.eulerAngles.z;
                //Aprēķina rotācijas starpību
                rotacijasStarpiba = Mathf.Abs(vietasZrot - velkamaObejktaZrot);
                //Iegūst objektu izmērus
                vietasIzm = notikums.pointerDrag.GetComponent<RectTransform>().localScale;
                velkObjIzm = GetComponent<RectTransform>().localScale;
                xIzmeruStarpiba = Mathf.Abs(vietasIzm.x - velkObjIzm.x);
                yIzmeruStarpiba = Mathf.Abs(vietasIzm.y - velkObjIzm.y);

                //Pārbauda vai objektu savstarpējā rotācija neatsķiras vairāk par 6 rādiem
                //un vai x un y izmēri neatšķiras vairāk par 0.15
                if ((rotacijasStarpiba <= 0 || (rotacijasStarpiba >= 351 && rotacijasStarpiba <= 360))
                    && (xIzmeruStarpiba <=0.15 && yIzmeruStarpiba <= 0.15))
                {
                    objektuSkripts.vaiIstajaVieta = true;
                    //Nometamo objektu iecentrē nomešanas vietā
                    notikums.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    //Pielāgo nomestā objekta rotāciju
                    notikums.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
                    //Pielāgo nomestā objekta izmēru
                    notikums.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

                    //Pārbauda pēc tagiem, kurš no objektiem ir pareizi nomests, tad atskaņo atbilstošo skaņu
                    switch (notikums.pointerDrag.tag)
                    {
                        case "Atkritumi":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[1]);
                            break;
                        case "Atrie":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[2]);
                           break;
                        case "Skola":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[3]);
                           break;

                        default:
                            Debug.Log("Nedefinēts Tags!");
                            break;
                    }
                }
                //Ja objektu tagi nesakrīt un nomet nepareizaja vietā
            }else{
                objektuSkripts.vaiIstajaVieta = false;
                //Atksaņo skaņu
                objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAskanot[0]);
                /*Atkarībā no obejektu taga kurš tika vilkts
                 * objektu aizbīda uz sākotnējo koordināti*/

                switch (notikums.pointerDrag.tag)
                {
                    case "Atkritumi":
                        objektuSkripts.atkritumuMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atkrKoord;
                        break;
                    case "Atrie":
                        objektuSkripts.atroMasinaa.GetComponent<RectTransform>().localPosition = objektuSkripts.atroKoord; break;
                    case "Skola":
                        objektuSkripts.autobuss.GetComponent<RectTransform>().localPosition = objektuSkripts.bussKoord;
                        break;

                    default:
                        Debug.Log("Nedefinēts Tags!");
                        break;
                }
            }
        }
    }
}
