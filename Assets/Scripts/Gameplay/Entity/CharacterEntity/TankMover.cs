using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class TankMover : BaseGameEntityComponent<BaseGameEntity>
{
    // Start is called before the first frame update

    public float speed;

    public bool moveByCells;

    void Start()
    {
        speed = 1;
    }

    public override void EntityUpdate()
    {
        base.EntityUpdate();
    }

    public Vector3 Move(Direction direction)
    {
        var currentPos = gameObject.transform.position;
        if (!moveByCells)
        {
            switch (direction)
            {
                case Direction.Down:
                    currentPos.y -= speed * Time.deltaTime;
                    break;
                case Direction.Left:
                    currentPos.x -= speed * Time.deltaTime;
                    break;
                case Direction.Right:
                    currentPos.x += speed * Time.deltaTime;
                    break;
                case Direction.Up:
                    currentPos.y += speed * Time.deltaTime;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        else
        {
            switch (direction)
            {
                case Direction.Down:
                    currentPos.y -= 1;
                    break;
                case Direction.Left:
                    currentPos.x -= 1;
                    break;
                case Direction.Right:
                    currentPos.x += 1;
                    break;
                case Direction.Up:
                    currentPos.y += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        

        gameObject.transform.position = currentPos;
        return currentPos;
    }

    
}