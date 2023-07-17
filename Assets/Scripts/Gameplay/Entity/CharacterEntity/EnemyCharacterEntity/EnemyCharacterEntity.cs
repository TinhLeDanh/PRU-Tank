using DefaultNamespace;
using Entity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyCharacterEntity : CharacterEntity
{
    // Start is called before the first frame update
    private Entity.Tank _tank;

    public int[,] _spawnPosition;
    public GameObject _tankBot;

    public float duration;

    private Vector2 baseTarget;
    private Direction moveDirection;
    private int maxX;
    private int maxY;
    private TankMover _tankMover;

    float timeRandomMove = 2;
    float timeCounter;

    protected override void EntityStart()
    {
        base.EntityStart();

        _tank = new Entity.Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = transform.position,
            Guid = GUID.Generate()
        };

        baseTarget = ConstructionController.Instance.basePos;
        maxX = ConstructionController.Instance.width;
        maxY = ConstructionController.Instance.height;
        _tankMover = gameObject.GetComponent<TankMover>();
        timeCounter = timeRandomMove;
        moveDirection = Direction.Left;
    }

    protected override void EntityUpdate()
    {
        base.EntityUpdate();

        //if(timeCounter >= 0)
        //{
        //    timeCounter -= Time.deltaTime;
        //}
        //else
        //{
        //    AutoMovement();
        //    timeCounter = timeRandomMove;
        //}


        //_tankMover.Move(moveDirection);

        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void AutoMovement()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        bool top = false;
        bool left = false;
        bool right = false;
        bool bot = false;
        int nextMove;

        if (y < ConstructionController.Instance.stuffMatrix.GetLength(1) - 1 && ConstructionController.Instance.stuffMatrix[x, y + 1] == -1)
        {
            top = true;
        }
        if (x > 2 && ConstructionController.Instance.stuffMatrix[x - 1, y] == -1)
        {
            left = true;
        }
        if (x < ConstructionController.Instance.stuffMatrix.GetLength(0) - 1 && ConstructionController.Instance.stuffMatrix[x + 1, y] == -1)
        {
            right = true;
        }
        if (y > 1 && ConstructionController.Instance.stuffMatrix[x, y - 1] == -1)
        {
            bot = true;
        }

        if(!top && moveDirection == Direction.Up)
        {
            nextMove = Random.Range(1, 4);

        }
        if (!left && moveDirection == Direction.Left)
        {
            nextMove = Random.Range(2, 4);

        }
        if (!right && moveDirection == Direction.Right)
        {
            nextMove = Random.Range(0, 3);

        }
        if (!top && moveDirection == Direction.Up)
        {
            nextMove = Random.Range(1, 4);

        }

        bool k = false;
        while (!k)
        {
            nextMove = Random.Range(0, 4);
            
            SetMoveDirection(nextMove, top, left, right, bot);
            k = true;
        }
    }

    private void SetMoveDirection(int i, bool top, bool left, bool right, bool bot)
    {
        if (i == 0 && top == true)
        {
            moveDirection = Direction.Up;
        }
        else if (i == 1 && left == true)
        {
            moveDirection = Direction.Left;

        }
        else if (i == 2 && right == true)
        {
            moveDirection = Direction.Right;

        }
        else if (i == 3 && bot == true)
        {
            moveDirection = Direction.Down;

        }
    }

    private void AutoShooting()
    {
        
    }

    private void Fire()
    {
        var b = new Bullet
        {
            Direction = _tank.Direction,
            Tank = _tank,
            InitialPosition = _tank.Position
        };
        GetComponent<TankFirer>().Fire(b);
    }
}
