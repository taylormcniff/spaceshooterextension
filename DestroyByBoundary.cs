using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Bolt(Clone)")
            Destroy(other.gameObject);
    }
}