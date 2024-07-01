using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WheelAnimation : MonoBehaviour
{
    public UnityAction OnAnimationEnd;

    float path;

    private void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(path > 0)
        {
            float speed = Mathf.Min(path / 360f, 1f) * 200f + 1f;

            transform.Rotate(Vector3.back * speed * Time.deltaTime);

            path -= speed * Time.deltaTime;
        }
        else
        {
            OnAnimationEnd?.Invoke();
            enabled = false;
        }
    }

    public void SetAnimationPath(int index, int max)
    {
        float zoneSize = (360f / max);

        path = transform.rotation.eulerAngles.z;
        path += zoneSize * index; //set index zone start position
        path += zoneSize; //set index zone center

        path += Random.Range(-zoneSize / 2, zoneSize / 2); //some random

        path += 360f * 3; //add more loops

        enabled = true;
    }
}
