using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    private int shooterCount;
    private GameObject shooterParent;
    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] private float sightRange;
    [SerializeField] private float maxCalibrate;
    [SerializeField] private float horizontalCalibrate;
    [SerializeField] private LayerMask shootableObject;
    [SerializeField] private GameObject explosion;
    private int movingCount;
    private List<GameObject> movingBullets;

    private bool update = false;
    private int tankLevel;
    private float shootingRange;
    private float secsBetweenShots;
    private Vector3 startShooterPos;
    private Vector3 randomCalibrate;
    private Vector3 startEnemyPos;
    private float bulletSpeed;
    private bool inRange;
    private RaycastHit enemyHit;
    private bool canShoot;
    private float turningRate;
    private float missileTimestamp;
    [SerializeField] float missileDuration;
    [SerializeField] float missileCooldown;

    private float latestLoad;

    private ShooterRecoil _shooterRecoil;
    private bool isRecoiling;
    private void Awake() {
        latestLoad = 0;
        _shooterRecoil = FindObjectOfType<ShooterRecoil>();
    }
    // Start is called before the first frame update
    void Start()
    {
        turningRate = 75 / missileDuration;
        isRecoiling = false;
        canShoot = true;
        inRange = false;
        movingBullets = new List<GameObject>();
        UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && inRange && latestLoad > missileCooldown && tankLevel > 4)
        {
            LoadBullets();
            missileTimestamp = 0;
            latestLoad = 0;
            canShoot = false;
        }
        else if (!canShoot && inRange)
        {
            missileTimestamp += Time.deltaTime;
        }
        ShootBullets();
        latestLoad = latestLoad + Time.deltaTime;


    }

    void FixedUpdate() 
    {
        if (latestLoad > missileCooldown && canShoot)
        {
            inRange = Physics.SphereCast(transform.position, sightRange, Vector3.forward, out enemyHit, sightRange, shootableObject);
            if (inRange)
            {
                startEnemyPos = enemyHit.transform.position;
                randomCalibrate = new Vector3(Random.Range(-horizontalCalibrate, horizontalCalibrate), 0, 0);
            }
        }
        if (inRange && !isRecoiling)
        {
            _shooterRecoil.SetRecoil(true);
            isRecoiling = true;
        }
        if (!inRange && isRecoiling)
        {
            _shooterRecoil.SetRecoil(false);
            isRecoiling = false;
        }
    }

    private void SetShooterParent()
    {
     
            shooterParent = transform.GetChild(tankLevel - 1).GetChild(shooterCount - 1)
                .GetChild(0).GetChild(0).gameObject;
        
       
    }

    private void LoadBullets()
    {
        for (int i = 0; i < shooterCount; i++)
        {
            GameObject bullet = bulletPool.GetPooledObject();
            GameObject shooter = null;
            if (i < shooterParent.transform.childCount)
            {
                shooter = shooterParent.transform.GetChild(i).gameObject;
            }

            if (bullet != null && shooter != null)
            {
                bullet.transform.position = shooter.transform.position;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(-45,0,0));
                startShooterPos = bullet.transform.position; 
                movingBullets.Add(bullet);
                movingCount = movingCount + 1;
                bullet.SetActive(true);
            }
        }
    }

    private void ShootBullets()
    {
        for (int i = 0; i < movingCount; i++)
        {
            
                GameObject curBullet = movingBullets[i];
                Vector3 start = startShooterPos;
                Vector3 max = start + Vector3.up * maxCalibrate + Vector3.forward * maxCalibrate + randomCalibrate;
                Vector3 end = startEnemyPos;
       
                float fraction = missileTimestamp / missileDuration;
                Vector3 start_max = Vector3.Lerp(start, max, fraction);
                Vector3 max_end = Vector3.Lerp(max, end, fraction);
                Vector3 result = Vector3.Lerp(start_max, max_end, fraction);
                Quaternion normalAngle = Quaternion.Euler(new Vector3(0, 0, 0));
                Quaternion downwardAngle = Quaternion.Euler(new Vector3(45, 0, 0));
                if (fraction < 0.5)
                {
                    curBullet.transform.rotation = Quaternion.RotateTowards(curBullet.transform.rotation, normalAngle, turningRate * Time.deltaTime); 
                }
                else
                {
                    curBullet.transform.rotation = Quaternion.RotateTowards(curBullet.transform.rotation, downwardAngle, turningRate * Time.deltaTime); 
                }

                curBullet.transform.position = result;

                if (missileTimestamp >= missileDuration)
                {
                    missileTimestamp = 0;
                    canShoot = true;
                    movingBullets.Remove(curBullet);
                    movingCount = movingCount - 1;
                    explosion.transform.position = curBullet.transform.position;
                    explosion.GetComponent<ParticleSystem>().Play();
                    curBullet.SetActive(false);
                    Collider[] hitColliders = Physics.OverlapSphere(curBullet.transform.position, 2);
                    foreach (var hitCollider in hitColliders)
                    {
                    
                        if (hitCollider.gameObject.layer == 8)
                        {
                            hitCollider.gameObject.GetComponent<Enemy>().DieEnemy(false);
                        }
                    }
                }

        }
    }

    public void ChangeAmmo(GameObject newAmmo)
    {
        bulletPool.ChangeObject(newAmmo);
    }

    public void UpdateStats()
    {
        TankController controller = gameObject.GetComponent<TankController>();
        tankLevel = controller.GetLevel();
        secsBetweenShots = 1 - controller.GetShootingSpeed() / controller.GetMaxShootingSpeed();
        shootingRange = controller.GetShootingRange();
        bulletSpeed = controller.GetBulletSpeed();
        shooterCount = controller.GetShooterAmount();
        SetShooterParent();
    }
}
