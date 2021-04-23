using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzvarasLogs : MonoBehaviour
{
    //Tiek nodefinēti tagadējie punkti, kurus lietotājs sakrāj un uzvaras punktu skaitu
    private int uzvarasPunkti;
    private int tagadejiePunkti;
    public GameObject objektuSkripts;
    // Start is called before the first frame update
    void Start()
    {
        uzvarasPunkti = objektuSkripts.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    { //Ja tagadējie punkti, ko lietotājs sakrāj pārspēj vai ir tikpat daudz, cik uzvaras punkti - uzvaras logs parādās
        if(tagadejiePunkti >= uzvarasPunkti){
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void AddPoints(){ //Skaitās punkti
        tagadejiePunkti++;
    }
}
