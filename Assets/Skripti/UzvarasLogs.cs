using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzvarasLogs : MonoBehaviour
{
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
    {
        if(tagadejiePunkti >= uzvarasPunkti){
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void AddPoints(){
        tagadejiePunkti++;
    }
}
