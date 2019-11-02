namespace App.Models.HelperModels
{
    public class FcmViewModel
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public bool ShowNotification { get; set; }
        public string Body { get; set; }
        public string UserDeviceId { get; set; }
    }
}
