using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.ConstructionStuff_MenuName, fileName = GameConst.ConstrucionStuff_FileName, order = GameConst.ConstructionStuff_Order)]
public class ConstructionStuffSO : BaseEntityData
{
    public bool canBuild = true;
    public bool canBreak;
    public bool canWalkThrough;
    public bool canShoot;
    public int lifeCount;

    public List<ItemEntity> items;

    public ItemEntity GetRandomItem()
    {
        if(items == null || items.Count <= 0)
        {
            return null;
        }
        int rand = Random.Range(0, items.Count - 1);
        return items[rand];
    }
}
