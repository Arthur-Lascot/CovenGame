﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Dummie : MonoBehaviour
{
    public GameObject target;
    GameObject player;
    public void SetPlayer(GameObject player)
    {
        this.player=player;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag=="mob")
        {
            target.GetComponent<Coven.Skeleton_Dummie>().TakeDamage(player.GetComponent<Coven.PlayerStat>());
        }
    }
}