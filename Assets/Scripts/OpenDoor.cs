using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public TMP_Text InstructionText;  // Referensi ke Text untuk instruksi pintu
    public TMP_Text NeededKeyText;  // Referensi ke Text untuk instruksi kunci dibutuhkan
    public GameObject AnimeObject;  // Objek animasi pintu
    public GameObject ThisTrigger;  // Trigger pintu
    public AudioSource DoorOpenSound;  // Suara pintu terbuka
    public float timerOpen = 3.5f;  // Durasi pintu terbuka
    private bool Action = false;  // Menandakan apakah interaksi dengan pintu bisa dilakukan

    void Start()
    {
        InstructionText.gameObject.SetActive(false);  // Menyembunyikan instruksi pintu pada awalnya
        NeededKeyText.gameObject.SetActive(false);  // Menyembunyikan instruksi kunci pada awalnya
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!KeyManager.HasKey)  // Jika pemain belum memiliki kunci
            {
                NeededKeyText.gameObject.SetActive(true);  // Menampilkan instruksi kunci dibutuhkan
                InstructionText.gameObject.SetActive(false);  // Menyembunyikan instruksi pintu
            }
            else  // Jika pemain sudah memiliki kunci
            {
                InstructionText.gameObject.SetActive(true);  // Menampilkan instruksi pintu                
                NeededKeyText.gameObject.SetActive(false);  // Menyembunyikan instruksi kunci dibutuhkan
            }

            Action = true;  // Menandakan bahwa pemain dapat berinteraksi dengan pintu
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InstructionText.gameObject.SetActive(false);  // Menyembunyikan instruksi pintu saat pemain keluar dari trigger pintu
            NeededKeyText.gameObject.SetActive(false);  // Menyembunyikan instruksi kunci saat pemain keluar dari trigger pintu
            Action = false;  // Menonaktifkan interaksi
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Action && KeyManager.HasKey)
        {
            Interact();  // Memanggil metode Interact() jika pemain menekan E dan memiliki kunci
        }
    }

    // Implementasi Interact dari interface IInteractable
    public void Interact()
    {
        InstructionText.gameObject.SetActive(false);  // Menyembunyikan instruksi pintu setelah pintu dibuka
        AnimeObject.GetComponent<Animator>().Play("door_open_out");

        ThisTrigger.SetActive(false);  // Menonaktifkan trigger pintu untuk mencegah interaksi lebih lanjut
        Action = false;

        // Memanggil fungsi CloseDoor setelah beberapa detik
        Invoke("CloseDoor", timerOpen);
    }

    void CloseDoor()
    {
        AnimeObject.GetComponent<Animator>().Play("door_close");
        ThisTrigger.SetActive(true);  // Menyembunyikan trigger pintu setelah pintu tertutup
    }
}