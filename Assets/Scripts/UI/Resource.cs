using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private Text _resourceText;
    public float resourceCounter;

    void Update()
    {
        SetResourceText();
    }

    void SetResourceText()
    {
        _resourceText.text = "Resource: " + resourceCounter.ToString();
    }
}
