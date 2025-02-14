using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject Inticon, Key, signOne, signTwo;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Inticon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Key.SetActive(false);
                Door.keyFound = true;
                Inticon.SetActive(false);
                signOne.SetActive(true);
                signTwo.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Inticon.SetActive(false);
        }
    }
}
