namespace WebUI.Models.Controls {
    public class CtrlCheckBoxModel : CtrlBaseModel {

        public CtrlCheckBoxModel() { ViewName = ""; }
        public string Type           { get; set; }
        public string Label          { get; set; }
        public string PlaceHolder    { get; set; }
        public string ColumnDataName { get; set; }

    }
}
