using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.ConstructionTank_MenuName, fileName = GameConst.ConstrucionTank_FileName, order = GameConst.ConstructionTank_Order)]
public class ConstructionTank : Tank
{
    [SerializeField]
    public List<ConstructionStuffController> stuffs;

    public void ApplyStuff(int order, Vector2 position)
    {
        GameObject go = Instantiate(stuffs[order].gameObject, position + stuffs[order].offset, Quaternion.identity);

    }
}
