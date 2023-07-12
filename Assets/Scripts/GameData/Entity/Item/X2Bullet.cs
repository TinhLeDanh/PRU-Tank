using UnityEngine;

namespace GameData.Entity.Item
{
    [CreateAssetMenu(menuName = GameConst.X2Bullet_FileName, fileName = GameConst.X2Bullet_MenuName, order = GameConst.X2Bullet_Order)]
    public class X2Bullet : BaseItem
    {
        public int NumberBullet { get; set; }
    }
}