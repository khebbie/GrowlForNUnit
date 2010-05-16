using System;
using System.Threading;
using Growl.Connector;

namespace GrowlForNUnit
{
    public class Notifier
    {
        private Application _application;
        private GrowlConnector _growl;
        private NotificationType _notificationTypeFailure;
        private NotificationType _notificationTypeSucces;

        public void RegisterGrowl()
        {
            _growl = new GrowlConnector();
            _notificationTypeSucces = new NotificationType("SUCCESS_NOTIFICATION", "Notification Succes");
            _notificationTypeFailure = new NotificationType("FAILURE_NOTIFICATION", "NotificationFailure");
            _application = new Application("NUnit build notifier");
            NotificationType[] notificationList = {_notificationTypeSucces, _notificationTypeFailure};
            _growl.Register(_application, notificationList);
            Thread.Sleep(2000);
        }

        public void Notify(string title, string message, bool success)
        {
            Notification notification = null;
            if (success)
                notification = new Notification(_application.Name, _notificationTypeSucces.Name,
                                                DateTime.Now.Ticks.ToString(),
                                                title, message);
            else
            {
                notification = new Notification(_application.Name, _notificationTypeFailure.Name, DateTime.Now.Ticks.ToString(),
                                 title, message);
            }
            _growl.Notify(notification);
        }
    }
}