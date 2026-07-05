using System;
using System.Collections.Generic;
using System.Text;

namespace HpGameServerDemo
{
    public class BLLManger
    {
        private static BLLManger instance;
        public static BLLManger Instance
        {
            get
            {
                if(instance == null)
                {
                    instance= new BLLManger();
                }
                return instance;

            }
        }

        //所有BLL类都在这里创建
        public AccountBLL account = new AccountBLL();
        public UserBLL user = new UserBLL();
        public GameBLL game = new GameBLL();
    }
}
