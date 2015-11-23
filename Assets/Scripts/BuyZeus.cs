using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyZeus : MonoBehaviour 
{
    [SerializeField] private GameObject _turretZeus;
    [SerializeField] private GameObject _turretPoint;

    private void OnMouseDown()
    {
        GameObject resourceObj = GameObject.Find("_ResourceCountScript");
        ResourceCount resourceScript = resourceObj.GetComponent<ResourceCount>();
        
        if (resourceScript.resourceCounter >= 200)
        {
            print("Spawn Zeus");
            GameObject zeusPrefab = Instantiate(_turretZeus, _turretPoint.transform.position, transform.rotation) as GameObject;
            resourceScript.resourceCounter -= 200;
            _turretPoint.SetActive(false);
        }

        else
        {
            print("Not Enough resources!");
            //Moet nog een text laten weergeven.
        }
    }
}
