namespace Server.Logics
{
    public class Admin
    {
        /// <summary>
        /// 登陆判断
        /// </summary>
        /// <param name="Admin_ID">管理员ID</param>
        /// <param name="Pwd">管理员密码</param>
        /// <returns>添加成功 true; 添加失败 false</returns>
        public static bool Is_Login_Info_Valid(string Admin_ID, string Pwd)
        {
            var admin = Models.Admin.GetAdminByID(Admin_ID);
            if (admin == null)
            {
                return false;
            }

            return Pwd == admin.Pwd;
        }
    }
}