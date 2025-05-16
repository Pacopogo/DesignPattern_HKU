using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Bullets/BulletType", order = 1)]
public class BulletType : ScriptableObject
{
    
    public string name = "Default";
    public float speed = 20f;
    public float dmg = 1f;
    public bool canExplode = false;
    
}


