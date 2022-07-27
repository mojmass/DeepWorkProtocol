using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Protocol : MonoBehaviour
{
    [SerializeField] AudioClip TaDaSound;
    private bool ProtocolInitiated = false;
    private TMP_Text ButtonText;
    [SerializeField] private GameObject CycleNumber;
    private TMP_Text CycleNumberText;
    [SerializeField] private GameObject AreYouSure;
    [SerializeField] private GameObject FinishPanel;
    [SerializeField] private GameObject Title;
    private TMP_Text TitleText;
    [SerializeField] private GameObject Timer;
    private TMP_Text TimerText;
    private int Cycle = 0;
    private Coroutine Init;
    private bool WorkingTime = true;
    private WaitForSeconds WFS = new WaitForSeconds(1);
    [SerializeField] private int WorkTimeSeconds = 600;
    [SerializeField] private int RestTimeSeconds = 120;
    [SerializeField] private int MaxCycle = 5;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        ButtonText = transform.GetChild(0).GetComponent<TMP_Text>();
        TitleText = Title.GetComponent<TMP_Text>();
        TimerText = Timer.GetComponent<TMP_Text>();
        CycleNumberText = CycleNumber.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitiateProtocol()
    {
        if (ProtocolInitiated)
        {
            AreYouSure.SetActive(true);
        }
        else
        {
            ButtonText.text = "Abort Protocol";
            ProtocolInitiated = true;
            CycleNumber.SetActive(true);
            CoroutineStarter();
        }
    }
    private void CoroutineStarter()
    {
        StopAllCoroutines();
        Init = StartCoroutine(Time());
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
    private IEnumerator Time()
    {
        var t = 0;
        if (WorkingTime)
        {
            Cycle++;
            t = WorkTimeSeconds;
            TitleText.text = "Work Time";
            CycleNumberText.text = "Cycle: " + Cycle;
        }
        else
        {
            if (Cycle >= MaxCycle)
            {
                FinishPanel.SetActive(true);
                AudioSource.clip = TaDaSound;
                AudioSource.Play();
                StopAllCoroutines();
                yield return null;
            }
            t = RestTimeSeconds;
            TitleText.text = "Rest Time";
        }
        //Play Sound here
        AudioSource.Play(); 
        while (true)
        {
            t--;
            if (t < 0)
            {
                WorkingTime = !WorkingTime;
                CoroutineStarter();
                yield return null;
            }
            TimerTextChanger(t);
            yield return WFS;
        }
    }
    private void TimerTextChanger(int RemainingTime)
    {
        TimerText.text = (RemainingTime / 60).ToString("00") + " : " + (RemainingTime % 60).ToString("00");
    }
}
