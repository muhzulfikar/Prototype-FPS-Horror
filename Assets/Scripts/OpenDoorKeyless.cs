using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoorKeyless : MonoBehaviour
{
    public TMP_Text InstructionText;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public float timerOpen = 3.5f;
    private bool Action = false;

    void Start()
    {
        InstructionText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InstructionText.gameObject.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InstructionText.gameObject.SetActive(false);
            Action = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Action)
        {
            Interact();
        }
    }

    public void Interact()
    {
        InstructionText.gameObject.SetActive(false);
        AnimeObject.GetComponent<Animator>().Play("door_open_out");
        ThisTrigger.SetActive(false);
        Action = false;

        // Memanggil fungsi CloseDoor setelah beberapa detik
        Invoke("CloseDoor", timerOpen);
    }

    void CloseDoor()
    {
        AnimeObject.GetComponent<Animator>().Play("door_close");
        ThisTrigger.SetActive(true);
    }
}
