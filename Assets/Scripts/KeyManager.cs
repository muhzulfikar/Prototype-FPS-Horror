using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour, IInteractable
{
    public GameObject keyGround, grabInstruction;  // Objek kunci di tanah dan instruksi interaksi
    private bool isInRange = false;  // Menandakan apakah pemain berada dalam trigger area
    public static bool HasKey = false;  // Menandakan apakah pemain memiliki kunci

    // Implementasi Interact dari interface IInteractable
    public void Interact()
    {
        Debug.Log("Key picked up!");
        keyGround.SetActive(false);  // Menonaktifkan kunci di tanah
        grabInstruction.SetActive(false);  // Menyembunyikan ikon interaksi

        // Mengubah status pemain sudah memiliki kunci
        HasKey = true;

        Destroy(gameObject);  // Menghancurkan objek kunci setelah diambil
    }

    void Update()
    {
        // Mengecek apakah pemain menekan tombol E saat berada dalam trigger area
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();  // Memanggil fungsi Interact() saat E ditekan
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Memastikan interaksi hanya dengan pemain (dalam hal ini, objek dengan tag "Player")
        if (other.CompareTag("MainCamera"))
        {
            isInRange = true;  // Menandakan bahwa pemain berada di dalam trigger area
            grabInstruction.SetActive(true);  // Menampilkan ikon interaksi saat memasuki trigger area
            grabInstruction.GetComponent<TMP_Text>().text = "Press [E] for grab Key";  // Menampilkan instruksi
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Menyembunyikan ikon interaksi saat keluar dari trigger area
        if (other.CompareTag("MainCamera"))
        {
            isInRange = false;  // Menandakan bahwa pemain keluar dari trigger area
            grabInstruction.SetActive(false);  // Menyembunyikan ikon interaksi
        }
    }
}