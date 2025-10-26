using UnityEngine;

public class AndroidToast : MonoBehaviour
{
    public static void ShowToast(string message)
    {
#if UNITY_ANDROID
        try
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toast = toastClass.CallStatic<AndroidJavaObject>("makeText", currentActivity, message, 0);
                toast.Call("show");
            }));
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Toast gösteriminde hata: {ex.Message}");
        }
#endif
    }
}

