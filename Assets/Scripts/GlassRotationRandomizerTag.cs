using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

// Add this Component to any GameObject that you would like to be randomized. This class must have an identical name to
// the .cs file it is defined in.
public class GlassRotationRandomizerTag : RandomizerTag {}

[Serializable]
[AddRandomizerMenu("GlassRotationRandomizer")]
public class GlassRotationRandomizer : Randomizer
{
    // Sample FloatParameter that can generate random floats in the [0,360) range. The range can be modified using the
    // Inspector UI of the Randomizer.
    public FloatParameter x_rotation = new(){ value = new UniformSampler(0, 360) };
    public FloatParameter y_rotation = new(){ value = new UniformSampler(0, 360) };
    public FloatParameter z_rotation = new(){ value = new UniformSampler(0, 360) };

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<GlassRotationRandomizerTag>();
        foreach (var tag in tags)
            tag.transform.rotation = Quaternion.Euler(
                tag.transform.eulerAngles.x + x_rotation.Sample(),
                tag.transform.eulerAngles.y + y_rotation.Sample(), 
                z_rotation.Sample());
    }
}
