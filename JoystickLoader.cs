using UnityEngine;
using UnityEngine.UI;

public class JoystickLoader : MonoBehaviour
{
    [SerializeField] private Image _joystickBorderImage;
    [SerializeField] private Image _joystickHandleImage;

    private float _pressedTime;
    private bool _imageIsLoaded;
    public bool ImageIsLoaded => _imageIsLoaded;

    public void LoadJoystick()
    {
        _pressedTime += Time.deltaTime;

        _joystickBorderImage.fillAmount = _pressedTime / 1;
        _joystickHandleImage.fillAmount = _pressedTime / 1;

        if (_pressedTime / 1 >= 1)
        {
            _imageIsLoaded = true;
        }
    }

    public void HideJoystick()
    {
        _pressedTime = 0;
        _imageIsLoaded = false;
        _joystickBorderImage.fillAmount = 0;
        _joystickHandleImage.fillAmount = 0;
    }

    public float GetAccelerationFactor()
    {
        return Vector3.Distance(_joystickBorderImage.transform.position, _joystickHandleImage.transform.position);
    }
}
