using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSystem : MonoBehaviour
{
    public List<RewardItem> items;
    public List<ChestHolder> chests;
    private int count;

    public void Fillitem(int itemId,Sprite img)
    {
        foreach (ChestHolder chest in chests)
        {
            if (itemId == chest.id)
            {
                HolderUpdate(chest,img);


            }
        }
    }

    private void HolderUpdate(ChestHolder chest,Sprite img)
    {
      Image renderer = chest.holders[chest.Count].GetComponentInChildren<Image>();
        renderer.sprite = img;
       chest.Count++;   
       

        if (chest.Count == 3)
        {
            Debug.Log("Won");

        }
    }
}