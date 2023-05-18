using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.Tank_MenuName, fileName = GameConst.Tank_FileName, order = GameConst.Tank_Order)]
public class TankSO : ScriptableObject
{
    public string tankName;
    public int health;
    public float speed;
}
