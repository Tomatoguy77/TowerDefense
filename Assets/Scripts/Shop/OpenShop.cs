using UnityEngine;
using System.Collections;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject _turretSelecter;

    private void OnMouseDown()
    {
        _turretSelecter.SetActive(true);
    }
    
}
