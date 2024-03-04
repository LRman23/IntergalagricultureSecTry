using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public GameObject craftScreen;
    public GameObject robotScreen;
    public GameObject robotUpgScreen;
    public GameObject baseBuildScreen;

    public List<string> inventoryList = new List<string>();

    //Category Buttons
    Button robotBut;
    Button robotUpgBut;
    Button baseBuildBut;

    //Craft Buttons
    //Button craftAxeBTN;

    //Requirement Text
    //Text AxeReq1, AxeReq2;

    public bool isOpen;

    //All Blueprints


    public static CraftingSystem instance { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }



    void Start()
    {
        isOpen = false;

        robotBut = craftScreen.transform.Find("RobotButton").GetComponent<Button>();
        robotBut.onClick.AddListener(delegate { openRobotsCategory(); });

        robotUpgBut = craftScreen.transform.Find("RobotUpgradeButton").GetComponent<Button>();
        robotUpgBut.onClick.AddListener(delegate { robotUpgradeCategory(); });

        baseBuildBut = craftScreen.transform.Find("BaseBuildButton").GetComponent<Button>();
        baseBuildBut.onClick.AddListener(delegate { baseBuildCategory(); });
    }

    private void openRobotsCategory()
    {
        craftScreen.SetActive(false);
        robotScreen.SetActive(true);
    }

    private void robotUpgradeCategory()
    {
        craftScreen.SetActive(false);
        robotUpgScreen.SetActive(true);
    }

    private void baseBuildCategory()
    {
        craftScreen.SetActive(false);
        baseBuildScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
            Debug.Log("tab is pressed");
            craftScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftScreen.SetActive(false);
            robotScreen.SetActive(false);
            robotUpgScreen.SetActive(false);
            baseBuildScreen.SetActive(false);
            if (!InventorySystem.Instance.isOpen)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            isOpen = false;
        }
    }
}