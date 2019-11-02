using App.Models.HelperModels;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace App.Services.HelperServices
{
    public class SendPushNotificationService : ISendPushNotificationService
    {
        public string SendNotificationAsync(FcmViewModel fcmViewModel)
        {
            try
            {
                Fcm fcmAuth = new Fcm();
                var str = "-1";
                string applicationID = fcmAuth.FCMAPIkey;
                string senderId = fcmAuth.FCMSenderKey;
                string deviceId = fcmViewModel.UserDeviceId;
                var webAddr = "https://fcm.googleapis.com/fcm/send";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                var data = new
                {
                    to = fcmViewModel.UserDeviceId,
                    content_available = fcmViewModel.ShowNotification,
                    notification = new
                    {
                        body = fcmViewModel.Body,
                        title = fcmViewModel.Title,
                        topic = fcmViewModel.Topic,
                        sound = "Enabled"
                    }
                };
                var json = JsonConvert.SerializeObject(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                httpWebRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = httpWebRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = httpWebRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                str = sResponseFromServer;
                            }
                        }
                    }
                    return str;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return str;
            }
        }
    }
}
