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
    }

    void SetWaveText()
    {
        _waveText.text = "Wave: " + waveCounter.ToString() + "/10";
    }
}