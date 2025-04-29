using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int magCapacity = 30;
    public int bullets;

    public Text bulletsCountText;
    public Camera cam;
    public ParticleSystem muzzleFlash;
    /*public int gunLevel = 1;
    public GunProperties gunProperties;*/

    private void Start()
    {
        bullets = magCapacity;
        bulletsCountText.text = bullets.ToString();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        /*Debug.Log("Gun Level: "+ gunLevel+" Gun Damage: " + gunProperties.levels[gunLevel - 1].gunDamage);
        if (gunLevel < gunProperties.levels.Length)
        {
            gunLevel++;
        }*/
        if (bullets > 0)
        {
            muzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log("Hitted object: " + hit.transform.name);
                HealthManager _healthManger = hit.transform.GetComponent<HealthManager>();
                if (_healthManger != null)
                {
                    _healthManger.UpdateHealth(-damage);
                }
            }

            bullets--;
            if(bullets <= 0)
            {
                Reload();
            }
            bulletsCountText.text = bullets.ToString();
        }
    }
    public void Reload()
    {
        Debug.Log("Reloading");
        bullets = magCapacity;
    }

}
/*[System.Serializable]
public class GunProperties
{
    public string gunName;
    public float recoilValue;
    public GunLevel[] levels;
}
[System.Serializable]
public class GunLevel
{
    public float gunDamage;
    public float gunRange;
    public float reloadTime;
}*/
// ScriptableObject
// AudioMixer