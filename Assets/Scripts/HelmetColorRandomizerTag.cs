using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;
using System.IO;
using UnityEditor;

// Add this Component to any GameObject that you would like to be randomized. This class must have an identical name to
// the .cs file it is defined in.
public class HelmetColorRandomizerTag : RandomizerTag {}

[Serializable]
[AddRandomizerMenu("HelmetColorRandomize")]
public class HelmetColorRandomizer : Randomizer
{
    

    protected override void OnIterationStart()
    {
        string[] textureDirectory;
        textureDirectory = Directory.GetFiles(@"Assets\Materials\colors\helmet\", "*.png");

        var tags = tagManager.Query<HelmetColorRandomizerTag>();
        foreach (var tag in tags)
        {
            int randomIndex = UnityEngine.Random.Range(0, textureDirectory.Length);
            var material = tag.GetComponent<Renderer>().material;
            Texture randomTexture = AssetDatabase.LoadAssetAtPath<Texture>(textureDirectory[randomIndex]);
            material.mainTexture = randomTexture;

        }
    }
}
