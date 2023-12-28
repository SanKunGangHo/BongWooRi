using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class TimeCount : MonoBehaviour
    {
        public Text timeUI;

        private void OnEnable()
        {

        }
        private void FixedUpdate()
        {
            timeUI.text = GameData.instance.timeText; 
        }


    }



