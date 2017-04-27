using UnityEngine;
using System.Collections;


public class MissionButtonWhenClicked : MonoBehaviour
{

    public GameObject mass;

    public void Clicked()
    {
        mass.SetActive(true);

    }
}
