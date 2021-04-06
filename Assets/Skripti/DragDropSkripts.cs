using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lia varētu strādāt ar Event|Systems
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler /* IEndDragHandler*/ 
    {
    //Uzglabās norādi uz Objektu skriptu
   // public Objekti objektuSkripts;
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
        //objektuSkripts.pedejaisVilktais = null;
        //Usākot vilkt objektu tas paliek nedaudz caurspīdīgs
        kanvasGrupa.alpha = 0.6f;
        //Lai objekta varētu iet cauri raycast stars
        kanvasGrupa.blocksRaycasts = false;
    }

    //Nostrādā reāli notiekot vilkšanai

    public void OnDrag(PointerEventData notikums)  {
        Debug.Log("notiek vilkšana!");
        //velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;

    }

}
