using App.Models.HelperModels;

namespace App.Services.HelperServices
{
    public interface ISendPushNotificationService
    {
        string SendNotificationAsync(FcmViewModel fcmViewModel);
    }
}
