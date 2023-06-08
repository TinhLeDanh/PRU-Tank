using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.ConstructionTank_MenuName, fileName = GameConst.ConstrucionTank_FileName, order = GameConst.ConstructionTank_Order)]
public class ConstructionTankSO : Tank
{
    [SerializeField]
    public ConstructionStuffListSO stuffs;

    public ConstructionStuff ApplyStuff(int order, Vector2 position, bool isOnAnotherStuff = false, ConstructionStuff currentStuff = null)
    {
        if (isOnAnotherStuff && currentStuff != null)
        {
            Destroy(currentStuff.gameObject);

        }

        GameObject go = Instantiate(stuffs.stuffList[order].gameObject, position + stuffs.stuffList[order].offset, Quaternion.identity);
        ConstructionStuff constructionStuff = go.GetComponent<ConstructionStuff>();
        constructionStuff.StuffIndex = order;

        if (ConstructionController.Instance != null)
            ConstructionController.Instance.ApplyStuffToMatrix((int)position.x, (int)position.y, order);

        return constructionStuff;
    }
}
