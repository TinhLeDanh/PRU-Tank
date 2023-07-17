using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private int maxX;
    private int maxY;

    protected override void EntityStart()
    {
        base.EntityStart();

        maxX = ConstructionController.Instance.width;
        maxY = ConstructionController.Instance.height;

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
            if (transform.position.x <= 0)
                return;
            Move(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y <= 0)
                return;
            Move(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x >= maxX)
                return;
            Move(Direction.Right);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y >= maxY)
                return;
            Move(Direction.Up);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }

    protected void Move(Direction direction)
    {
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        //if (_cameraController != null)
        //    _cameraController.Move(_tank.Position);
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