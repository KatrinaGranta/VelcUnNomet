using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lia varētu strādāt ar Event|Systems
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler,  IEndDragHandler
    {
    //Uzglabās norādi uz Objektu skriptu
    public Objekti objektuSkripts;
    //Velkamā objekta piestiprināta komponete
    private CanvasGroup kanvasGrupa;
    //Vilktā objekta atrašanās vietas kooridinātu maiņai
    private RectTransform velkObjRectTransf;

    void Awake()  {
        //Piekļūst objektam piesaistītajai canvasGroup komponentei
        kanvasGrupa = GetComponent<CanvasGroup>();
        //Piekļust objekta RectTransfrom komponentei
        velkObjRectTransf = GetComponent<RectTransform>();

    }

    //Nostrādā nospiežot peles klikši uz objekta
    public void OnPointerDown(PointerEventData notikums){
        Debug.Log("Uzklikšķināts uz velkamā objekta!");

    }
    //Nostrādā uzsākot vilkšanu
    public void OnBeginDrag(PointerEventData notikums){
        Debug.Log("Uzsākta vilkšana!");
        //Attīra pēdējo vilkto objektu
        objektuSkripts.pedejaisVilktais = null;
        //Usākot vilkt objektu tas paliek nedaudz caurspīdīgs
        kanvasGrupa.alpha = 0.6f;
        //Lai objekta varētu iet cauri raycast stars
        kanvasGrupa.blocksRaycasts = false;
    }

    //Nostrādā reāli notiekot vilkšanai

    public void OnDrag(PointerEventData notikums)  {
        Debug.Log("notiek vilkšana!");
        velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;

    }

    //Nostādā, kad tiek beigta vilkšana
    public void OnEndDrag(PointerEventData notikums)
    {
        //Atlaižot objektu iestata to kā pēdējo vilkto
        objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
        Debug.Log("Pēdējais vilktais objekts: " + objektuSkripts.pedejaisVilktais);
        Debug.Log("Beigta vilkšana!");
        //Atlaižot objektu ta atkal paliek necaurspīdīgs
         kanvasGrupa.alpha = 1;

        //Pārbauda vai objekts ir vienkārši nomest vai arī nomests pareizajā vietā
        if(objektuSkripts.vaiIstajaVieta == false)
        {
        //ja nav nomests pareizaja vietā, tad atkal padara velkamu
            kanvasGrupa.blocksRaycasts = true;
        }
        else
        {
        /*Ja objeks nolikts pareizaja vietā, izmēra, rotācija,
            tad pedējo vilkto attīra*/
            objektuSkripts.pedejaisVilktais = null;
        }
        /*JA viens objekts nomests pareizāja vietā, tad lai verētu turpināt
        pārvietot pāerējos objektus*/
        objektuSkripts.vaiIstajaVieta = false;
    }

}
