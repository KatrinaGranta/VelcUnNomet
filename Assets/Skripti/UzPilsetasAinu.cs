using System.Collections;
using UnityEngine;
//Importē, lai varētu ielādēt ainas
using UnityEngine.SceneManagement;

public class UzPilsetasAinu : MonoBehaviour
{
    //Izdarot klikšķi uz pogas "Retry", tiks atvērta aina "GalvenaAina"
    public void uzGalveno()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}