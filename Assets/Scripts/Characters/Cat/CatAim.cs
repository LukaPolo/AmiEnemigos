using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAim : CatState{
    [SerializeField] private Transform aimPoint;

    void OnEnable(){
        StartCoroutine(MoveToCenter());
    }

    void OnDisable(){
        StopAllCoroutines();
        transform.rotation = Quaternion.identity;
        Cat.PlayAnim("Cat.Idle");
    }

    void Update(){
        AimToTarget();
    }

    void AimToTarget(){
        Vector3 look = transform.InverseTransformPoint(Cat.AttackTarget.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg + 90;
        transform.Rotate(0, 0, angle);
    }

    IEnumerator MoveToCenter(){
        while(transform.position != aimPoint.position){
            transform.position = Vector3.MoveTowards(transform.position, aimPoint.position, Cat.Data.PatrolSpeed * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(AimAttack());
        Cat.PlayAnim("Cat.Attack");
    }

    IEnumerator AimAttack(){
        while(true){
            int randomCount = Random.Range(1, 11);
            yield return new WaitForSeconds(Cat.Data.AttackDelay);
            Cat.LaunchProjectile(0);
            if(randomCount == 1 || randomCount == 10){
                yield return new WaitForSeconds(Cat.Data.AttackCadence);
                Cat.LaunchProjectile(1);
                if(randomCount == 10){
                    yield return new WaitForSeconds(Cat.Data.AttackCadence);
                    Cat.LaunchProjectile(2);
                }
            }
        }
    }
}