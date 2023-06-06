using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ConstructionTankController : TankController
{
    public enum ConstructionTankState
    {
        None,
        OnStuff
    }

    public ConstructionTankState state;

    private ConstructionStuff _currentStuff;
    private int _currentStuffIndex;
    private ConstructionTankSO constructionData;
    private RaycastHit2D raycastHit;

    protected override void EntityStart()
    {
        base.EntityStart();

        _currentStuffIndex = -1;

        if (data is ConstructionTankSO cData)
            constructionData = cData;
    }

    protected override void EntityUpdate()
    {
        base.EntityUpdate();

        if (constructionData != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                _currentStuffIndex++;
                if (_currentStuffIndex >= constructionData.stuffs.stuffList.Count)
                {
                    _currentStuffIndex = 0;
                }

                constructionData.ApplyStuff(_currentStuffIndex,
                    transform.position, state == ConstructionTankState.OnStuff, _currentStuff);

                state = ConstructionTankState.OnStuff;
            }
        }

        raycastHit = Physics2D.CircleCast(transform.position, .05f, transform.forward, .05f);
        if (raycastHit.collider == null)
        {
            Debug.DrawRay(transform.position, raycastHit.point, Color.white);
            _currentStuff = null;
            state = ConstructionTankState.None;
            _currentStuffIndex = -1;
        }
        else if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Stuff"))
        {
            Debug.DrawRay(transform.position, raycastHit.point, Color.black);
            state = ConstructionTankState.OnStuff;
            _currentStuff = raycastHit.collider.gameObject.GetComponent<ConstructionStuff>();
            _currentStuffIndex = _currentStuff.StuffIndex;
        }
    }

    protected override void EntityFixedUpdate()
    {
        base.EntityFixedUpdate();

        
    }
}
