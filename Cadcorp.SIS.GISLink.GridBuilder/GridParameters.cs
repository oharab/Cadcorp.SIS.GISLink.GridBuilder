using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cadcorp.SIS.GISLink.GridBuilder
{
    public partial class GridParameters : Form
    {
        public GridParameters()
        {
            InitializeComponent();
            Bitmap bmp = Icons.grid;
            this.Icon = Icon.FromHandle(bmp.GetHicon());
        }

        

    }
}
