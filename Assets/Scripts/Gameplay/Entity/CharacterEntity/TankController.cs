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

    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    public new GameObject camera;

    protected override void EntityStart()
    {
        base.EntityStart();

        _tank = new Entity.Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = new Vector3(1, 0, 0),
            Guid = GUID.Generate()
        };

        if (camera == null)
            camera = Camera.main.gameObject;

        //gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _cameraController = camera.GetComponent<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    protected override void EntityUpdate()
    {
        base.EntityUpdate();

        InputHandle();
    }

    protected virtual void InputHandle()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Move(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(Direction.Right);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Move(Direction.Up);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    protected void Move(Direction direction)
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