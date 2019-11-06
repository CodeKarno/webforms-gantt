using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGantt;
using DevExpress.Web.Data;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            Session.Clear();
    }

    protected void ASPxGantt1_DataUpdate(object sender, DevExpress.Web.ASPxGantt.GanttDataUpdateEventArgs e) {
        foreach (var args in e.InsertTaskValues)
            InsertTaskValues(args);

        foreach (var args in e.UpdateTaskValues)
            UpdateTaskValues(args.Keys, args.NewValues);

        foreach (var args in e.DeleteTaskValues)
            DeleteTaskValues(args.Values);

        foreach (var args in e.InsertDependencyValues)
            InsertDependencyValues(args);

        foreach (var args in e.DeleteDependencyValues)
            DeleteDependencyValues(args);

        foreach (var args in e.InsertResourceValues)
            InsertResourceValues(args);

        foreach (var args in e.UpdateResourceValues)
            UpdateResourceValues(args);

        foreach (var args in e.DeleteResourceValues)
            DeleteResourceValues(args);

        foreach (var args in e.InsertResourceAssignmentValues)
            InsertResourceAssignmentValues(args);

        foreach (var args in e.DeleteResourceAssignmentValues)
            DeleteResourceAssignmentValues(args);

        e.Handled = true;
    }
  

    #region Data Methods
    private void DeleteResourceAssignmentValues(ASPxDataDeleteValues args) {
        var resAssignment = ProjectDataContext.ResourceAssignments.First(p => p.ResourceAssignmentID == (int)args.Values["ResourceAssignmentID"]);
        ProjectDataContext.ResourceAssignments.Remove(resAssignment);
    }

    private void InsertResourceAssignmentValues(GanttDataInsertValues args) {
        var key = args.Key;
        var resAssignment = new ResourceAssignment { ResourceAssignmentID = ProjectDataContext.ResourceAssignments.Count };
        resAssignment.ResourceID = (int)args.NewValues["ResourceID"];
        resAssignment.TaskID = (int)args.NewValues["TaskID"];
    }

    private void DeleteResourceValues(ASPxDataDeleteValues args) {
        var resource = ProjectDataContext.Resources.First(p => p.ResourceID == (int)args.Values["ResourceID"]);
        ProjectDataContext.Resources.Remove(resource);
    }

    private void UpdateResourceValues(ASPxDataUpdateValues args) {
        var resource = ProjectDataContext.Resources.First(p => p.ResourceID == (int)args.NewValues["ResourceID"]);
        resource.Name = (string)args.NewValues["Name"];
    }

    private void InsertResourceValues(GanttDataInsertValues args) {
        var resource = new TaskResource { ResourceID = ProjectDataContext.Resources.Count };
        resource.Name = (string)args.NewValues["Name"];
        ProjectDataContext.Resources.Add(resource);
    }

    private void DeleteDependencyValues(ASPxDataDeleteValues args) {
        var dependency = ProjectDataContext.Dependencies.First(p => p.DependencyID == (int)args.Values["DependencyID"]);
        ProjectDataContext.Dependencies.Remove(dependency);
    }

    private void InsertDependencyValues(GanttDataInsertValues args) {
        var dependency = new Dependency { DependencyID = ProjectDataContext.Dependencies.Count };
        dependency.ParentID = (int)args.NewValues["ParentID"];
        dependency.DependentID = (int)args.NewValues["DependentID"];
        ProjectDataContext.Dependencies.Add(dependency);
    }

    private void DeleteTaskValues(OrderedDictionary keys) {
        var task = ProjectDataContext.Tasks.First(p => p.ID == Convert.ToInt32(keys["ID"]));
        ProjectDataContext.Tasks.Remove(task);
    }

    private void InsertTaskValues(GanttDataInsertValues args) {
        var task = new Task { ID = ProjectDataContext.Tasks.Count };
        var newValues = args.NewValues;
        LoadNewTaskValues(newValues, task);
        ProjectDataContext.Tasks.Add(task);
    }

    private void UpdateTaskValues(OrderedDictionary keys, OrderedDictionary newValues) {
        var task = ProjectDataContext.Tasks.First(p => p.ID == Convert.ToInt32(keys["ID"]));
        LoadNewTaskValues(newValues, task);
    }

    private void LoadNewTaskValues(OrderedDictionary newValues, Task task) {
        task.ParentID = (int?)newValues["ParentID"];
        task.Subject = (string)newValues["Subject"];
        task.PercentComplete = (int)newValues["PercentComplete"];
        task.StartDate = Convert.ToDateTime(newValues["StartDate"]);
        task.EndDate = Convert.ToDateTime(newValues["EndDate"]);
    }
    #endregion
}