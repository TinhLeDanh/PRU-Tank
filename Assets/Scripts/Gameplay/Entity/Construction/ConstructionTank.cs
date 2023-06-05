using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionTankController : MonoBehaviour
{
    public enum ConstructionTankState
    {
        None,
        OnStuff
    }

    public ConstructionTankState state;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Stuff"))
        {
            Debug.Log(1);
        }
    }
}
