using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightManager : MonoBehaviour, IInteractable
{
    public GameObject flashlightGround, flashlightPlayer;
    public GameObject grabInstruction;
    private bool isInRange = false;
    
    public void Interact()
    {
        Debug.Log("Flashlight picked up!");
        flashlightGround.SetActive(false);
        grabInstruction.SetActive(false);
        flashlightPlayer.SetActive(true);
    }

    void Update()
    {        
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("MainCamera"))
        {
            isInRange = true;
            grabInstruction.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {        
        if (other.CompareTag("MainCamera"))
        {
            isInRange = false;
            grabInstruction.SetActive(false);
        }
    }
}