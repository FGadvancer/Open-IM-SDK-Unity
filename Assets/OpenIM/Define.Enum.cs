using System;
using System.Collections.Generic;
using UnityEngine;
namespace OpenIM
{
    public enum LoginStatus
    {
        Logout = 1,
        Logging = 2,
        Logged = 3,
    }
    public enum PlatFormID
    {
        None = 0,
        IOSPlatformID = 1,
        AndroidPlatformID = 2,
        WindowsPlatformID = 3,
        OSXPlatformID = 4,
        WebPlatformID = 5,
        MiniWebPlatformID = 6,
        LinuxPlatformID = 7,
        AndroidPadPlatformID = 8,
        IPadPlatformID = 9,
        AdminPlatformID = 10,
    }
}
