using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;


public class HeadObjectsRandomizerTag : RandomizerTag
{
    public Vector3 InitialAngles { get; private set; }
    public int InitialSign;

    private void Awake()
    {
        InitialAngles = transform.eulerAngles;        
    }
}

[Serializable]
[AddRandomizerMenu("HeadObjectsRandomizer")]
public class HeadObjectsRandomizer : Randomizer
{    
    public FloatParameter x_rotation = new()
    {
        value = new UniformSampler(0, 45)
    };
    public FloatParameter y_rotation = new()
    {
        value = new UniformSampler(-90, 90)
    };

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<HeadObjectsRandomizerTag>();
        foreach (var tag in tags) 
        {
            var ran = UnityEngine.Random.Range(0, 4);
            if (ran > 1)
            {
                var initAngle = tag.InitialAngles;
                var offset = new Vector3(tag.InitialSign * x_rotation.Sample(), y_rotation.Sample(), 0);
                tag.transform.eulerAngles = initAngle + offset;
            }
            else
            {
                var initAngle = tag.InitialAngles;
                tag.transform.eulerAngles = initAngle;
            }
        }
    }
}
