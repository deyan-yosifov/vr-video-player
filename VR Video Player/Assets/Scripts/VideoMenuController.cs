using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace DemoScripts
{    public class VideoMenuController : MonoBehaviour
    {
        public VideoPlayer videoPlayer;
        public Text playPauseText;
        public Text sliderValueText;
        public Slider slider;
        public Transform[] menuUIToShowOrHide;

        private bool isInitialized;
        private int lastSliderValue;
        private bool isMenuVisible;

        public void OnPlayPausePressed()
        {            
            if (this.videoPlayer.isPlaying)
            {
                this.videoPlayer.Pause();
            }
            else
            {
                this.videoPlayer.Play();
            }

            this.UpdatePlayPauseText();
        }

        public void OnStopButtonPressed()
        {
            this.videoPlayer.Stop();
            this.UpdatePlayPauseText();
            this.UpdateSliderValueText();
        }

        public void OnSliderValueChanged(float value)
        {
            int time = (int)value;
            bool isPressed = this.lastSliderValue != time;

            if (isPressed)
            {
                if (this.videoPlayer.canSetTime)
                {
                    this.videoPlayer.time = time;
                    this.UpdateSliderValueText();
                }
                else
                {
                    this.slider.value = this.lastSliderValue;
                    Debug.LogError("Cannot set time for video player");
                }
            }
        }

        private void Awake()
        {
            this.isInitialized = this.videoPlayer && this.playPauseText && this.slider && this.sliderValueText;

            if (this.isInitialized)
            {
                this.UpdatePlayPauseText();
                this.slider.maxValue = (int)this.videoPlayer.length;
                this.isMenuVisible = true;
            }
            else
            {
                Debug.LogError("VideoMenuController fields are not initialized.");
            }
        }

        private void Update()
        {
            if (this.videoPlayer.isPlaying)
            {
                this.UpdateSliderValueText();
            }

            this.CheckKeyboardCommands();
            this.CheckControllersCommands();
        }

        private void ChangeMenuVisibility()
        {
            this.isMenuVisible = !this.isMenuVisible;

            foreach (Transform t in this.menuUIToShowOrHide)
            {
                t.gameObject.SetActive(this.isMenuVisible);
            }
        }

        private void UpdatePlayPauseText()
        {
            this.playPauseText.text = this.videoPlayer.isPlaying ? "Pause" : "Play";
        }

        private void UpdateSliderValueText()
        {
            int time = (int)this.videoPlayer.time;

            if (this.lastSliderValue != time)
            {
                this.lastSliderValue = time;
                this.slider.value = time;
                this.sliderValueText.text = time + " s";
            }
        }

        private void CheckControllersCommands()
        {
            bool isBackButtonPressed = OVRInput.GetDown(OVRInput.Button.Two);

            if (isBackButtonPressed)
            {
                this.ChangeMenuVisibility();
            }
        }

        private void CheckKeyboardCommands()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                this.OnPlayPausePressed();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                this.OnStopButtonPressed();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                this.ChangeMenuVisibility();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                float smallerValue = this.slider.value - 1;
                if (smallerValue >= this.slider.minValue)
                {
                    this.slider.value = smallerValue;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                float biggerValue = this.slider.value + 1;
                if (biggerValue <= this.slider.maxValue)
                {
                    this.slider.value = biggerValue;
                }
            }
        }
    }
}
