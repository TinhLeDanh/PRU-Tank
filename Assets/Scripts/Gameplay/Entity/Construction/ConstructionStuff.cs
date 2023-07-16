using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionStuff : MonoBehaviour
{
    public int ID { get; set; }
    public ConstructionStuffSO data;
    public int StuffIndex { get; set; }
    private int lifeCounter;
    private BoxCollider2D boxCol;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        lifeCounter = data.lifeCount;

        if (GameInstance.instance != null)
        {
            if (data.canWalkThrough)
            {
                boxCol.isTrigger = true;
            }
            else
            {
                boxCol.isTrigger = false;
            }
        }
        else
        {
            //boxCol.isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            lifeCounter--;
            if(lifeCounter <= 0 && data.canBreak)
            {
                ItemEntity item = data.GetRandomItem();
                if(item != null)
                {
                    Instantiate(item, this.transform.position, Quaternion.identity);
                }

                Destroy(this.gameObject);
            }

            if (data.canShoot)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
