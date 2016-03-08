using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleViewer.Plugins.ViewModels;
using Grabacr07.KanColleViewer.Plugins.Views;
using Grabacr07.KanColleWrapper;

namespace Grabacr07.KanColleViewer.Plugins
{
    [Export(typeof(IPlugin))]
    [Export(typeof(ITool))]
    [ExportMetadata("Guid", "E206BA74-39D8-4941-A238-EBD85582D21E")]
    [ExportMetadata("Title", "LogViewer")]
    [ExportMetadata("Description", "ドロップ・建造・開発ログを表示する。")]
	[ExportMetadata("Version", "1.2")]
	[ExportMetadata("Author", "+PaddyXu")]
	public class LogViewer : IPlugin, ITool
	{
		private PortalViewModel logViewerViewModel;
        private Logger logger;

        string ITool.Name => "LogViewer";

        object ITool.View => new Portal { DataContext = this.logViewerViewModel };
        
        public void Initialize()
        {
            this.logger = new Logger(KanColleClient.Current.Proxy);

            this.logViewerViewModel = new PortalViewModel();
        }
	}
}
