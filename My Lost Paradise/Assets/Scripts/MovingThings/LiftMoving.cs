using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LiftMoving : MonoBehaviour
{
    [SerializeField]GameObject Lift;
    [SerializeField]Vector3 _startPos;
    [SerializeField]Vector3 _endPos;
    [SerializeField]float reachtime;


    private void OnTriggerStay(Collider other) 
    {
            Lift.transform.DOLocalMove(_endPos,reachtime);
    }

    private void OnTriggerExit(Collider other) 
    {
            Lift.transform.DOLocalMove(_startPos,reachtime);
    }
}
