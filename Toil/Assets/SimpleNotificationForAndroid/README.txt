Hi,

This asset is for Android only. It will not work inside the Unity editor.
To implement it in your project move the plugins folder to your project and use this code to send notification:

AndroidJavaObject ajc = new AndroidJavaObject("com.zeljkosassets.notifications.Notifier");
ajc.CallStatic("sendNotification", "PA", "PB", "PC", PD);
PA - Notification Name (string)
PB - Notification Title (string)
PC - Notification Label (string)
PD - Display notification in PD seconds (int)

Please refer to:
http://docs.unity3d.com/Manual/android-GettingStarted.html - for more information about Android plugins in Unity.
http://developer.android.com/guide/topics/ui/notifiers/notifications.html - for more information about notifications in Android.

Also full source code for the notification plugin is included in source-com.zeljkosassets.notifications.zip archive.

Thanks,
Zeljko