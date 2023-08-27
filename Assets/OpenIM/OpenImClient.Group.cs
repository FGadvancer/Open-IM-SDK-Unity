using System;
using UnityEngine;

namespace OpenIM{

    public class CreateGroupReq{
        public string[]  memberUserIDs;
        public GroupInfo groupInfo;
        public string[] adminUserIDs;
        public string ownerUserID;
    }
    public class GroupInfo{
        public string groupID;
        public string groupName;
        public string notification;
        public string introduction;
        public string faceURL;
        public string ownerUserID;
        public long createTime;
        public ulong memberCount;
        public string ex;
        public int status;
        public string creatorUserID;
        public int groupType;
        public int needVerification;
        public int lookMemberInfo;
        public int applyMemberFriend;
        public long notificationUpdateTime;
        public string notificationUserID;
    }

    public partial class OpenIMClient{

        public static void CreateGroup(BaseCallBack callback,CreateGroupReq req){
            _Instance.CallStatic("createGroup",callback,GetTimeStamp(),JsonUtility.ToJson(param));
        }

        public static void GetSpecifiedGroupsInfo(BaseCallBack callback,string[] groupIDs){
            _Instance.CallStatic("getSpecifiedGroupsInfo",callback,GetTimeStamp(),JsonUtility.ToJson(groupIDs));
        }
    }
}