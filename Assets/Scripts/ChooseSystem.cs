using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerVaalues
{
    public int[] clickedButtons;
    public int[] ids;
    public int[] holders;
    public int[] count;
}

public class ChooseSystem : MonoBehaviour
{
    public List<ChestHolder> chests;
    private int count;
    private PlayerVaalues playerValues;

    public void Fillitem(int itemId, Sprite img)
    {
        foreach (ChestHolder chest in chests)
        {
            if (itemId == chest.id)
            {
                HolderUpdate(chest, img);
            }
        }
    }

    private void HolderUpdate(ChestHolder chest, Sprite img)
    {
        Image renderer = chest.holders[chest.Count].GetComponentInChildren<Image>();
        renderer.sprite = img;
        chest.Count++;

        if (chest.Count == 3)
        {
            Debug.Log("Smh");
        }
    }

    public void SaveSystem()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerVaalues));
        using (StringWriter sw = new StringWriter())
        {
            serializer.Serialize(sw, playerValues);
            PlayerPrefs.SetString("Playervalues", sw.ToString());
        }
    }

    public void LoadSystem()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerVaalues));
        string text = PlayerPrefs.GetString("Playervalues");
        if (text.Length == 0)
        {
            playerValues = new PlayerVaalues();
        }
        else
        {
            using (StringReader sr = new StringReader(text))
            {
                playerValues = serializer.Deserialize(sr) as PlayerVaalues;
            }
        }
    }
}