using UnityEngine;

[CreateAssetMenu (menuName = "data/settings" , fileName = "settings", order = 0)]
public class playerSettings : ScriptableObject
{
   public bool invertY = false;
   public float volume = 0.5f;
}
