using System;
using UnityEngine;
using NaughtyAttributes;
using Nova;
using NovaSamples.UIControls;

public class pauseManager : MonoBehaviour
{
    [Required] 
    public GameObject pausePanel;
    public bool gamePaused;
    [Required]
    public Slider sliderUI;
    [Required] 
    public Toggle toggleUI;

    public AudioClip pauseClip;
    public AudioClip unpauseClip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pausePanel.SetActive(gamePaused);
        if (Input.GetButtonUp("pause"))
        {
            if (!gamePaused)
            {
                pauseGame();
            }
            else
            {
                unpauseGame();
            }
        }
    }

    private void pauseGame()
    {
        gamePaused = true;
        toggleUI.ToggledOn = gameManager.instance.gameSettings.invertY;
        sliderUI.Value = gameManager.instance.gameSettings.volume;
        gameManager.instance.SpawnSound(pauseClip);
    }

    private void unpauseGame()
    {
        gameManager.instance.SpawnSound(unpauseClip);
        gamePaused = false;
    }
    public void resumeClicked()
    {
        unpauseGame();
    }

    public void quitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        
    }

    public void invertYChanged(bool value)
    {
        gameManager.instance.gameSettings.invertY = value;
    }

    public void volumeChanged(Single value)
    {
        gameManager.instance.gameSettings.volume = value;
    }
}
