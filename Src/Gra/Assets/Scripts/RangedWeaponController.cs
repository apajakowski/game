using UnityEngine;
using System.Collections;
public enum ProjectileType
{
    bullet1
}

public class RangedWeaponController : MonoBehaviour {
    GameObject bullet1;
    // ADDED THIS VARIABLE, defines this weapon's projectile type
    public ProjectileType currentProjectileType;

    public bool IsShooting = false;
	// Use this for initialization
	void Start () {
        bullet1 = Resources.Load<GameObject>("Prefabs/Bullets/bullet1");
	}
    public void Shoot(ProjectileType projectileType)
    {
        if(projectileType == ProjectileType.bullet1)
        {
            IsShooting = true;
            GameObject tmpBulletGO = (GameObject)Instantiate(bullet1);
            tmpBulletGO.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            if(gameObject.transform.parent.transform.lossyScale.x < 0)
            {
                tmpBulletGO.GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0);
            }
            else
            {
                tmpBulletGO.GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0);
            }
            
        }
    }
}