using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadFirstScene : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI text;
    public float skipTimer = 0;
    public bool skipDetect = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 85f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && skipDetect)
        {
            SceneManager.LoadScene("TestScene");
        }
        if (Input.anyKeyDown)
        {
            skipDetect = true;
            text.text = "Press spacebar to skip";
            skipTimer = 3f;
        }
        if(skipTimer > Mathf.Epsilon)
        {
            skipTimer -= Time.deltaTime;
        }
        if(skipTimer <= Mathf.Epsilon)
        {
            skipDetect = false;
            text.text = "";
        }
    }
}
