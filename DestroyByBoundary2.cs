using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary2 : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Asteroid(Clone)")
            Destroy(other.gameObject);
    }
}
