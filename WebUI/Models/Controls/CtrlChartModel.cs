using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Controls
{
    public class CtrlChartModel : CtrlBaseModel
    {

        public string Title { get; set; }
        public string Labels { get; set; }
        public string OnLoadFunction { get; set; }
        public string ChartType { get; set; }
    }
}