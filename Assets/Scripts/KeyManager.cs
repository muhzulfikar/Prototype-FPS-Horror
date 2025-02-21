using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour, IInteractable
{
    public GameObject keyGround, grabInstruction;
    private bool isInRange = false;
    public static bool HasKey = false;
    public KeyCounter keyCounter;

    public void Interact()
    {
        Debug.Log("Key picked up!");
        keyGround.SetActive(false);
        grabInstruction.SetActive(false);

        HasKey = true;
        
        keyCounter.IncrementKeyCount();

        Destroy(gameObject);
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
