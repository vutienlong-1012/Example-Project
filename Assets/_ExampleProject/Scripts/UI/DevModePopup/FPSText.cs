using ExampleProject.UI.BaseUI;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.DevModePopup
{
    public class FPSText : BaseText
    {
        #region Fields

        [SerializeField] float updateInterval = 0.5f;
        float accum = 0.0f;
        int frames = 0;
        float timeleft;
        float fps;

        #endregion

        #region Properties

        #endregion

        #region LifeCycle   

        void Start()
        {
            timeleft = updateInterval;
        }
        void Update()
        {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            ++frames;

            // Interval ended - update GUI text and start new interval
            if (timeleft <= 0.0)
            {
                // display two fractional digits (f2 format)
                fps = (accum / frames);
                timeleft = updateInterval;
                accum = 0.0f;
                frames = 0;
            }

            ThisText.text = "FPS: " + fps.ToString("F2");
            if (fps >= 60)
                ThisText.color = Color.green;
            else
                if (fps >= 30)
                ThisText.color = Color.yellow;
            else
                ThisText.color = Color.red;

            //charNumberText.text = "Number: " + PlayerManager.instance.characterNumberControl.transform.childCount;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion      
    }
}
