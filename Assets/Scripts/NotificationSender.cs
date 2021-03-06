using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class NotificationSender : MonoBehaviour
{
    bool isPaused = false;

    private void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);


        

    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        if (pauseStatus == true)
        {
            BackgroundNotification();
        }
      
    }

    public void ButtonNotification()
    {

        var notification = new AndroidNotification();
        notification.Title = "visit our website";
        notification.Text = "blahblahblah.com";
        notification.FireTime = System.DateTime.Now.AddSeconds(15);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
 
    public void BackgroundNotification()
    {

        var notification = new AndroidNotification();
        notification.Title = "Please come back!";
        notification.Text = "Plsplsplspls";
        notification.FireTime = System.DateTime.Now.AddSeconds(5);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}

