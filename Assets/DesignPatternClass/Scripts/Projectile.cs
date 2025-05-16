using UnityEngine;


    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private float speed;
        [SerializeField] private float dmg;
        [SerializeField] private bool canExplode;

        public void OnDespawn()
        {
            Debug.Log("I am done");
        }

        public void OnSpawn()
        {
            Debug.Log("PEW");
        }

        public class ProjectileBuilder
        {
            private string name = "Default";
            private float speed = 20f;
            private float dmg = 1f;
            private bool canExplode = false;

            public ProjectileBuilder SetName(string name)
            {
                this.name = name;
                return this;
            }

            public ProjectileBuilder SetSpeed(float speed)
            {
                this.speed = speed;
                return this;
            }

            public ProjectileBuilder SetDmg(float dmg)
            {
                this.dmg = dmg;
                return this;
            }

            public ProjectileBuilder SetExplode(bool canExplode)
            {
                this.canExplode = canExplode;
                return this;
            }

            public Projectile Build()
            {
                Projectile projectile = new GameObject().AddComponent<Projectile>();

                projectile.name = name;
                projectile.speed = speed;
                projectile.dmg = dmg;
                projectile.canExplode = canExplode;

                //so the object is easier to spot in inspector according to gun type
                projectile.gameObject.name = name + "(projectile)";

                projectile.gameObject.SetActive(false);

                return projectile;
            }
        }
    }
