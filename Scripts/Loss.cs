using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loss : MonoBehaviour
{
    public void LossState()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
