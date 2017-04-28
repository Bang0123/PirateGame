using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shopOpener : MonoBehaviour
{

    public GameObject shopPanel;

    void Update()
    {
        if (Input.GetKey("p")) OpenShop();

    }

    public void Start()
    {
        shopPanel.SetActive(false);
        //shopPanel = GameObject.FindGameObjectWithTag("shopPanel");
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        //Time.timeScale = 1;
    }
}


