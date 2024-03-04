using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance { get; set; }

    public GameObject inventoryScreenUI;

    public List<GameObject> slotList = new List<GameObject>();

    public List<string> itemList = new List<string>();

    private GameObject itemAdd;
    private GameObject slotToEquip;


    public bool isOpen;

    //public bool isFull;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        isOpen = false;

        PopulateSlotList();
    }

    private void PopulateSlotList()
    {
        foreach (Transform child in inventoryScreenUI.transform)
        {
            if (child.CompareTag("Slot"))
            {
                slotList.Add(child.gameObject);
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {

            Debug.Log("Tab is pressed");
            inventoryScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            //if (!CraftingSystem.instance.isOpen)
            //{
                //Cursor.lockState = CursorLockMode.Locked;
            //}
            isOpen = false;
        }
    }

    public void AddToInventory(string itemName)
    {
        slotToEquip = FindNextEmptySlot();
        itemAdd = Instantiate(Resources.Load<GameObject>(itemName), slotToEquip.transform.position, slotToEquip.transform.rotation);
        itemAdd.transform.SetParent(slotToEquip.transform);
        itemList.Add(itemName);

    }

    private GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }

        return new GameObject();
    }

    public bool CheckIfFull()
    {
        int counter = 0;

        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount > 0)
            {
                counter += 1;
            }
        }

        if (counter == 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}