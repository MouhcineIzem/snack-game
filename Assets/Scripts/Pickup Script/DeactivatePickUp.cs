using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("deactivate", Random.Range(3f, 6f));
    }

    void deactivate()
    {
        gameObject.SetActive(false);
    }
}
