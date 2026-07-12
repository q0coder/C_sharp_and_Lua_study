using System;
using System.Collections.Generic;
using System.Text;

namespace HpGameServerDemo
{
    public class DALManager
    {
        private static DALManager instance;
        public static DALManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DALManager();

                }
                return instance;

            }

        }
        //账号数据
        public AccountDAL account =new AccountDAL();
        public UserDAL user = new UserDAL();
    }
}
