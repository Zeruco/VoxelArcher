using UnityEngine;

public class UIController : MonoBehaviour
{
    private bool _gameIsPaused = false;

    public void PauseOrResumeGame()
    {
        if(_gameIsPaused == false)
        {
            Time.timeScale = 0;
            _gameIsPaused = !_gameIsPaused;
        }
        else 
        {
            Time.timeScale = 1;
            _gameIsPaused = !_gameIsPaused;
        }
    }


}
