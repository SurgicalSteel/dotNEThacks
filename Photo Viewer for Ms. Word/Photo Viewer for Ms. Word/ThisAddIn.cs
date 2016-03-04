using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Tools;
namespace Photo_Viewer_for_Ms.Word
{
    public partial class ThisAddIn
    {
        CustomTaskPane _ctp;


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _ctp = Globals.ThisAddIn.CustomTaskPanes.Add(new Photo_Viewer_User_Control(), "Photo Viewer");
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
