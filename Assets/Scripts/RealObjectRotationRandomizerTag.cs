using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

// Add this Component to any GameObject that you would like to be randomized. This class must have an identical name to
// the .cs file it is defined in.
public class RealObjectRotationRandomizerTag : RandomizerTag 
{
    
}

[Serializable]
[AddRandomizerMenu("RealObjectRotationRandomizer")]
public class RealObjectRotationRandomizer : Randomizer
{
    
    public FloatParameter rotation = new()
    {
        value = new UniformSampler(0, 360)
    };

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<RealObjectRotationRandomizerTag>();
        foreach (var tag in tags)
        {
            tag.transform.rotation = Quaternion.Euler(0f, 0f, rotation.Sample());
        }
    }
}
