using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Controls
{
    public class CtrlComboBoxModel : CtrlBaseModel
    {
        public CtrlComboBoxModel() { ViewName = ""; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
    }
}