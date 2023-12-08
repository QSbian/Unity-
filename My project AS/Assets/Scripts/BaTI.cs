using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaTI : MonoBehaviour
{
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.Invincibility(1);
            Destroy(gameObject);
        }
    }
}