using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace WorkshopSampleScripts
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoPlayerController : MonoBehaviour
    {
        public UnityEvent onPlayPausePressed = new UnityEvent();
        public UnityEvent onStopPressed = new UnityEvent();
        public UnityEvent onVideoTimeChanged = new UnityEvent();
        private VideoPlayer videoPlayer;

        public void OnPlayPauseButtonPressed()
        {
            if (this.videoPlayer.isPlaying)
            {
                this.videoPlayer.Pause();
            }
            else
            {
                this.videoPlayer.Play();
            }

            this.onPlayPausePressed.Invoke();
        }

        public void OnStopButtonPressed()
        {
            this.videoPlayer.Stop();
            this.onStopPressed.Invoke();
        }

        private void Awake()
        {
            this.videoPlayer = this.GetComponent<VideoPlayer>();
        }
        
        private void Update()
        {
            this.CheckKeyboardCommands();
        }

        private void CheckKeyboardCommands()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                this.OnPlayPauseButtonPressed();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                this.OnStopButtonPressed();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.SetVideoPlayerTime(this.videoPlayer.time - 1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.SetVideoPlayerTime(this.videoPlayer.time + 1);
            }
        }

        private void SetVideoPlayerTime(double newTime)
        {
            if (this.videoPlayer.canSetTime)
            {
                if (0 <= newTime && newTime <= this.videoPlayer.length)
                {
                    this.videoPlayer.time = newTime;
                    this.onVideoTimeChanged.Invoke();
                }
            }
            else
            {
                Debug.LogError("Cannot set time for the video player.");
            }
        }
    }
}
