using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightManager : MonoBehaviour, IInteractable
{
    public GameObject flashlightGround, flashlightPlayer;
    public GameObject grabInstruction;  // Menyimpan referensi ke objek teks instruksi
    private bool isInRange = false; // Menandakan apakah kamera di dalam trigger area

    // Implementasi Interact dari interface IInteractable
    public void Interact()
    {
        Debug.Log("Flashlight picked up!");
        flashlightGround.SetActive(false);  // Menonaktifkan flashlight di ground
        grabInstruction.SetActive(false);  // Menyembunyikan instruksi saat interaksi
        flashlightPlayer.SetActive(true);  // Mengaktifkan flashlight pada player
    }

    void Update()
    {
        // Mengecek apakah pemain menekan tombol E saat berada dalam trigger area
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact(); // Memanggil fungsi Interact() saat E ditekan
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Memastikan interaksi hanya dengan kamera utama (player)
        if (other.CompareTag("MainCamera"))
        {
            isInRange = true; // Menandakan bahwa kamera berada di dalam trigger area
            grabInstruction.SetActive(true);  // Menampilkan instruksi saat memasuki trigger area
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Menyembunyikan instruksi saat keluar dari trigger area
        if (other.CompareTag("MainCamera"))
        {
            isInRange = false; // Menandakan bahwa kamera keluar dari trigger area
            grabInstruction.SetActive(false); // Menyembunyikan instruksi
        }
    }
}