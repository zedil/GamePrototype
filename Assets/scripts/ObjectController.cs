using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
       // Debug.Log("Touched: " + other);

        if(controller != null)
        {
            controller.ChangeScale();
            Destroy(gameObject);
        }
    }
}
