using System;
using System.Collections.Generic;
using System.Text;

namespace HpGameServerDemo
{
    //角色信息类，设定每个角色的基础信息
    public class UserInfo
    {
        public int Modelid;
        public int MaxHp;
        public int Attack;
        public int StartPoint;
        public  UserInfo( int modelid,int maxhp,int attack, int startpoint)
        {
            Modelid = modelid;
            MaxHp = maxhp;
            Attack = attack;
            StartPoint = startpoint;
        }
        //设定两种角色
        public static UserInfo[] userList = new UserInfo[]{
            //战士
            new UserInfo(1,100,25,1),
            //法师
            new UserInfo(2,70,50,2)

        };

    }
    //玩家的角色类，设定每个玩家用户的基础信息
    public class UserModel
    {
        public int ID;
        public int HP;
        public float[] Points;
        public UserInfo userinfo;

    }
}
