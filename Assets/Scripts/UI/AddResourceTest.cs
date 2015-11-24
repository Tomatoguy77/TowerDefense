using UnityEngine;
using System.Collections;

public class AddResourceTest : MonoBehaviour
{
    public void AddResource()
    {
        GameObject.Find("_ResourceCountScript").GetComponent<ResourceCount>().resourceCounter += 200f;
    }
}
