using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.ConstructionTank_MenuName, fileName = GameConst.ConstrucionTank_FileName, order = GameConst.ConstructionTank_Order)]
public class ConstructionTankSO : Tank
{
    [SerializeField]
    public ConstructionStuffListSO stuffs;

    public void ApplyStuff(int order, Vector2 position)
    {
        GameObject go = Instantiate(stuffs.stuffList[order].gameObject, position + stuffs.stuffList[order].offset, Quaternion.identity);

    }
}
