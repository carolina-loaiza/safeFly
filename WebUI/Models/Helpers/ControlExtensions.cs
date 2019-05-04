using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Controls;

namespace WebUI.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }



        public static HtmlString CtrlChart(this HtmlHelper html, string viewName, string id, string title,
        string labels, string chartType, string onLoadFunction)
        {
            var ctrl = new CtrlChartModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Labels = labels,
                ChartType = chartType,
                OnLoadFunction = onLoadFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInput(
            this HtmlHelper html, string id, string type, string label, string placeHolder = "",
            string          columnDataName = ""
        ) {
            CtrlBaseModel ctrl;

            switch (type) {
                case "checkbox":
                    ctrl = new CtrlCheckBoxModel {
                        Id             = id,
                        Type           = type,
                        Label          = label,
                        PlaceHolder    = placeHolder,
                        ColumnDataName = columnDataName
                    };
                    break;
                case "textarea":
                    ctrl = new CtrlTextAreaModel() {
                        Id             = id,
                        Label          = label,
                        PlaceHolder    = placeHolder,
                        ColumnDataName = columnDataName
                    };
                    break;
                default:

                    ctrl = new CtrlInputModel {
                        Id             = id,
                        Type           = type,
                        Label          = label,
                        PlaceHolder    = placeHolder,
                        ColumnDataName = columnDataName
                    };
                    break ;
            }

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction = "", string buttonType = "primary")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDown(this HtmlHelper html, string id, string label, string listId)
        {
            var ctrl = new CtrlDropDownModel
            {
                Id = id,
                Label = label,
                ListId = listId
            };

            return new HtmlString(ctrl.GetHtml());
        }

    }
}