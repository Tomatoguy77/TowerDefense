using UnityEngine;
using System.Collections;

public class AddResourceTest : MonoBehaviour
{
	
    public void AddResource()
    {
        GameObject.Find("_ResourceScript").GetComponent<Resource>().resourceCounter += 200f;
    }
}
