using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
          Debug.Log("Help me");
        //if (other.gameObject.tag == "Player")
          if (other.gameObject.CompareTag("Player"))
          Debug.Log("Collided with isle");
          OpenShop();
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("Help me");
    //    if (other.gameObject.tag == "Player")
    //        Debug.Log("Collided with isle");
    //        OpenShop();
    //}


    private void Start()
    {
        shopPanel = GameObject.FindGameObjectWithTag("shopPanel");
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
