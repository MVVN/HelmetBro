using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int maxHeartAmount = 3;     // 3 health
    public int curHealth;
    public GameObject[] healthImages;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHeartAmount;
        for (int i = 0; i < healthImages.Length; i++) {
            GameObject item = healthImages [i];
            if (i > maxHeartAmount - 1) {
                item.SetActive(false);
            }
        }
    }

    public void AddHealth() {       // called when enough helmets collected --> restores 1 heart
        if (curHealth >= maxHeartAmount) {
            return;
        }
        curHealth ++;
        healthImages [curHealth - 1].SetActive(true);
    }

    public void RemoveHealth() {
        if (curHealth < 1) {
            return;
        }
        curHealth --;
        healthImages[curHealth].SetActive(false);
    }

}
