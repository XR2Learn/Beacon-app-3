using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;
using static UnityEngine.Rendering.DebugUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using System.Diagnostics.Contracts;

public class RealObjectTextureRandomizerTag : RandomizerTag 
{
    public int type;
}

[Serializable]
[AddRandomizerMenu("RealObjectTextureRandomizerTag")]
public class RealObjectTextureRandomizer : Randomizer
{
    
    protected override void OnIterationStart()
    {
        string[] textureDirectory;

        var tags = tagManager.Query<RealObjectTextureRandomizerTag>();
        foreach (var tag in tags)
        {

            int type = tag.GetComponent<RealObjectTextureRandomizerTag>().type;

            if (type == 0)
            {
                textureDirectory = Directory.GetFiles(@"Assets\ModelsReal\Materials\Helmet\", "*.png");
            }
            else if (type == 1)
            {
                textureDirectory = Directory.GetFiles(@"Assets\ModelsReal\Materials\Glasses\", "*.png");
            }
            else if(type == 2)
            {
                textureDirectory = Directory.GetFiles(@"Assets\ModelsReal\Materials\Gloves\Right", "*.png");
            }
            else if(type == 3)
            {
                textureDirectory = Directory.GetFiles(@"Assets\ModelsReal\Materials\Gloves\Left", "*.png");
            }
            else
            {
                textureDirectory = null;
            }

            if (textureDirectory != null)
            {
                int randomIndex = UnityEngine.Random.Range(0, textureDirectory.Length);
                var material = tag.GetComponent<Renderer>().material;
                Texture randomTexture = AssetDatabase.LoadAssetAtPath<Texture>(textureDirectory[randomIndex]);
                material.mainTexture = randomTexture;

               
                textureDirectory = null;
            }
        }
    }
}
