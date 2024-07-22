using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        // Aseg�rate de que el transform del jugador est� asignado
        if (playerTransform != null)
        {
            // Hace que el enemigo mire al jugador
            transform.LookAt(playerTransform);
        }
    }
}
