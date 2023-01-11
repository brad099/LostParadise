using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmazingAssets.AdvancedDissolve;

public class sarmasiq1 : MonoBehaviour
{
    public float amount;
    private Material mat;
    public bool Burning;
    void Start()
    {
        Burning = false;
        GetComponent<Renderer>();
        mat = GetComponent<Renderer>().material;
    }
    public void Update()
    {
        if(Burning)
        {
        amount = Mathf.Clamp01(amount + Time.deltaTime);
        AmazingAssets.AdvancedDissolve.AdvancedDissolveProperties.Cutout.Standard.UpdateLocalProperty(mat, AdvancedDissolveProperties.Cutout.Standard.Property.Clip, amount);
        }
    }

    public void Burn()
    {
        Burning = true;
    }
}
