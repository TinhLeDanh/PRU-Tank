using Entity;
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

    public enum StuffState
    {
        Spawned,
        Moved,
    }

    public ConstructionTankState state;

    private int maxX;
    private int maxY;
    public ConstructionStuff _currentStuff;
    public int _currentStuffIndex;
    private ConstructionTankSO constructionData;
    private StuffState stuffState;

    protected override void EntityAwake()
    {
        base.EntityAwake();

    }

    protected override void EntityStart()
    {
        base.EntityStart();

        maxX = ConstructionController.Instance.width;
        maxY = ConstructionController.Instance.height;

        _currentStuffIndex = -1;

        if (data is ConstructionTankSO cData)
            constructionData = cData;
    }

    protected override void EntityUpdate()
    {
        base.EntityUpdate();

    }

    protected override void EntityFixedUpdate()
    {
        base.EntityFixedUpdate();

    }

    protected override void InputHandle()
    {
        ConstructionMovement();
        HandleStuff();
    }

    private void ConstructionMovement()
    {
        Direction dir = Direction.None;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x <= 0)
                return;

            dir = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transform.position.y <= 0)
                return;

            dir = Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x >= maxX)
                return;

            dir = Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (transform.position.y >= maxY)
                return;

            dir = Direction.Up;
        }

        if (dir != Direction.None)
            Move(dir);
    }

    private void HandleStuff()
    {
        if (constructionData != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;

                if (ConstructionController.Instance.stuffMatrix[x, y] == -1)
                {
                    _currentStuff = null;
                    state = ConstructionTankState.None;
                }
                else if (ConstructionController.Instance.stuffMatrix[(int)transform.position.x, (int)transform.position.y] != -1)
                {
                    state = ConstructionTankState.OnStuff;
                    foreach(ConstructionStuff cons in ConstructionController.Instance.stuffs)
                    {
                        if(cons.transform.position.x == x && cons.transform.position.y == y)
                        {
                            _currentStuff = cons;
                            break;
                        }
                    }
                }

                if ((_currentStuff != null && _currentStuff.StuffIndex == _currentStuffIndex)
                    || (_currentStuff == null && _currentStuffIndex == -1))
                    _currentStuffIndex++;

                if (_currentStuffIndex >= constructionData.stuffs.maxStuffPlayerCanUse)
                {
                    _currentStuffIndex = -1;
                }

                if (constructionData.ApplyStuff(_currentStuffIndex, transform.position, state == ConstructionTankState.OnStuff, _currentStuff) != null)
                {
                    state = ConstructionTankState.OnStuff;
                    stuffState = StuffState.Spawned;
                }

            }
        }        
    }
}
