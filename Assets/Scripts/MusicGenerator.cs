using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelData;

public class MusicGenerator : MonoBehaviour
{
    public GameObject break1Generator;
    public GameObject horn1Generator;
    public GameObject kick1Generator;
    public GameObject kick2Generator;
    public GameObject snare1Generator;
    public GameObject snare2Generator;

    public Vector3 initialSpeed;

    public bool useGravity;

    public string levelName;

    private string GenerationFuctionName(Note noteType)
    {
        switch (noteType)
        {
            case Note.Break1:
                return "GenerateBreak1";
            case Note.Horn1:
                return "GenerateHorn1";
            case Note.Kick1:
                return "GenerateKick1";
            case Note.Kick2:
                return "GenerateKick2";
            case Note.Snare1:
                return "GenerateSnare1";
            case Note.Snare2:
                return "GenerateSnare2";
            default:
                return "";
        }
    }
    
    private void Start()
    {
        var drumsData = (IDrumsPattern) this.GetComponent(levelName);
        var beats = drumsData.Beats;
        foreach(var beat in beats)
        {
            string fuctionName = GenerationFuctionName(beat.Note);
            Invoke(fuctionName, (float)beat.StartTime);
        }
    }

    private void Generate(GameObject generator)
    {
        generator.GetComponent<Generation>().GenerateInstantiate(initialSpeed, useGravity);
    }

    private void GenerateBreak1()
    {
        Generate(break1Generator);
    }


    private void GenerateHorn1()
    {
        Generate(horn1Generator);
    }


    private void GenerateKick1()
    {
        Generate(kick1Generator);
    }


    private void GenerateKick2()
    {
        Generate(kick2Generator);
    }


    private void GenerateSnare1()
    {
        Generate(snare1Generator);
    }


    private void GenerateSnare2()
    {
        Generate(snare2Generator);
    }

}
