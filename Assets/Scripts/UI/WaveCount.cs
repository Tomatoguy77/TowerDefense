using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveCount : MonoBehaviour
{
    [SerializeField]
    private Text _waveText;
    public float waveCounter;

    void Update()
    {
        SetWaveText();
        
        if (waveCounter > 10)
        {
            waveCounter = 10;
        }
    }

    void SetWaveText()
    {
        _waveText.text = "Wave: " + waveCounter.ToString() + "/10";
    }
}