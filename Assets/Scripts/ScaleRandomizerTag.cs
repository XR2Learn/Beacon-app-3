using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;


public class ScaleRandomizerTag : RandomizerTag 
{
   
    public float minFactor = 0.25f;
    public float maxFactor = 0.75f;

    public Vector3 InitialScale {  get; private set; }
    public FloatParameter Scale { get; private set; }

    private void Awake()
    {
        InitialScale = transform.localScale;
        Scale = new FloatParameter
        {
            value = new UniformSampler(minFactor, maxFactor)
        };
    }
}

[Serializable]
[AddRandomizerMenu("ScaleRandomizer")]
public class ScaleRandomizer : Randomizer
{
    
    public FloatParameter scale = new()
    {
        value = new UniformSampler(1.3f, 1.8f)
    };

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<ScaleRandomizerTag>();
       
        foreach (var tag in tags)
        {
            var scale = tag.GetComponent<ScaleRandomizerTag>().Scale;
            float scalar = scale.Sample();
            Vector3 InitScale = tag.InitialScale;
            tag.transform.localScale = new Vector3(InitScale.x * scalar, InitScale.y * scalar, InitScale.z * scalar);
        }
    }
}
