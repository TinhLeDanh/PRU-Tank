using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.GameData_MenuName, fileName = GameConst.GameData_FileName, order = GameConst.GameData_Order)]
public class BaseGameData : ScriptableObject
{
    public List<BaseItem> Items;
}
