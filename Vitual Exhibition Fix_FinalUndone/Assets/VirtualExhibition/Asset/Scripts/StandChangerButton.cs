using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandChangerButton : MonoBehaviour
{
    public GameObject[] standsOn;
    public GameObject[] standsOff;

    [SerializeField] private bool switcher;

    public void Switcher()
    {
        if (switcher)
        {
            foreach (GameObject i in standsOn)
            {
                i.SetActive(false);
            }

            foreach (GameObject i in standsOff)
            {
                i.SetActive(true);
            }

            switcher = false;
        }
        else
        {
            foreach (GameObject i in standsOn)
            {
                i.SetActive(true);
            }

            foreach (GameObject i in standsOff)
            {
                i.SetActive(false);
            }

            switcher = true;
        }
    }
}
