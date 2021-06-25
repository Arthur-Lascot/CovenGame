﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Coven {
public class PlayerWeapon : MonoBehaviour
{
    bool isHiting;
    GameObject player;
    IA_Albinos_code Dragon;
    IA_Hob_Code Hob;
    IA_Skeleton_code Skeleton;
    Skeleton_Dummie Dummie;

    public void SetIsHiting(bool isHiting)
    {
        this.isHiting=isHiting;
    }
    public void SetPlayer(GameObject player)
    {
        this.player=player;
    }
    public string GetScript(GameObject mob)
    {
        if (mob.GetComponent<IA_Skeleton_code>()!=null)
        {
            Skeleton = mob.GetComponent<IA_Skeleton_code>();
            return "Skeleton";
        }
        if (mob.GetComponent<IA_Hob_Code>()!=null)
        {
            Hob = mob.GetComponent<IA_Hob_Code>();
            return "Hob";
        }
        if (mob.GetComponent<IA_Albinos_code>()!=null)
        {
            Dragon = mob.GetComponent<IA_Albinos_code>();
            return "Dragon";   
        } 
        if (mob.GetComponent<Skeleton_Dummie>()!=null)
        {
            Dummie = mob.GetComponent<Skeleton_Dummie>();
            return "Dummie";
        }
        return null;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (isHiting && collider.gameObject.tag == "mob" )
        {
            Debug.Log("the player is hitting a mob");
            PlayerStat playerStat = player.GetComponent<PlayerStat>();
            Debug.Log(GetScript(collider.gameObject));
            switch (GetScript(collider.gameObject))
            {
                case "Hob" : Hob.TakeDamage(playerStat);
                             break;
                case "Dragon" : Dragon.TakeDamage(playerStat);
                                break;
                case "Skeleton" : Skeleton.TakeDamage(playerStat);
                                  break;
                default: Dummie.TakeDamage(playerStat);
                         break;
            }
            isHiting = false;
        }
    }
}}
