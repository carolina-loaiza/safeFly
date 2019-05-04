using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Controls
{
    public class CtrlTextAreaModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }

        public CtrlTextAreaModel()
        {
            ViewName = "";
        }
    }
}