using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MenuController : MonoBehaviour
{
    private GameObject choose1, choose2, choose3;
    private int choose = 0;
    public AudioSource beep_switch;
    private bool firstRender = true;
    // Start is called before the first frame update
    void Start()
    {
        choose1 = GameObject.FindGameObjectWithTag("choose1");
        choose2 = GameObject.FindGameObjectWithTag("choose2");
        choose3 = GameObject.FindGameObjectWithTag("choose3");
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))
        {
            choose++;
            choose= choose % 3;
            Debug.Log(choose);
            Debug.Log(firstRender);
            if (!firstRender)
            {
                beep_switch.Play(0);
            }
            UpdateUI();
        }else if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadScenes();
        }
    }

    void UpdateUI()
    {
        firstRender = false;
        switch (choose)
        {
           case 0:
               choose1.SetActive(true);
               choose2.SetActive(false);
               choose3.SetActive(false);
               break;
           case 1:
               choose1.SetActive(false);
               choose2.SetActive(true);
               choose3.SetActive(false);
               break;
           case 2:
               choose1.SetActive(false);
               choose2.SetActive(false);
               choose3.SetActive(true);
               break;
               
        }
    }

    void LoadScenes()
    {
        switch (choose)
        {
            case 0:
                SceneManager.LoadSceneAsync("MenuChooseMap");
                break;
            case 1:
                break;
            case 2: 
                SceneManager.LoadSceneAsync("CustomMap");
                break;
               
        }
    }



}
