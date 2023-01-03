using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    [SerializeField] ParticleSystem part;
    [SerializeField] ParticleSystem part1;
    [SerializeField] ParticleSystem part2;
    [SerializeField] ParticleSystem part3;
    [SerializeField] ParticleSystem part4;
    public bool IsBurned;
    void Update()
    {
        if (IsBurned)
        {
        part.Play();
        part1.Play();
        part2.Play();
        part3.Play();
        part4.Play();
        sarmasiq[] burnable = GameObject.FindObjectsOfType<sarmasiq>();
        foreach (sarmasiq item in burnable)
        {
            item.Burn();
        }
        part.Stop();
        part1.Stop();
        part2.Stop();
        part3.Stop();
        part4.Stop();
        IsBurned = false;
        }
        else return;
    }

    public void ChestBurn()
    {
        IsBurned = true;
    }
}
