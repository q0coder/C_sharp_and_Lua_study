using System;
using System.Collections.Generic;
using System.Text;

namespace HpGameServerDemo
{
    public class UserDAL
    {
        //字典保存客户端所有的用户,两种方式，通过客户端连接与通过用户id
        private Dictionary<IntPtr, UserModel> ptrUserDic = new Dictionary<IntPtr, UserModel>();
        private Dictionary<int, UserModel> idUserDic = new Dictionary<int, UserModel>();
        //id
        private int userid = 1;

        //添加一名角色
        public int AddUser(IntPtr ptr, int index)
        {
            UserModel model = new UserModel();
            model.ID = userid++;
            model.userinfo = UserInfo.userList[index - 1];
            model.HP = model.userinfo.MaxHp;
            ptrUserDic.Add(ptr, model);
            idUserDic.Add(model.ID, model);
            return userid;


        }
        //移除
        public void RemoveUser(IntPtr ptr)
        {
            idUserDic.Remove(ptrUserDic[ptr].ID);
            ptrUserDic.Remove(ptr);

        }
        //获取所有的链接
        public IntPtr[] GetUserPtrs()
        {
            return ptrUserDic.Keys.ToArray();
        }

        //获取所有模型
        public UserModel[] GetUserModel()
        {
            return ptrUserDic.Values.ToArray();
        }
        //获取对应id的模型
        public UserModel GetUserModel(int id)
        {
            return idUserDic[id];
        }
        //获取对应链接的模型
        public UserModel GetUserModel(IntPtr ptr)
        {
            return ptrUserDic[ptr];
        }
    }
}
