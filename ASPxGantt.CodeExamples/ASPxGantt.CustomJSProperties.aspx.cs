using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPxGantt_CustomJSProperties : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) { if (!IsPostBack) Session.Clear();    }
    int newProgressValue;
    protected void ASPxGantt1_DataUpdate(object sender, DevExpress.Web.ASPxGantt.GanttDataUpdateEventArgs e) {
        foreach (var args in e.UpdateTaskValues)
            UpdateTaskValues(args.Keys, args.NewValues, args.OldValues);
        e.Handled = true;
    }
    protected void ASPxGantt1_CustomJSProperties(object sender, DevExpress.Web.ASPxGantt.GanttCustomJSPropertiesEventArgs e) {
        e.Properties["cpProgressUpdated"] = newProgressValue;
    }
   void UpdateTaskValues(OrderedDictionary keys, OrderedDictionary newValues, OrderedDictionary oldValues) {
        var task = ProjectDataContext.Tasks.First(p => p.ID == Convert.ToInt32(keys["ID"]));
        task.ParentID = (int?)newValues["ParentID"];
        task.Subject = (string)newValues["Subject"];
        task.PercentComplete = (int)newValues["PercentComplete"];
        task.StartDate = Convert.ToDateTime(newValues["StartDate"]);
        task.EndDate = Convert.ToDateTime(newValues["EndDate"]);
        if (oldValues["PercentComplete"] != newValues["PercentComplete"]) {
            newProgressValue = (int)newValues["PercentComplete"];
        }
    }
}