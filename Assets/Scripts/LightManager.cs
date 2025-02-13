using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject flashlightGround, Inticon, flashlightPlayer;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Inticon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                flashlightGround.SetActive(false);
                Inticon.SetActive(false);
                flashlightPlayer.SetActive(true);
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
