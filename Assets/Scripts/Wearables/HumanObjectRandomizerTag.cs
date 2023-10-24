using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;

public class HumanObjectRandomizerTag : RandomizerTag
{
    public int numberOfProps;
}

public class HumanObjectRandomizer : Randomizer
{
    System.Random random = new System.Random();
    
    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<HumanObjectRandomizerTag>();

        foreach (var tag in tags)
        {
            var randomizer = tag.GetComponent<Transform>();

            for (int i = 0; i < tag.numberOfProps; i++)
            {
                randomizer.GetChild(i).gameObject.SetActive(false);
            }

            int randomProp = random.Next(tag.numberOfProps);
            randomizer.GetChild(randomProp).gameObject.SetActive(true);
        }
    }
}
