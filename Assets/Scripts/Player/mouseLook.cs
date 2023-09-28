using Unity.Mathematics;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public pauseManager pause;
    public gameManager manager;

    public float sharpness = 15f;
    public Vector2 input = Vector2.zero;
    public float lookSpeed = 10;

    public Transform body;
    public Transform cam;

    public Vector2 rot;
    public Vector2 rotClampX= new Vector2(-90,90);
    
    private void Start()
    {
        pause = GameObject.FindObjectOfType<pauseManager>();
        manager = gameManager.instance;
    }

    private void Update()
    {
        if (!pause.gamePaused)
        {
            //if the game is not paused
            updateInput();
            updateRot();
        }
        else
        {
            //the game is paused
        }
    }

    private void updateInput()
    {
        float invert = 1;
        if (gameManager.instance.gameSettings.invertY)
        {
            invert = -1;
        }
        Vector2 goal = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * invert);
        input = gameManager.smoothLerp(input, goal, sharpness);
    }

    private void updateRot()
    {
        rot = rot + input * lookSpeed;
        rot.y = Mathf.Clamp(rot.y, rotClampX.x, rotClampX.y);

        cam.rotation = Quaternion.Euler(rot.y, rot.x, 0);
        body.localRotation = quaternion.Euler(0, rot.x, 0);
    }
}
