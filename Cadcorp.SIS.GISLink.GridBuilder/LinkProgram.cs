namespace Cadcorp.SIS.GISLink.GridBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cadcorp.SIS.GisLink.Library;
    using System.Windows.Forms;
    using System.Drawing;
    using log4net.Config;
    using System.Reflection;
    using System.IO;
    using log4net;
    using System.Diagnostics;


    [GisLinkProgram("Build Grid")]
    public class LinkProgram
    {
        private readonly ILog log = LogManager.GetLogger(typeof(LinkProgram));
        private readonly SisApplication sis;

        /// <summary>
        /// Configures Log4Net
        /// </summary>
        public LinkProgram()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileInfo assemblyFile = new FileInfo(assembly.Location);
            string configFileName = assemblyFile.Name + ".log4net";
            DirectoryInfo configDir = assemblyFile.Directory;

            if(configDir.GetFiles(configFileName).Length==1)
                XmlConfigurator.ConfigureAndWatch(configDir.GetFiles(configFileName)[0]);
        }
        
        /// <summary>
        /// Main entry point into the GISLink
        /// </summary>
        /// <param name="application">Application calling the GisLink</param>
        public LinkProgram(SisApplication application):this()
        {
            log.Debug("Starting to link GridBuilder to Sis");
            
            this.sis = application;
            log.Debug("Build MenuItem");
            SisMenuItem gridBuilerMenuItem = new SisMenuItem("Build Grid...", new SisClickHandler(this.showGridBuilderDialog));
            gridBuilerMenuItem.Help = "Create an overlay of grid squares covering the current selection.";
            gridBuilerMenuItem.MinStatus = 1;
            gridBuilerMenuItem.MinSelection = 1;
            this.sis.ContextMenu.MenuItems.Add(gridBuilerMenuItem);
            log.Debug("MenuItem added to the context menu.");
        }

        private void showGridBuilderDialog(object sender, SisClickArgs args)
        {
            log.Debug("Context MenuItem has been clicked.");
            new GridParameters(args.Manager)
                .ShowDialog()
                ;
        }
    }
}
