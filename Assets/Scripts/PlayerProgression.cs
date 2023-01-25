using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Created by Kutay Senyigit for Trelans Studio
 * Date: 14/06/2022
 * 
 */
public class PlayerProgression : MonoBehaviour
{
  

   public int GetLevel()
   {
      return PlayerPrefs.GetInt("level", 1);
   }
   
   public int GetLevelIndex()
   {
      return PlayerPrefs.GetInt("levelIndex", 0);
   }

   public int GetCurrency()
   {
      return PlayerPrefs.GetInt("coin", 0);
   }
   
   public void SaveLevel(int level)
   {
      PlayerPrefs.SetInt("level", level);
   }

   public void SaveLevelIndex(int index)
   {
      PlayerPrefs.SetInt("levelIndex", index);
   }

   public void SaveCurrency(int coin)
   {
      PlayerPrefs.SetInt("coin", coin);
   }
}
