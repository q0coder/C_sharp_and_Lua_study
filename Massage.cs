
[Serializable]
public class Massage
{
    //类型
    public byte type;
    //命令
    public int cmd;
    //参数
    public object content;

    public Massage(byte type, int cmd,params object[] content)
    {
        this.type = type;
        this.cmd = cmd;
        this.content = content;
    }
    //获取参数
    public T Getcontent<T>(int index)
    {
        object[] arr = (object[])content;
        return (T)arr[index];
    }
    [Serializable]
    public class Type
    {
        public const byte Type_Acount = 1;
        public const byte Type_User = 2;
        public const byte Type_Buttle = 3;
        
        //命令
        //账号注册
        //C代表客户端发送的命令，S代表服务器发送的命令
        //注册账号，1代表账号，2代表密码
        public const int Acount_RegistC = 100;
        //1代表注册成功，0代表注册失败
        public const int Acount_RegistS = 101;
        //1代表账号，2代表密码
        public const int Acount_LoginC = 102;
        //1代表登录成功，0代表登录失败
        public const int Acount_LoginS = 103;
    }
}