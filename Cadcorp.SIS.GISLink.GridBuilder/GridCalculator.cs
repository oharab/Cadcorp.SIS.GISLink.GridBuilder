namespace Cadcorp.SIS.GISLink.GridBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cadcorp.SIS.GisLink.Library;
    using log4net;

    public class GridCalculator:IDisposable
    {
        private readonly ILog log = LogManager.GetLogger(typeof(GridParameters));
        private readonly IManager sis;
        
        public GridCalculator(IManager sis)
        {
            log.Debug("Grid Calculator created");
            this.sis = sis;
            
        }
        
        public void Calculate()
        {
            log.Debug("Calculate grid sizes.");
            sis.CreateListFromSelection("Point");

        }

        public void Dispose()
        {
            sis.Dispose();
        }
    }
}
