using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    [SerializeField] private int level;
    [SerializeField] private ShooterController shooterController;

    [SerializeField] private int shooterAmount;
    [SerializeField] private int prevShooterAmount;
    [SerializeField] private float shootingSpeed;
    private float startingShootingSpeed;
    [SerializeField] private float bulletLevel;
    [SerializeField] private float shootingRange;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private List<GameObject> ammos;
    private int ammoLevel;


    [SerializeField] private const int MAX_LEVEL = 6;
    [SerializeField] private const float MAX_SHOOTING_SPEED = 6;
    [SerializeField] private List<int> MAX_SHOOTER_AMOUNTS;
    [SerializeField] private const float SHOOTING_SPEED_INCREASE = 0.5f;

    private PlayerSwipeController _playerSwipeController;

    [SerializeField] private ParticleSystem gateTankParticle;
    [SerializeField] private ParticleSystem levelTankParticle;

    private ProgressBarManager _progressBarManager;
    private ProgressBar _progressBar;


    private void Awake()
    {
        _playerSwipeController = FindObjectOfType<PlayerSwipeController>();
        ammoLevel = 0;
        _progressBarManager = FindObjectOfType<ProgressBarManager>();
        _progressBar = FindObjectOfType<ProgressBar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MAX_SHOOTER_AMOUNTS = new List<int> {4, 6, 4, 4, 4, 4};
        SetTank();
        startingShootingSpeed = shootingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetTank()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int x = 0; x < transform.GetChild(i).childCount; x++)
            {
                if (x == shooterAmount - 1)
                {
                    transform.GetChild(i).GetChild(x).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).GetChild(x).gameObject.SetActive(false);
                }
            }
            if (i == level - 1)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        SetStats();
    }

    public void TankLevelUp()
    {
        if (level < MAX_LEVEL)
        {
            levelTankParticle.Play();
            level = level + 1;
           // shooterAmount = 1;
            AmmoUpgrade();
            SetTank();
            ShooterSpeedUp();
            _playerSwipeController.SetCurrentBoundaries(level);
            _progressBarManager.AssignCurrentProgressBar(level, shooterAmount);
            _progressBar.IncreaseCurrentTankLevel();
    
        }
    }

    public void ShooterAmountUp()
    {
        if (shooterAmount < MAX_SHOOTER_AMOUNTS[level - 1])
        {
          
            gateTankParticle.Play();
            shooterAmount = shooterAmount + 1;
            SetTank();
            
            if (level == 2 && shooterAmount > 2)
            {
                _progressBarManager.AssignCurrentProgressBar(level, shooterAmount);
            }
        }
    }

    public void ShooterSpeedUp()
    {
        gateTankParticle.Play();
        shootingSpeed = shootingSpeed + SHOOTING_SPEED_INCREASE;
        UpdateSoundSpeedLevel();
        SetTank();
        shooterController.SetShootingSpeedForSound(shootingSpeed/startingShootingSpeed);
        Debug.Log("SHHOTİNG SPED = " + shootingSpeed + "Shooting amo: " + startingShootingSpeed );
    }
    public void ShooterSpeedDown()
    {
        gateTankParticle.Play();
        shootingSpeed = shootingSpeed - SHOOTING_SPEED_INCREASE;
        UpdateSoundSpeedLevel();
        SetTank();
    }

    private float CalculateShootingSpeedChange()
    {
        return shootingSpeed / startingShootingSpeed;
    }

    public void UpdateSoundSpeedLevel()
    {
        float rate = CalculateShootingSpeedChange();
        //shooterController.SetShootingSpeedForSound(rate);

    }
    public void SetAmmoLevel(int level)
    {
        gateTankParticle.Play();
        shooterAmount = level;
        if (level == 2 && shooterAmount > 2)
        {
            _progressBarManager.AssignCurrentProgressBar(level, ammoLevel);
        }
        SetTank();
    }

    public void AmmoUpgrade()
    {
    
        if (ammoLevel < MAX_LEVEL)
        {    
            ammoLevel = ammoLevel + 1;
            shooterController.ChangeAmmo(ammos[ammoLevel]);
            
        }
    }

    private void SetStats()
    {
        shooterController.UpdateStats();
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetShooterAmount()
    {
        return shooterAmount;
    }

    public float GetShootingSpeed()
    {
        return shootingSpeed;
    }

    public float GetBulletLevel()
    {
        return bulletLevel;
    }

    public float GetShootingRange()
    {
        return shootingRange;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public int GetMaxLevel()
    {
        return MAX_LEVEL;
    }

    public float GetMaxShootingSpeed()
    {
        return MAX_SHOOTING_SPEED;
    }

}
