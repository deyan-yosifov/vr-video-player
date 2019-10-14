using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine;

namespace WorkshopSampleScripts
{
    [RequireComponent(typeof(OvrAvatar))]
    public class OculusIdInitializer : MonoBehaviour
    {
        private OvrAvatar localAvatar;

        // Start is called before the first frame update
        void Awake()
        {
            this.localAvatar = this.GetComponent<OvrAvatar>();

            if (this.localAvatar.ShowFirstPerson == true && this.localAvatar.ShowThirdPerson == false)
            {
                Core.Initialize();
                Users.GetLoggedInUser().OnComplete(this.GetLoggedInUserCallback);
                Request.RunCallbacks();  //avoids race condition with OvrAvatar.cs Start().
            }
            else
            {
                Debug.LogError("Local avatar should be shown first person and not third person.");
            }
        }

        private void GetLoggedInUserCallback(Message<User> message)
        {
            if (!message.IsError)
            {
                this.localAvatar.oculusUserID = message.Data.ID.ToString();
                Debug.Log($"Local avatar ID: {this.localAvatar.oculusUserID}");
            }
        }
    }
}
