using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(AudioSource source)
    {
        source.Play();
        Invoke(nameof(end),source.clip.length);
    }

    private void end()
    {
        Destroy(gameObject);
    }
}
