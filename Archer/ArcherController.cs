using UnityEngine;

public class ArcherController : MonoBehaviour
{
    [SerializeField] private JoystickLoader _joystickLoader;
    [SerializeField] private ShootPosition _shootPosition;
    [SerializeField] private float _constantSpeed;
    [SerializeField] private PlayerArrow _arrow;

    private Bow[] _archersBows;
    private Vector3 _startDragPosition;

    private void Start()
    {
        _archersBows = GetComponentsInChildren<Bow>();
        _startDragPosition = _shootPosition.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LoadShoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_joystickLoader.ImageIsLoaded)
            {
                DragRelease();
            }

            _joystickLoader.HideJoystick();
        }
    }

    private void LoadShoot()
    {
        _joystickLoader.LoadJoystick();

        if (_joystickLoader.ImageIsLoaded)
        {
            float speed = _constantSpeed * _joystickLoader.GetAccelerationFactor();
            _shootPosition.MoveShootTarget(speed);
        }
    }

    private void DragRelease()
    {
        for (int i = 0; i < _archersBows.Length; i++)
        {
            Vector3 direction = _shootPosition.GetShootDirection();
            _archersBows[i].Shoot(direction, _arrow);
        }

        _shootPosition.transform.position = _startDragPosition;
    }
}
