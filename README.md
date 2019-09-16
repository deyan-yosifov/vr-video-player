# vr-video-player
VR application for Oculus Go and Oculus Quest developed for a workshop on HackConf 2019.

## How to prepare for the workshop

 1. Create Unity Account and activate the free license (Personal seat) for using Unity.
 2. Download and install UnityHub and install the latest version of Unity from it. If you do not have Visual Studio compatible with Unity, you may choose to install free one during Unity installation. For the purpose of our demo you should also choose to install Android Build Support and Windows Build Support, as shown below:![Unity modules installation](https://raw.githubusercontent.com/deyan-yosifov/vr-video-player/master/Images/UnityModulesInstallation.png)
 3. Clone the demo project from our Github repository: https://github.com/deyan-yosifov/vr-video-player
 4. Go to UnityHub and choose Project->Add and select the “VR Video Player” folder from the repository. Open the newly added project.
 5. Go to File->BuildSettings, for Platform choose Android, for Texture Compression choose ASTC. Press the Switch Platform button and wait for the textures to be computed as shown below:![Switching to Android platform to convert textures](https://raw.githubusercontent.com/deyan-yosifov/vr-video-player/master/Images/SwitchPlatform.png)
 6. Once the textures are computed you may exit Unity and wait for the workshop to build the demo together! 😊
