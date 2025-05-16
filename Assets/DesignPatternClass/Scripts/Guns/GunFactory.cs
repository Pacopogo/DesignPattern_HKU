using UnityEngine;

public abstract class GunFactory : ScriptableObject
{
    public abstract IGun CreateGun();
}

#region Weapons

public class Pistol : IGun
{
    public void Shoot()
    {
        Debug.Log("Pistol Shot");
    }
}
public class WaterGun : IGun
{
    public void Shoot()
    {
        Debug.Log("Water gun I choose you");
    }
}

#endregion

#region Factories

public class WaterGunFactory : GunFactory
{
    public override IGun CreateGun()
    {
        return new WaterGun();
    }
}

public class PistolFactory : GunFactory
{
    public override IGun CreateGun()
    {
        return new Pistol();
    }
}

#endregion
