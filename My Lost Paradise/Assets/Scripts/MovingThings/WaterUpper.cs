using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WaterUpper : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Pad;
    [SerializeField] Vector3 _startPos;
    [SerializeField] Vector3 _endPos;
    private bool fill;

    private void OnTriggerEnter(Collider other)
    {
        //Door.transform.DOLocalMove(_endPos, 10f).SetEase(Ease.Linear);
        Pad.transform.DOLocalMove(new Vector3(0f, -0.08f, 0f), 1).SetEase(Ease.Linear);
        fill = true;
    }

    private void OnTriggerExit(Collider other)
    {
        DOTween.KillAll();
        //Door.transform.DOLocalMove(_startPos, 13f).SetEase(Ease.Linear);
        Pad.transform.DOLocalMove(new Vector3(0f, 0f, 0f), 1).SetEase(Ease.Linear);
        fill = false;
    }

    private void Update()
    {
        if (fill)
        {
            Door.transform.DOLocalMove(_endPos, 10f).SetEase(Ease.Linear);
        }
        else
        {
            Door.transform.DOLocalMove(_startPos, 13f).SetEase(Ease.Linear);
        }
    }
}

