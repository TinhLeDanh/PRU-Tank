using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionStuff : MonoBehaviour
{
    public int ID { get; set; }
    public int StuffIndex { get; set; }
    public ConstructionStuffSO data;

    private int lifeCounter;
    private BoxCollider2D boxCol;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();

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
}
