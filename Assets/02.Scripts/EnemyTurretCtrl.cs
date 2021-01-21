using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretCtrl : MonoBehaviour
{
    public GameObject wayPoint;
    public GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        wayPoint = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        turret.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wayPoint.transform.position - transform.position), 1);
    }
}
