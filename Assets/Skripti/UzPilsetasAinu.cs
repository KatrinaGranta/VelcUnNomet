using System.Collections;
using UnityEngine;
//Importē, lai varētu ielādēt ainas
using UnityEngine.SceneManagement;

public class UzPilsetasAinu : MonoBehaviour
{
    //Izdarot klikšķi uz pogas "SacSpelet", tiks atvērta aina "PilsetasAina"
    public void uzIzvelni()
    {
        SceneManager.LoadScene("PilsetasAina", LoadSceneMode.Single);
    }
}