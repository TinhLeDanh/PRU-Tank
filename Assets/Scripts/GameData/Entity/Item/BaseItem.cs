using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.Item_MenuName, fileName = GameConst.Item_FileName, order = GameConst.Item_Order)]
public class BaseItem : ScriptableObject
{
    public float timeApply;
    public float damageByPercent;
    public int increaseBullet;
    public float speedByPercent;
    public float atkSpeedByPercent;

    public void Apply(CharacterEntity target)
    {
        if(target.data is Tank tankData)
        {
            tankData.damage = (int)(tankData.damage + tankData.damage * damageByPercent);
            tankData.bulletPerShot += increaseBullet;
            tankData.atkSpeed = tankData.atkSpeed + tankData.atkSpeed * atkSpeedByPercent;
            tankData.speed = tankData.speed + tankData.speed * speedByPercent;
        }
    }
}
