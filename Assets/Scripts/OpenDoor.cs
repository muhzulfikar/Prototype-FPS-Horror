using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public TMP_Text InstructionText;
    public TMP_Text NeededKeyText;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public float timerOpen = 3.5f;
    private bool Action = false;
    private bool doorOpened = false;
    public KeyManager keyManager;

    void Start()
    {
        InstructionText.gameObject.SetActive(false);
        NeededKeyText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!doorOpened && !KeyManager.HasKey)
            {
                NeededKeyText.gameObject.SetActive(true);
                InstructionText.gameObject.SetActive(false);
            }
            else
            {
                InstructionText.gameObject.SetActive(true);
                NeededKeyText.gameObject.SetActive(false);
            }

            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InstructionText.gameObject.SetActive(false);
            NeededKeyText.gameObject.SetActive(false);
            Action = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Action && (KeyManager.HasKey || doorOpened))  // Cek apakah pintu bisa dibuka
        {
            Interact();
        }
    }

    // Implementasi Interact dari interface IInteractable
    public void Interact()
    {
        if (!doorOpened && KeyManager.HasKey)  // Jika pintu belum dibuka dan pemain memiliki kunci
        {
            InstructionText.gameObject.SetActive(false);
            AnimeObject.GetComponent<Animator>().Play("door_open_out");

            ThisTrigger.SetActive(false);
            Action = false;

            // Panggil fungsi CloseDoor setelah beberapa detik
            Invoke("CloseDoor", timerOpen);
            doorOpened = true;
            KeyManager.HasKey = false;
        }
        else if (doorOpened)
        {
            InstructionText.gameObject.SetActive(false);
            AnimeObject.GetComponent<Animator>().Play("door_open_out");

            ThisTrigger.SetActive(false);
            Action = false;

            // Memanggil fungsi CloseDoor setelah beberapa detik
            Invoke("CloseDoor", timerOpen);
        }
    }

    void CloseDoor()
    {
        AnimeObject.GetComponent<Animator>().Play("door_close");
        ThisTrigger.SetActive(true);
    }
}
