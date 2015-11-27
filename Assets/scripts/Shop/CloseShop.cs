using UnityEngine;
using System.Collections;

public class CloseShop : MonoBehaviour
{
    [SerializeField] private GameObject _turretShop;

    private void OnMouseDown()
    {
        _turretShop.SetActive(false);
    }
}
