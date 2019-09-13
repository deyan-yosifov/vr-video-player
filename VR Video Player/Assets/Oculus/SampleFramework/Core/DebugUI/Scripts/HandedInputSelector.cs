/************************************************************************************

Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.  

See SampleFramework license.txt for license terms.  Unless required by applicable law 
or agreed to in writing, the sample code is provided “AS IS” WITHOUT WARRANTIES OR 
CONDITIONS OF ANY KIND, either express or implied.  See the license for specific 
language governing permissions and limitations under the license.

************************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HandedInputSelector : MonoBehaviour
{
    [SerializeField]
    OvrAvatar localAvatar;
    OVRCameraRig m_CameraRig;
    OVRInputModule m_InputModule;

    private Transform avatarLeftHand;
    private Transform avatarRightHand;

    private Transform AvatarLeftHand
    {
        get
        {
            if (!this.avatarLeftHand)
            {
                this.avatarLeftHand = this.localAvatar?.GetHandTransform(OvrAvatar.HandType.Left, OvrAvatar.HandJoint.HandBase);
            }

            return this.avatarLeftHand;
        }
    }

    private Transform AvatarRightHand
    {
        get
        {
            if (!this.avatarRightHand)
            {
                this.avatarRightHand = this.localAvatar?.GetHandTransform(OvrAvatar.HandType.Right, OvrAvatar.HandJoint.HandBase);
            }

            return this.avatarRightHand;
        }
    }

    void Start()
    {
        m_CameraRig = FindObjectOfType<OVRCameraRig>();
        m_InputModule = FindObjectOfType<OVRInputModule>();
    }

    void Update()
    {
        if(OVRInput.GetActiveController() == OVRInput.Controller.LTouch)
        {
            SetActiveController(OVRInput.Controller.LTouch);
        }
        else
        {
            SetActiveController(OVRInput.Controller.RTouch);
        }

    }

    void SetActiveController(OVRInput.Controller c)
    {
        Transform t;
        if(c == OVRInput.Controller.LTouch)
        {
            t = this.AvatarLeftHand ?? m_CameraRig.leftHandAnchor;
        }
        else
        {
            t = this.AvatarRightHand ?? m_CameraRig.rightHandAnchor;
        }

        m_InputModule.rayTransform = t;
    }
}
