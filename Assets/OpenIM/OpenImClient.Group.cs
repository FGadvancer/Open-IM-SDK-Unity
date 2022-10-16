using System;
using UnityEngine;

namespace OpenIM{

    public class CreateGroupParams{
        public int groupType;
        public string groupName;
        public string notification;
        public string introduction;
        public string faceURL;
        public string ex;
    }


    public partial class OpenIMClient{

        public static void CreateGroup(BaseCallBack callback,CreateGroupParams param,string memebers){
            _Instance.CallStatic("createGroup",callback,GetTimeStamp(),JsonUtility.ToJson(param),memebers);
        }

        public static void GetGroupsInfo(BaseCallBack callback,string groupIDs){
            _Instance.CallStatic("getGroupsInfo",callback,GetTimeStamp(),groupIDs);
        }
    }
}