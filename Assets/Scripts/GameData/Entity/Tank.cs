using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.Tank_MenuName, fileName = GameConst.Tank_FileName, order = GameConst.Tank_Order)]
public class Tank : BaseEntityData
{
    public string tankName;
    public int damage;
    public int health;
    public float speed;
    public float atkSpeed;
    public int bulletPerShot;
}
