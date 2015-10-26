﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools;
namespace photoAddIn
{
    public partial class ThisAddIn
    {
        CustomTaskPane _ctp;


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _ctp = Globals.ThisAddIn.CustomTaskPanes.Add(new MyUserControl(),"Photo Viewer");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        public void ShowPhotoViewer()
        {
            _ctp.Visible = true;
        }

        public void HidePhotoViewer()
        {
            _ctp.Visible = false;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
