using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace OpenIM
{


    public partial class OpenIMClient
    {
        public static void GetAllConversationList(BaseCallBack callback)
        {
            _Instance.CallStatic("getAllConversationList",callback,GetTimeStamp());
        }
        
        public static void GetConversationListSplit(BaseCallBack callback,int offset,int count){
            _Instance.CallStatic("getConversationListSplit",callback,GetTimeStamp(),offset,count);
        }


    }
    
}
