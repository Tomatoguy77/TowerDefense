using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceCount : MonoBehaviour
{
    [SerializeField] private Text _resourceText;
    public float resourceCounter;

    void Start()
    {
        resourceCounter += 400f;
    }

    void Update()
    {
        SetResourceText();
    }

    void SetResourceText()
    {
        _resourceText.text = resourceCounter.ToString();
    }
}
