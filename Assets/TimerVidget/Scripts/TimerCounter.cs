using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{
    public Text display;
    public AudioSource audioSource;

    private int chargeInSeconds = 600;
    private float counter = 0;
    private bool active;

    private void Start()
    {
        UpdateDisplay();
    }

    public void Reset()
    {
        active = false;
        counter = 0;
    }

    public void Activate()
    {
        if (counter > 0) active = !active;
        else
        {
            counter = chargeInSeconds;
            active = true;
        }
    }

    public void AddMinutes(bool positive)
    {
        if (active)
        {
            if (counter < 0) return;
            if (positive) counter += 60;
            else counter -= 60;
        }
        else
        {
            if (chargeInSeconds < 0) return;
            if (positive) chargeInSeconds += 60;
            else chargeInSeconds -= 60;
        }
    }

    void Update()
    {
        if (active)
        {
            if (counter <= 0)
            {
                audioSource.Play();
                active = false;
                return;
            }

            counter -= Time.deltaTime;
        }

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        int h = Mathf.RoundToInt(counter / 3600);
        int m = Mathf.RoundToInt(counter / 60);
        int s = Mathf.RoundToInt(counter % 60);

        string hh = "", mm = "", ss = "";

        if (h < 10) hh = "0" + h;
        else hh = h.ToString();
        if (m < 10) mm = "0" + m;
        else mm = m.ToString();
        if (s < 10) ss = "0" + s;
        else ss = s.ToString();

        display.text = hh + ":" + mm + ":" + ss;
    }
}