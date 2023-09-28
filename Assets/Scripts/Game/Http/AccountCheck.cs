using System.Collections.Generic;


public class AccountCheckArgs : BaseHttpMsg
{
    List<string> checkUserIDs;

    public AccountCheckArgs(string id)
    {
        checkUserIDs = new List<string>();
        checkUserIDs.Add(id);
    }
}

public class AccountStatusResult
{
    public string userID;
    public string accountStatus;
}
public class AccountStatusResults
{
    public List<AccountStatusResult> result;
}
public class AccountCheckRes
{
    public int errCode;
    public string errMsg;
    public string errDlt;
    public AccountStatusResults data;
}
