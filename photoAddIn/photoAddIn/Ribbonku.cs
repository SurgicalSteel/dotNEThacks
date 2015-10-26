using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace photoAddIn
{
    public partial class Ribbonku
    {
        private void Ribbonku_Load(object sender, RibbonUIEventArgs e)
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
