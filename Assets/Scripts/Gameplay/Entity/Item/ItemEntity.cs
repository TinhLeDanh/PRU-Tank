using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : MonoBehaviour
{
    public BaseItem data;

    public void SetData(BaseItem data)
    {
        this.data = data;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
