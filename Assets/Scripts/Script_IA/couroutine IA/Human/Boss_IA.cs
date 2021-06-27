using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_IA : MonoBehaviour
{
    public int health = 200;
    public Animator animator;
    public GameObject mainSword;
    public GameObject mainSword2;
    GameObject[] listTarget;
    int nbTarget;
    bool canDoAction;
    bool InFight;
    public void SetCanDoAction(bool canDoAction)
    {
        this.canDoAction = canDoAction;
    }
    public void SetInFight(bool inFight)
    {
        InFight = inFight;
    }
    public void TakeDamage(int dmg)
    {
        if (mainSword.GetComponent<Boss_Sword>().GetCurrentAction()!=Action.ShieldOfSword)
        {
        health-=dmg;
        if (health<=0)
        {
            animator.SetTrigger("Dead");
            Destroy(gameObject,5);
        }
        }
    }
    IEnumerator ChooseAttackClose()
    {
        while(true){
        canDoAction = false;
        int attack = Random.Range(0,6);
        mainSword.GetComponent<Boss_Sword>().SetCurrentActon(attack);
        mainSword2.GetComponent<Boss_Sword>().SetCurrentActon(attack);
        yield return new WaitUntil(()=> canDoAction==true);
        }
    }
    void Start()
    {
        StartCoroutine(ChooseAttackClose());
    }
    void Update()
    {
        if (InFight)
        {
            listTarget = GameObject.FindGameObjectsWithTag("Player");
            if(listTarget.Length==0){InFight=false;}
            else{mainSword.GetComponent<Boss_Sword>().SetTarget(listTarget[0]);
            mainSword2.GetComponent<Boss_Sword>().SetTarget(listTarget[0]);}
            nbTarget = listTarget.Length;
        }
    }
}
