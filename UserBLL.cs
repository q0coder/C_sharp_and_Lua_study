using System;
using System.Collections.Generic;
using System.Text;

namespace HpGameServerDemo
{
    public class UserBLL : IMessageHandler
    {
        public void Server_OnClose(nint connId)
        {
           //用户下线
           //得到下线的用户
           UserModel model = DALManager.Instance.user.GetUserModel(connId);
            //移除角色
            DALManager.Instance.user.RemoveUser(connId);
            //通知所有客户端该角色下线
            foreach (IntPtr client in DALManager.Instance.user.GetUserPtrs())
            {
                Sever.Send(client,Message.Type.Type_User,Message.Type.User_RemoveS,model.ID);
            }

        }

        public void Server_OnReceive(nint connId, Message ms)
        {
            switch (ms.cmd)
            {
                case Message.Type.User_SelectC:
                    //创建其他玩家的角色
                    CreateOtherUser(connId, ms);
                    //创建自己
                    CreateUser(connId, ms);
                    //告诉其他玩家创建自己
                    CreateUserByOthers(connId, ms);
                    break;
            }

        }
        //创建其他玩家的角色

        private void CreateUserByOthers(nint connId, Message ms)
        {
            //遍历其他玩家并创建
            foreach (UserModel model in DALManager.Instance.user.GetUserModel())
            {
                Sever.Send(connId, Message.Type.Type_User, Message.Type.User_CreateS, model.ID, model.userinfo.Modelid,model.Points);


            }

        }
        //创建自己

        private void CreateUser(nint connId, Message ms)
        {
            int modelid=ms.Getcontent<int>(0);
            int userid = DALManager.Instance.user.AddUser(connId, modelid);
            //获取需要创建的模型
            UserModel model = DALManager.Instance.user.GetUserModel(userid);
            model.Points = ms.Getcontent<float[]>(1);
            Sever.Send(connId, Message.Type.Type_User, Message.Type.User_SelectS, userid, modelid, model.Points);



        }
        //告诉其他玩家创建自己

        private void CreateOtherUser(nint connId, Message ms)
        {
            //获取自己
            UserModel model = DALManager.Instance.user.GetUserModel(connId);
            //遍历除了自己的客户端发送创建消息
            foreach (IntPtr client in DALManager.Instance.user.GetUserPtrs())
            {
                if(client == connId)
                {
                    //如果是自己就不要创建
                    continue;

                }
                Sever.Send(client, Message.Type.Type_User, Message.Type.User_CreateS,model.ID,model.userinfo.Modelid,model.Points);

            }


        }
    }
}
