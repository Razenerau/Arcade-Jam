using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetController : MonoBehaviour
{
    public PlayerJump PlayerJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerJump._groundCheck = true;
    }
}
