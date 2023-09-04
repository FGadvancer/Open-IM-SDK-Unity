
namespace OpenIM
{
    public static class Utils
    {
        public static CB_I_S WrapperCB_I_S(CB_I_S callBack)
        {
            CB_I_S wrapper = (eventName, data) =>
            {
                SDKHelper.QueueOnMainThread(() =>
                {
                    callBack(eventName, data);
                });
            };
            return wrapper;
        }
        public static CB_I_S_S WrapperCB_I_S_S(CB_I_S_S callBack)
        {
            CB_I_S_S wrapper = (errCode, errMsg, data) =>
            {
                SDKHelper.QueueOnMainThread(() =>
                {
                    callBack(errCode, errMsg, data);
                });
            };
            return wrapper;
        }
        public static CB_I_S_S_I WrapperCB_I_S_S_I(CB_I_S_S_I callBack)
        {
            CB_I_S_S_I wrapper = (errCode, errMsg, data, progress) =>
            {
                SDKHelper.QueueOnMainThread(() =>
                {
                    callBack(errCode, errMsg, data,progress);
                });
            };
            return wrapper;
        }
    }
}