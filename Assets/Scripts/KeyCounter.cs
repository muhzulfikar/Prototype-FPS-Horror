using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    public TMP_Text keyCountText;
    private int keyCount = 0;

    void Start()
    {        
        UpdateKeyCountText();
    }

    public void IncrementKeyCount()
    {
        keyCount++;
        UpdateKeyCountText();
    }

    void UpdateKeyCountText()
    {
        // Menampilkan jumlah kunci
        keyCountText.text = "Kunci: " + keyCount.ToString();
    }
}
