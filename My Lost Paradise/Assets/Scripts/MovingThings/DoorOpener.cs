using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorOpener : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Pad;
    [SerializeField] Vector3 _startPos;
    [SerializeField] Vector3 _endPos;
    [SerializeField] float reachtime;
    Sequence seq;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Weight"))
        {
            seq = DOTween.Sequence();
            seq.Join(Door.transform.DOLocalMove(_endPos, reachtime).SetEase(Ease.Linear));
            seq.Join(Pad.transform.DOLocalMove(new Vector3(0f, -0.08f, 0f), 1).SetEase(Ease.Linear));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Weight"))
        {
            seq.Join(Door.transform.DOLocalMove(_startPos, reachtime).SetEase(Ease.Linear));
            seq.Join(Pad.transform.DOLocalMove(new Vector3(0f, 0f, 0f), 1).SetEase(Ease.Linear));
            seq.Kill();
        }
    }
}

