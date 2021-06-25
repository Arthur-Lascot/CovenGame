using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace Coven 
{ 
public class Dummie : MonoBehaviour 
{ 
    public Animator animator; 
    public GameObject Weapon;
    CapsuleCollider playerCollider; 
    Skeleton_Dummie Skeleton; 
    void Start() 
    { 
        Skeleton = gameObject.AddComponent<Skeleton_Dummie>(); 
        Skeleton.SetTarget(null); 
        Skeleton.SetAnimator(animator);
        Skeleton.SetWeapon(Weapon);
        ((enemy_couroutine)Skeleton).SetAttackRange(2); 
        ((enemy_couroutine)Skeleton).SetMoveSpeed(3); 
        ((enemy_couroutine)Skeleton).SetAttackDelay(1); 
        ((enemy_couroutine)Skeleton).SetAttackDammage(0);
        ((enemy_couroutine)Skeleton).SetHealth(90000000);  
    } 
    // Update is called once per frame 
    void Update() 
    { 
        if (Time.time>Skeleton.GetAllow_action()) 
        { 
            if (Skeleton.GetTarget()!=null)
            {
            float Distance = Vector3.Distance(Skeleton.transform.position,Skeleton.GetTarget().transform.position);
            if (Distance>Skeleton.GetFightingRange()) 
            { 
                Skeleton.chase(); 
            } 
            else 
            { 
                if (Distance<=Skeleton.GetAttackRange()) 
                { 
                    Skeleton.attack(); 
                } 
                else 
                { 
                    if (Skeleton.GetFight() && Distance<=Skeleton.GetFightingRange()) 
                    { 
                        Skeleton.StartCoroutine("fighting"); 
                    } 
                }     
            } }
        } 
        else 
        { 
            if (Skeleton.GetTarget()!=null)
            {
                Vector3 Targetposition = new Vector3 (Skeleton.GetTarget().transform.position.x, transform.position.y, Skeleton.GetTarget().transform.position.z); 
                transform.LookAt (Targetposition); 
                transform.position=Vector3.MoveTowards(transform.position,Skeleton.GetTarget().transform.position, 6*Time.deltaTime); 
            }
        }
    } 
}
}