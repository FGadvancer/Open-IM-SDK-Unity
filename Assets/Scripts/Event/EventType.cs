
namespace Dawn.Event
{
    public enum EventType
    {
        Error,
        Tip,
        ConnectWallet,
        OnRecvFightData,
        OnRecvBattle,
        StartMatch,
        MatchSuc,
        //回合改变
        RoundChange,
        // 血量改变
        HPChange,
        // 体力消耗
        VitChange,
        // 战斗结束
        BattleEnd,
        QuitBattle,
        AutoVictory,
        RecvTransactionStatus
    }
}
