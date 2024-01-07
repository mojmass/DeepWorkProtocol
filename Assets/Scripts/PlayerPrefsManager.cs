using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static PlayerPrefsManager instance;
    public int WorkTime { get { return _workTime; } set { _workTime = value; } }
    private int _workTime;
    public int RestTime { get { return _restTime; } set { _restTime = value; } }
    private int _restTime;
    public int MaxCycle { get { return _maxCycle; } set { _maxCycle = value; } }
    private int _maxCycle;
    [SerializeField] private TMP_InputField WorkTimeText;
    [SerializeField] private TMP_InputField RestTimeText;
    [SerializeField] private TMP_InputField CyclesNumberText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        WorkTime = PlayerPrefs.GetInt("WorkTime", 600);
        RestTime = PlayerPrefs.GetInt("RestTime", 120);
        MaxCycle = PlayerPrefs.GetInt("MaxCycle", 5);
        WorkTimeText.text = (WorkTime / 60).ToString();
        RestTimeText.text = (RestTime / 60).ToString();
        CyclesNumberText.text = MaxCycle.ToString();
        SaveChanges();
    }
    public void SetDefatult()
    {
        WorkTimeText.text = "10";
        RestTimeText.text = "2";
        CyclesNumberText.text = "5";
    }
    [SerializeField] private TextMeshProUGUI ErrorText;
    public void SaveChanges()
    {
        try
        {
            ErrorText.enabled = false;
            WorkTime = (int)(float.Parse(WorkTimeText.text) * 60);
            PlayerPrefs.SetInt("WorkTime", WorkTime);
            RestTime = (int)(float.Parse(RestTimeText.text) * 60);
            PlayerPrefs.SetInt("RestTime", RestTime);
            MaxCycle = int.Parse(CyclesNumberText.text);
            PlayerPrefs.SetInt("MaxCycle", MaxCycle);
        }
        catch
        {
            ErrorText.enabled = true;
        }
    }
}
