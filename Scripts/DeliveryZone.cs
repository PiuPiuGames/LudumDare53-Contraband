using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public GameObject winScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "package")
            winScreen.SetActive(true);
    }
}
