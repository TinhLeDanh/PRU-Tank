using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.ConstructionStuffList_MenuName, fileName = GameConst.ConstrucionStuffList_FileName, order = GameConst.ConstructionStuffList_Order)]
public class ConstructionStuffListSO : BaseEntityData
{
    public int maxStuffPlayerCanUse;
    public List<ConstructionStuff> stuffList;

    public List<ConstructionStuff> specialStuffList;
}
