namespace Cadcorp.SIS.GISLink.GridBuilder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Cadcorp.SIS.GisLink.Library;
    using log4net;

    public partial class GridParameters : Form
    {
        private readonly ILog log = LogManager.GetLogger(typeof(GridParameters));

        private readonly IManager sis;
        public GridParameters(IManager sis)
        {
            log.Debug("Grid Parameters dialog created.");

            InitializeComponent();
            Bitmap bmp = Icons.grid;
            this.Icon = Icon.FromHandle(bmp.GetHicon());
            this.sis = sis;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                log.Debug("Build grid");
                using (GridCalculator calc = new GridCalculator(sis))
                {
                    calc.Calculate();
                }
            }
            else
            {
                log.Debug("Will not build grid as parameters are not valid.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            log.Debug("Grid build cancelled.");
        }

        private void txtGridSize_Validating(object sender, CancelEventArgs e)
        {
            log.DebugFormat("Validating \"{0}\".", this.txtGridSize);
            long gridSize;
            if (!long.TryParse(this.txtGridSize.Text, out gridSize) || gridSize == 0)
                this.ErrorProvider.SetError(this.txtGridSize, "Grid Size must be a number.");
            else
                this.ErrorProvider.SetError(this.txtGridSize, string.Empty);
        }

    }
}

