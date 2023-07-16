using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.Item_MenuName, fileName = GameConst.Item_FileName, order = GameConst.Item_Order)]
public class BaseItem : ScriptableObject
{
    public float timeApply;
    public int damage;
    public int increaseBullet;
    public float speedByPercent;

    public void Apply(CharacterEntity target)
    {
        if(target.data is Tank tankData)
        {
            tankData.damage += damage;
            //tankData.damage += damage;
            //tankData.damage += damage;
            tankData.speed = tankData.speed + tankData.speed * speedByPercent;
        }
    }
}
