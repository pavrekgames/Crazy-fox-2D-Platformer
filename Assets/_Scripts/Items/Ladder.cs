using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Collider2D ladderCollider;

    public void EnableCollider()
    {
        ladderCollider.enabled = true;
    }

    public void DisableCollider()
    {
        ladderCollider.enabled = false;
    }

}
