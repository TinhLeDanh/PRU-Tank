using System;
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

    public ConstructionTankState state;

    private int maxX;
    private int maxY;
    private ConstructionStuff _currentStuff;
    public int _currentStuffIndex;
    private ConstructionTankSO constructionData;
    private RaycastHit2D raycastHit;
    
    private bool delayBtnUp = true;
    private bool delayBtnDown = true;
    private bool delayBtnLeft = true;
    private bool delayBtnRight = true;
    private float delayTime = 0.4f;

    public GameObject gameObject;
    public bool blinking;
    protected override void EntityStart()
    {

        StartCoroutine(Blink(gameObject));
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
            if (delayBtnLeft)
            {
                StartCoroutine(DelayBtnLeft());
                if (transform.position.x <= 0)
                    return;

                dir = Direction.Left;
            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && delayBtnLeft)
            {
                StartCoroutine(DelayBtnLeft());
                if (transform.position.x <= 0)
                    return;

                dir = Direction.Left;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (delayBtnDown)
            {
                StartCoroutine(DelayBtnDown());
                if (transform.position.y <= 0)
                    return;

                dir = Direction.Down;
            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && delayBtnDown)
            {
                StartCoroutine(DelayBtnDown());
                if (transform.position.y <= 0)
                    return;

                dir = Direction.Down;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (delayBtnRight)
            {
                StartCoroutine(DelayBtnRight());
                if (transform.position.x >= maxX)
                    return;

                dir = Direction.Right;
            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && delayBtnRight)
            {
                StartCoroutine(DelayBtnRight());
                if (transform.position.x >= maxX)
                    return;

                dir = Direction.Right;
            }
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (delayBtnUp)
            {
                StartCoroutine(DelayBtnUp());
                if (transform.position.y >= maxY)
                    return;
                dir = Direction.Up;
            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && delayBtnUp)
            {
                StartCoroutine(DelayBtnUp());
                if (transform.position.y >= maxY)
                    return;

                dir = Direction.Up;
            }
        }

        if (dir != Direction.None)
            Move(dir);
    }
    IEnumerator Blink(GameObject obj)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        blinking = true;
        while(blinking)
        {
            objRenderer.enabled = false;
            yield return new WaitForSeconds(0.5f);
            objRenderer.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }

    }
    private void HandleStuff()
    {
        if (constructionData != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if ((_currentStuff != null && _currentStuff.StuffIndex == _currentStuffIndex)
                    || (_currentStuff == null && _currentStuffIndex == -1))
                    _currentStuffIndex++;

                if (_currentStuffIndex >= constructionData.stuffs.maxStuffPlayerCanUse)
                {
                    _currentStuffIndex = -1;
                }

                if (constructionData.ApplyStuff(_currentStuffIndex, transform.position, state == ConstructionTankState.OnStuff, _currentStuff) != null)
                    state = ConstructionTankState.OnStuff;
                ;

            }
        }

        raycastHit = Physics2D.CircleCast(transform.position, .05f, transform.forward, .05f);
        if (raycastHit.collider == null)
        {
            _currentStuff = null;
            state = ConstructionTankState.None;
        }
        else if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Stuff"))
        {
            state = ConstructionTankState.OnStuff;
            _currentStuff = raycastHit.collider.gameObject.GetComponent<ConstructionStuff>();
        }
    }
    IEnumerator DelayBtnUp()
    {
        delayBtnUp = false; // Đang delay

        yield return new WaitForSeconds(delayTime); // Tạm dừng thực thi của hàm trong 0.5 giây

        delayBtnUp = true; // Kết thúc delay
    }

    IEnumerator DelayBtnDown()
    {
        delayBtnDown = false; // Đang delay

        yield return new WaitForSeconds(delayTime); // Tạm dừng thực thi của hàm trong 0.5 giây

        delayBtnDown = true; // Kết thúc delay
    }

    IEnumerator DelayBtnLeft()
    {
        delayBtnLeft = false; // Đang delay

        yield return new WaitForSeconds(delayTime); // Tạm dừng thực thi của hàm trong 0.5 giây

        delayBtnLeft = true; // Kết thúc delay
    }

    IEnumerator DelayBtnRight()
    {
        delayBtnRight = false; // Đang delay

        yield return new WaitForSeconds(delayTime); // Tạm dừng thực thi của hàm trong 0.5 giây

        delayBtnRight = true; // Kết thúc delay
    }
}