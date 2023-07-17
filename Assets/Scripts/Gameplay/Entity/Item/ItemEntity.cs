using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : BaseGameEntity
{
    public BaseItem itemData;

    public void SetData(BaseItem data)
    {
        this.itemData = data;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            itemData.Apply(collision.GetComponent<CharacterEntity>());
            Destroy(this.gameObject);
        }
    }
}
