using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MenuChooseMapController : MonoBehaviour
{
    public GameObject canvas;

    public AudioSource beep_switch;

    public GameObject pointer;

    private GameObject instancePointer;

    private int choose = 0;

    private ChangeJson saveSystem;

    private int countMap = 2;

    private List<string> lst = new List<string>(); 

    public TMP_FontAsset font;

    private float x = -21.6f, y = 120f, z = 0f;

    void Awake()
    {
        lst.Add("map custom");
        lst.Add("map default");
    }

void Start()
    {
        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
        for (int i = 0; i < countMap; i++)
        {
            GameObject textObject = new GameObject("Text Object");
            textObject.transform.position = new Vector3(x + 50, y - 10 - 20 * (i + 1),z);
            TextMeshProUGUI textMesh = textObject.AddComponent<TextMeshProUGUI>();
            textMesh.fontSize = 24;
            textMesh.font = font;
            textMesh.color = Color.white;
            textMesh.text = lst[i];
            textObject.transform.SetParent(canvasRectTransform, false);
        }

        instancePointer = Instantiate(pointer);
        instancePointer.transform.position = new Vector3(x - 80, y - 30 * (choose + 1) + 15, z);
        instancePointer.transform.SetParent(canvasRectTransform, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))
        {
            choose++;
            choose= choose % countMap;
            Debug.Log(choose);
            beep_switch.Play(0);
            UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadSceneAsync("Menu"); 
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadScenes();
        }
    }
    
    void UpdateUI()
    {
        
        switch (choose)
        {
            case 0:
                instancePointer.transform.position = new Vector3(instancePointer.transform.position.x, instancePointer.transform.position.y + 20 * (countMap-1) , instancePointer.transform.position.z);
                break;
            default:
                instancePointer.transform.position = new Vector3(instancePointer.transform.position.x, instancePointer.transform.position.y - 20 , instancePointer.transform.position.z);
                break;

        }
        
    }
    
    void LoadScenes()
    {
        switch (choose)
        {
            case 0:
                SceneManager.LoadSceneAsync("Gameplay");
                break;
            case 1:
                break;

        }
    }
}
