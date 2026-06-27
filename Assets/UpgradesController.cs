using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    public List<string> CardTitles;
    public List<string> CardDescriptions;
    public static UpgradesController Instance;

    [Header("Player 1")]
    public PlayerActions PlayerActionsOne;
    public PlayerJump PlayerJumpOne;
    public PlayerMovement PlayerMovementOne;

    [Header("Player 2")]
    public PlayerActions PlayerActionsTwo;
    public PlayerJump PlayerJumpTwo;
    public PlayerMovement PlayerMovementTwo;

    [Header("Multipliers")]
    public float ShootCooldown;
    public float BulletSpeed;
    public float BulletSize;

    public enum UpgradesEnum
    {
        FIRERATE,
        FASTERBULLETS,
        BIGGERBULLETS,
        BULLETSBOUNCE
    }

    private void Awake()
    {
        // If an instance already exists and it's not this one → destroy this
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Assign and persist
        Instance = this;
    }

    

    public void ChooseUpgrade(UpgradesEnum upgrade, bool IsPlayerOne)
    {
        switch (upgrade)
        {
            case UpgradesEnum.FIRERATE:
                if (IsPlayerOne)
                {
                    PlayerActionsOne.spawnInterval = PlayerActionsOne.spawnInterval * ShootCooldown;
                }
                else
                {
                    PlayerActionsTwo.spawnInterval = PlayerActionsTwo.spawnInterval * ShootCooldown;
                }
                break;

            case UpgradesEnum.FASTERBULLETS:
                if (IsPlayerOne)
                {
                    PlayerActionsOne.bulletSpeed = PlayerActionsOne.bulletSpeed * BulletSpeed;
                }
                else
                {
                    PlayerActionsTwo.bulletSpeed = PlayerActionsTwo.bulletSpeed * BulletSpeed;
                }
                break;

            case UpgradesEnum.BIGGERBULLETS:
                if (IsPlayerOne)
                {
                    PlayerActionsOne.bulletSize = PlayerActionsOne.bulletSize * BulletSize;
                }
                else
                {
                    PlayerActionsTwo.bulletSize = PlayerActionsTwo.bulletSize * BulletSize;
                }
                break;
        }
    }
}
