
//using FinalProject.MasterDataManagementForm;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    static class Program
    {
        private static LoggingUtility log = new LoggingUtility("FinalProject", Level.Debug, 30);

        public static LoggingUtility Log { get { return log; } }

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run( new frmLogin());
        }
    }
}
