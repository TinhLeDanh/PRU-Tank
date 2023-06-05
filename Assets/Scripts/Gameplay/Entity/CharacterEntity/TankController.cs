using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TankController : PlayerCharacterEntity
{
    // Start is called before the first frame update
    private Entity.Tank _tank;

    [Header("Sprite")]
    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;

    [Header("Movement")]
    public InputMovementType inputMovementType;

    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    public new GameObject camera;

    private void Start()
    {
        _tank = new Entity.Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            //Position = new Vector3(Random.Range(0, 20), Random.Range(0, 20), 0),
            Position = new Vector3(1, 0, 0),
            Guid = GUID.Generate()
        };

        if (camera == null)
            camera = Camera.main.gameObject;

        //gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _cameraController = camera.GetComponent<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
    }

    // Update is called once per frame
    private void Update()
    {
        InputHandle();

        if (data is ConstructionTankSO constructionData)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                constructionData.ApplyStuff(0, transform.position);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                constructionData.ApplyStuff(1, transform.position);
            }
        }
        
    }

    private void InputHandle()
    {
        Direction dir = Direction.None;

        if (inputMovementType == InputMovementType.MoveByKey)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                dir = Direction.Left;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                dir = Direction.Down;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                dir = Direction.Right;
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                dir = Direction.Up;
            }
        }
        else if (inputMovementType == InputMovementType.MoveByKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                dir = Direction.Left;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                dir = Direction.Down;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                dir = Direction.Right;
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                dir = Direction.Up;
            }
        }

        if (dir != Direction.None)
            Move(dir);

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Move(Direction direction)
    {
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        if (_cameraController != null)
            _cameraController.Move(_tank.Position);
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
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