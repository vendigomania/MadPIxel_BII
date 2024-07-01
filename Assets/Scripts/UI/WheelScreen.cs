using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WheelScreen : MonoBehaviour
{
    [SerializeField] private WheelAnimation wheelAnimation;
    [SerializeField] private WheelView wheelView;

    [SerializeField] private Button launchBtn;
    [SerializeField] private Text manaValueLable;
    [SerializeField] private Text coinsValueLable;

    public void Initialize(UnityAction onLaunchClick, UnityAction onWheelAnimationEnd, string[] wheelValues)
    {
        wheelView.SetValues(wheelValues);

        launchBtn.onClick.AddListener(onLaunchClick);
        wheelAnimation.OnAnimationEnd += () => onWheelAnimationEnd?.Invoke();
    }

    public void UpdateView(int manaValue, int coinsValue)
    {
        manaValueLable.text = manaValue.ToString();
        coinsValueLable.text = coinsValue.ToString();
    }

    public void ShowWheelAnimation(int index, int zonesCount)
    {
        wheelAnimation.SetAnimationPath(index, zonesCount);
    }

    public void SetLaunchBtnActive(bool active)
    {
        launchBtn.interactable = active;
    }
}
