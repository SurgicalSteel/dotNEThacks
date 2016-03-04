using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace Photo_Viewer_for_Ms.Word
{
    public partial class Photo_Viewer_Add_In_Ribbon
    {
        private void Photo_Viewer_Add_In_Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            if (toggleButton1.Checked)
            {
                Globals.ThisAddIn.ShowPhotoViewer();
            }
            else
            {
                Globals.ThisAddIn.HidePhotoViewer();
            }
        }
    }
}
