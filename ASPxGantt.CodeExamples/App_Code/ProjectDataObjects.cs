using System;
using System.Collections.Generic;

[Serializable]
public class Task {
    public int ID { get; set; }
    public int? ParentID { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PercentComplete { get; set; }
    public int Type { get; set; }
    public int Status { get; set; }
    public string Team { get; set; }
    public string Employees { get; set; }

    public Task() { }
    public Task(string id, string parentid, string subject, string start, string end, string percent, string type, string status, string resources) {
        ID = Convert.ToInt32(id);
        if (string.IsNullOrEmpty(parentid))
            ParentID = null;
        else
            ParentID = Convert.ToInt32(parentid);
        Subject = subject;
        StartDate = DateTime.Parse(start);
        EndDate = DateTime.Parse(end);
        PercentComplete = Convert.ToInt32(percent);
        Type = Convert.ToInt32(type);
        Status = Convert.ToInt32(status);
        Employees = resources;
    }
}
[Serializable]
public class Dependency {
    public int DependencyID { get; set; }
    public int ParentID { get; set; }
    public int DependentID { get; set; }
    public int Type { get; set; }
}
[Serializable]
public class TaskResource {
    public int ResourceID { get; set; }
    public string Name { get; set; }
}
[Serializable]
public class ResourceAssignment {
    public int ResourceAssignmentID { get; set; }
    public int TaskID { get; set; }
    public int ResourceID { get; set; }

}
