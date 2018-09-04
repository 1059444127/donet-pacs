using pacs_common;
using System;
using System.Windows.Forms;

namespace pacs_gui
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 链接数据库
            SqlHelper.SetConnectionString("oracle");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PacsDlg());
        }
    }
}
