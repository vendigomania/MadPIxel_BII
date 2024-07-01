using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelScreen wheelScreen;
    [SerializeField] private int[] wheelValues;

    [SerializeField] int mana;
    [SerializeField] int maxMana;
    [SerializeField] float manaCooldownTime;

    [SerializeField] int coins;

    public int Mana
    {
        get => mana;
        set
        {
            mana = value;
            
            wheelScreen.UpdateView(mana, coins);
            wheelScreen.SetLaunchBtnActive(Mana > 0 && resultSynced);
        }
    }

    private int spinResultIndex = 0;
    private bool resultSynced = true;

    // Start is called before the first frame update
    void Start()
    {
        wheelScreen.Initialize(
            LaunchWheel, 
            OnWheelAnimationEnd, 
            wheelValues.Select(val => val.ToString()).ToArray());
    }

    private void LaunchWheel()
    {
        resultSynced = false;

        if (mana == maxMana)
        {
            StartManaRefresh();
        }

        Mana--;

        spinResultIndex = Random.Range(0, wheelValues.Length);

        wheelScreen.ShowWheelAnimation(spinResultIndex, wheelValues.Length);

        Debug.Log($"Spin index: {spinResultIndex}, Spin result: {wheelValues[spinResultIndex]}");
    }

    private void OnWheelAnimationEnd()
    {
        coins += wheelValues[spinResultIndex];

        wheelScreen.UpdateView(mana, coins);

        wheelScreen.SetLaunchBtnActive(Mana > 0);

        resultSynced = true;

        Debug.Log("End animation");
    }

    private void StartManaRefresh()
    {
        Invoke("RefreshMana", manaCooldownTime);
    }

    private void RefreshMana()
    {
        Mana++;

        if (mana < maxMana)
        {
            StartManaRefresh();
        }
    }
}
