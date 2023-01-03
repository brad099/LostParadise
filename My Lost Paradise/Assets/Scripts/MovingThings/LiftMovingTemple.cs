using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LiftMovingTemple : MonoBehaviour
{
    [SerializeField] GameObject Lift;
    [SerializeField] Vector3 _startPos;
    [SerializeField] Vector3 _endPos;
    [SerializeField] float reachtime;
    Sequence seq;

    private void OnTriggerEnter(Collider other)
    {
            seq = DOTween.Sequence();
            seq.Join(Lift.transform.DOLocalMove(_endPos, reachtime).SetEase(Ease.Linear)); 
    }

    private void OnTriggerExit(Collider other)
    {
            seq.Join(Lift.transform.DOLocalMove(_startPos, reachtime).SetEase(Ease.Linear));
            seq.Kill();
    }
}
