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
            foreach (ConstructionStuff cons in ConstructionController.Instance.stuffs)
            {
                if (cons.transform.position.x == position.x && cons.transform.position.y == position.y)
                {
                    ConstructionController.Instance.stuffs.Remove(cons);
                    break;
                }
            }

            Destroy(currentStuff.gameObject);

        }

        if (order == -1)
            return null;

        GameObject go = Instantiate(stuffs.stuffList[order].gameObject, position, Quaternion.identity);
        ConstructionStuff constructionStuff = go.GetComponent<ConstructionStuff>();
        constructionStuff.StuffIndex = order;

        if (ConstructionController.Instance != null)
            ConstructionController.Instance.ApplyStuffToMatrix((int)position.x, (int)position.y, order, constructionStuff);

        return constructionStuff;
    }
}
