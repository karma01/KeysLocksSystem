using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LockRewardSystem : MonoBehaviour
{
    [SerializeField] private List<LockItemInfo> _items = new List<LockItemInfo>();
    [SerializeField] private ChooseSystem chooseSystem;
    [SerializeField] private Button[] buttons;
    private int itemId;
    private int key = 0;
    public int maxKeys = 3;
    private void Start()
    {
        for(int i = 0; i <= buttons.Length; i++) 
        {
            int buttonId = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(buttonId));
        }
    }
    public void OnButtonClick(int id)
    {
        if(key <maxKeys)
        {
            itemId = Random.Range(0, _items.Count);
            buttons[id].interactable = false;
            Sprite imgSprite = buttons[id].GetComponent<Image>().sprite = _items[itemId].Image;
            chooseSystem.Fillitem(_items[itemId].itemId, imgSprite);

        }
        key++;


    }
}

[Serializable]
public class LockItemInfo
{
    public int itemId;
    public string name;
    public Sprite Image;
    public int value;
}

[Serializable]
public class RewardItem
{
    public int value;
    public int itemId;
    public string name;
    public Sprite image;
    public int recievedCount;
}

[Serializable]
public class ChestHolder
{
    public GameObject[] holders;
    public int id;
    public int Count;
}