using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
            Debug.Log("Collided with isle");          
            OpenShop();
    }

    void OpenShop()
    {
        shopPanel.SetActive(true);
        //Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        //Time.timeScale = 1;
    }

 
}
