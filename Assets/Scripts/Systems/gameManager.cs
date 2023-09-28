using UnityEngine;
using NaughtyAttributes;

public class gameManager : MonoBehaviour
{
    [Required]
    public playerSettings gameSettings;
    public static gameManager instance;
    public GameObject soundPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public AudioSource SpawnSound(AudioClip clip)
    {
        GameObject g = Instantiate(soundPrefab);
        AudioSource a = g.GetComponent<AudioSource>();
        a.clip = clip;
        a.volume *= gameSettings.volume;
        soundController s = g.GetComponent<soundController>();
        s.setup(a);
        return a;
    }

    public static float smoothLerp(float from, float to, float sharpness)
    {
        return Mathf.Lerp(from,to,1 - Mathf.Exp(-sharpness * Time.deltaTime));
    }
    
    public static Vector2 smoothLerp(Vector2 from, Vector2 to, float sharpness)
    {
        return Vector2.Lerp(from,to,1 - Mathf.Exp(-sharpness * Time.deltaTime));
    }
    
    public static Vector3 smoothLerp(Vector3 from, Vector3 to, float sharpness)
    {
        return Vector3.Lerp(from,to,1 - Mathf.Exp(-sharpness * Time.deltaTime));
    }
}
