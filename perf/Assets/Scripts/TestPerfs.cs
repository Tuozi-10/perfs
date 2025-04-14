using System.Collections.Generic;
using System.Text;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Profiling;

public class TestPerfs : MonoBehaviour
{

    [SerializeField] private GameObject instance;
    
    private float lastSpawn;
    private const float delaySpawn = .1f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawn > delaySpawn)
        {
            lastSpawn = Time.time;
            PoolManager.GetOrCreate();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            DoStuffOnStrings();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            DoLotOfStuffOnStrings();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            DoStuffOnStrings();
            DoLotOfStuffOnStrings();
        }
                
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            DoLotOfStuffOnStringsWithCapacity();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            DoStuffOnStrings();
            DoLotOfStuffOnStrings();
            DoLotOfStuffOnStringBuilder();
            DoLotOfStuffOnStringBuilderInterpolation();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            DoString();
            DoStringBuilder();
        }
    }

    private void DoStuffOnStrings()
    {
        Profiler.BeginSample("Test 1");
        
        var allString = new List<string>();

        for (int i = 0; i < 1500; i++)
        {
            allString.Add("unMot" + i);
        }
        
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStrings()
    {
        Profiler.BeginSample("Test 2");
        
        var allString = new List<string>();
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                allString.Add("unMot" + i);
            }
        }
        Profiler.EndSample();
    }
    
    List<string> allString = new List<string>(1500*100);
    private void DoLotOfStuffOnStringsWithCapacity()
    {
        Profiler.BeginSample("Test 3");
        allString.Clear();
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                allString.Add("unMot");
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringsWithCapacityAndLocalVar()
    {
        Profiler.BeginSample("Test 4");
        
        var allString = new List<string>(1500*100);
        string s;
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                s = "unMot" + i;
                allString.Add(s);
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringsWithCapacityAndInterpolation()
    {
        Profiler.BeginSample("Test 5");

        string sentence ="";
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                sentence += $"unMot {i}";
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringBuilder()
    {
        Profiler.BeginSample("Test 10");
        var builder = new StringBuilder();
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                builder.Append("unMot" + i);
            }
        }
        Profiler.EndSample();
    }
 
    private void DoLotOfStuffOnStringBuilderInterpolation()
    {
        Profiler.BeginSample("Test 11");
        var builder = new StringBuilder();
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                builder.Append($"unMot {i}");
            }
        }
        Profiler.EndSample();
    }
    
    private void DoString()
    {
        Profiler.BeginSample("Test 100");

        string s = "";
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                s += $"unMot";
            }
        }
        
        Profiler.EndSample();
    }
    
    private void DoStringBuilder()
    {
        Profiler.BeginSample("Test 101");
        
        var builder = new StringBuilder();

        string caca = "";
        Debug.Log(caca);
        
        Debug.Log(builder.ToString());
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                builder.Append($"unMot");
            }
        }
        
        Profiler.EndSample();
    }

    void GetComponentTest()
    {
        for (int j = 0; j < 100; j++)
        {
            GetComponent<Transform>();

            if (TryGetComponent<Transform>(out Transform t))
            {
                t.position = Vector3.down;
            }
        }
    }
    
}
