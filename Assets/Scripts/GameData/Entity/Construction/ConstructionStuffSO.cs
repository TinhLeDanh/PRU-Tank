using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.ConstructionStuff_MenuName, fileName = GameConst.ConstrucionStuff_FileName, order = GameConst.ConstructionStuff_Order)]
public class ConstructionStuffSO : BaseEntityData
{
    public bool canBreak;
    public bool canWalkThrough;
    public int lifeCount;
}
