namespace Cadcorp.SIS.GISLink.GridBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cadcorp.SIS.GisLink.Library;
    using System.Windows.Forms;


    [GisLinkProgram("Build Grid")]
    public class LinkProgram
    {
        private SisApplication sis;
        public LinkProgram(SisApplication application) 
        {
            this.sis = application;
            SisMenuItem gridBuilerMenuItem = new SisMenuItem("Build Grid...",new SisClickHandler(this.showGridBuilderDialog));
            gridBuilerMenuItem.Help = "Create an overlay of grid squares covering the current selection.";
            gridBuilerMenuItem.MinStatus = 1;
            gridBuilerMenuItem.MinSelection = 1;
            this.sis.ContextMenu.MenuItems.Add(gridBuilerMenuItem);
        }

        private void showGridBuilderDialog(object sender, SisClickArgs args)
        {
            MessageBox.Show("Clicky clicky");
        }
    }
}
