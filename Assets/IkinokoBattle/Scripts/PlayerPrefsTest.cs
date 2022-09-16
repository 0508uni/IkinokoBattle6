using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour
{
    // Start is called before the first frame update

    private const string TestKey = "TEST";
    private void Start()
    {
        var testData = "This is TEST";

        PlayerPrefs.SetString(TestKey, testData);

        PlayerPrefs.Save();

        var saveData = PlayerPrefs.GetString(TestKey);
        Debug.Log(saveData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
