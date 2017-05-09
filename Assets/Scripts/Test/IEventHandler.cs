/// <summary>
/// 事件句柄
/// </summary>
public interface IEventHandler{
    void OnEvent(string type, object data);
}
