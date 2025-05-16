using System.Collections;
using UnityEngine;

namespace PabloSchool
{
    enum GunEnum
    {
        pistol,
        watergun
    }

    public class Gun : MonoBehaviour
    {
        [SerializeField] private KeyCode inputKey = KeyCode.Space;

        [SerializeField] private GunEnum gunEnum = GunEnum.pistol;
        private GunFactory gunFactory;
        private IGun gun;

        [SerializeField] private BulletType bulletType;
        private Projectile projectile;

        private ObjectPool<Projectile> pool;

        private void Start()
        {
            SetGunType();

            projectile = new Projectile.ProjectileBuilder()
            .SetSpeed(bulletType.speed)
            .SetDmg(bulletType.dmg)
            .SetExplode(bulletType.canExplode)
            .SetName(bulletType.name)
            .Build();

            pool = new ObjectPool<Projectile>(projectile, 10);
        }
        public void Fire()
        {
            Projectile projectile = pool.Get();

            StartCoroutine(ReturnAfterDelay(projectile, 1));
        }

        private void Update()
        {
            if (Input.GetKeyDown(inputKey))
            {
                gun.Shoot();
                Fire();
            }
        }

        private IEnumerator ReturnAfterDelay(Projectile projectile, float delay)
        {
            yield return new WaitForSeconds(delay);
            pool.ReturnToPool(projectile);
        }


        private void SetGunType()
        {
            switch (gunEnum)
            {
                case GunEnum.pistol:
                    gunFactory = new PistolFactory();

                    break;

                case GunEnum.watergun:
                    gunFactory = new WaterGunFactory();

                    break;
            }

            gun = gunFactory.CreateGun();
        }
    }
}
