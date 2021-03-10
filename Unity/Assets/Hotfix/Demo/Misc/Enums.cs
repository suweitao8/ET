namespace ETHotfix
{
    /// <summary>
    /// 触屏状态
    /// </summary>
    public enum TouchState
    {
        None,       // 没有触屏
        Began,      // 开始触屏
        Stay,      // 还在屏幕
        End         // 离开屏幕
    }
    /// <summary>
    /// UI层级
    /// </summary>
    public enum UILayer
    {
        Scene = -200,         // 对应在场景中的UI
        Background = -100,    // UI的背景
        Common = 0,         // 通用
        PopUI = 100,          // 弹出
        Forward = 200,        // 置顶
    }
}