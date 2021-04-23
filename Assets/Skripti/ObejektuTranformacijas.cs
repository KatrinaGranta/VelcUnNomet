using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejektuTranformacijas : MonoBehaviour {
    //Uzglabā norādi uz objektu skriptu
    public Objekti objektuSkripts;



    void Update()
    {   //Ja ir kāds pēdējais vilktais objekts, tad var veikt darbības ar to
        if (objektuSkripts.pedejaisVilktais != null)
        {  //Nospiežot pogu Z, objektu var rotēt pulksteņrādītāja virzienam
            if (Input.GetKey(KeyCode.Z))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * 9f);
            }
            //Nospiežot pogu X, objektu var rotēt pretēji pulksteņrādītāja virzienam
            if (Input.GetKey(KeyCode.X))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * 9f);
            }
            //Nospiežot pogu pa kreisi, var pataisīt šaurāku pa x asi
            if (Input.GetKey(KeyCode.LeftArrow))
            {  //Lai objektu nevar izstiept mīnusā
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x > 0.15)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                    new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x - 0.001f,
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }
            }
            //Nospiežot pogu pa labi, var pataisīt plašāku pa x asi
            if (Input.GetKey(KeyCode.RightArrow))
            { //Lai objektu nevar izstiept mīnusā
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x < 1.2)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                    new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x + 0.001f,
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }
            }
            //up arrow = lielāks y 
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y < 1.2)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                    new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y + 0.001f);
                }
            }
            //down arrow = mazāks y 
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y > 0.15)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                    new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y - 0.001f);
                }
            }
        }
    }
}
