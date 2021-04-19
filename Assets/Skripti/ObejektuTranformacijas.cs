using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejektuTranformacijas : MonoBehaviour {
    //UZglabā norādi uz objektu skriptu
    public Objekti objektuSkripts;


   
    void Update()
    {
        //Ja ir kāds pēdejais vilktais objekts, tad var veikt darbības ar to
        if (objektuSkripts.pedejaisVilktais != null) {
            //Nospiežot ppgu Z objektu var rotēt pretēji pulksteņrādītāja virzienam
            if (Input.GetKey(KeyCode.Z))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * 9f);
            }
            //Nospiežot ppgu X objektu var rotēt pretēji pulksteņrādītāja virzienam
            if (Input.GetKey(KeyCode.X))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * 9f);
            }

            //Nospiēžot bultiņu pa kreisi, iespējams objektu stiept šaurāku pa x asi
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Lai objektu nevar izstiept mīnusā
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x > 0.35)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x - 0.001f,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }
            }
            //Nospiēžot bultiņu pa labi, iespējams objektu stiept plašāku pa x asi

            if (Input.GetKey(KeyCode.RightArrow))
                {
                    //Lai objektu nevar izstiept pārāk plašu pa x asi
                    if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x < 0.9)
                    {
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                            new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x + 0.001f,
                            objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                    }
                }
            //Nospiēžot bultiņu uz augšu, iespējams objektu stiept lielāku pa y asi
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Lai objektu nevar izstiept pārāk plašu pa x asi
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y < 0.8)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y  - 0.001f);
                }
            }
            //Nospiēžot bultiņu uz leju, iespējams objektu stiept šaurāku pa y asi
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Lai objektu nevar izstiept pārāk plašu pa x asi
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y > 0.35)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y - 0.001f);
                }
            }

        }
    }
}
