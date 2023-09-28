using UnityEngine;

public class motor : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 velocity;

    public float gravity = -9.8f;
    public float moveSpeed;

    public Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //apply gravity
        velocity += new Vector3(0, gravity * Time.deltaTime, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        velocity += transform.forward * moveSpeed * input.y;
        velocity += transform.right * moveSpeed * input.x;

        controller.Move(velocity);
        velocity = gameManager.smoothLerp(velocity, Vector3.zero, 25);
    }
}
