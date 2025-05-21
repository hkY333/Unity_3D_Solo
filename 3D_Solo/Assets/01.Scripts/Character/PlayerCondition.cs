using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private float curAmount;
    [SerializeField] private float startAmount;
    [SerializeField] private float maxAmount;
    [SerializeField] private float passiveAmount;
    [SerializeField] private Image bar;

    //public float 

    // Start is called before the first frame update
    void Start()
    {
        curAmount = startAmount;
    }

    // Update is called once per frame
    void Update()
    {
        curAmount += passiveAmount * Time.deltaTime;
        bar.fillAmount = curAmount / maxAmount;
    }


}
