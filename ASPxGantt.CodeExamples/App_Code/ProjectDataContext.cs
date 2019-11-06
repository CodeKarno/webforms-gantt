using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Linq;
using System;
using System.Web.SessionState;

[DataObject(true)]
public class ProjectDataContext {
    const string
        TasksSessionKey = "Tasks",
        DependenciesSessionKey = "Dependencies",
        ResourcesSessionKey = "Resources",
        ResourceAssignmentsSessionKey = "ResourceAssignments";

    static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<Task> GetTasks() { return Tasks; }
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<Dependency> GetDependencies() { return Dependencies; }
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<TaskResource> GetResources() { return Resources; }
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<ResourceAssignment> GetResourceAssignments() { return ResourceAssignments; }

    public static List<Task> Tasks {
        get {
            if (Session[TasksSessionKey] == null)
                Session[TasksSessionKey] = CreateTasks();
            return (List<Task>)Session[TasksSessionKey];
        }
    }
    public static List<Dependency> Dependencies {
        get {
            if (Session[DependenciesSessionKey] == null)
                Session[DependenciesSessionKey] = CreateDependencies();
            return (List<Dependency>)Session[DependenciesSessionKey];
        }
    }
    public static List<TaskResource> Resources {
        get {
            if (Session[ResourcesSessionKey] == null)
                Session[ResourcesSessionKey] = CreateResources();
            return (List<TaskResource>)Session[ResourcesSessionKey];
        }
    }
    public static List<ResourceAssignment> ResourceAssignments {
        get {
            if (Session[ResourceAssignmentsSessionKey] == null)
                Session[ResourceAssignmentsSessionKey] = CreateResourceAssignments();
            return (List<ResourceAssignment>)Session[ResourceAssignmentsSessionKey];
        }
    }

    static List<Task> CreateTasks() {
        var result = new List<Task>();

        result.Add(new Task("0", "", "Software Development", "2/21/19 8:00 AM", "7/4/19 3:00 PM", "31", "1", "0", ""));
        result.Add(new Task("1", "0", "Scope", "2/21/19 8:00 AM", "2/26/19 12:00 PM", "60", "1", "1", ""));
        result.Add(new Task("2", "1", "Determine project scope", "2/21/19 8:00 AM", "2/21/19 12:00 PM", "100", "1", "2", "1"));
        result.Add(new Task("3", "1", "Secure project sponsorship", "2/21/19 1:00 PM", "2/22/19 12:00 PM", "100", "1", "2", "1"));
        result.Add(new Task("4", "1", "Define preliminary resources", "2/22/19 1:00 PM", "2/25/19 12:00 PM", "60", "1", "2", "2"));
        result.Add(new Task("5", "1", "Secure core resources", "2/25/19 1:00 PM", "2/26/19 12:00 PM", "0", "1", "2", "2"));
        result.Add(new Task("6", "1", "Scope complete", "2/26/19 12:00 PM", "2/26/19 12:00 PM", "0", "0", "2", ""));
        result.Add(new Task("7", "0", "Analysis/Software Requirements", "2/26/19 1:00 PM", "3/18/19 12:00 PM", "80", "1", "1", ""));
        result.Add(new Task("8", "7", "Conduct needs analysis", "2/26/19 1:00 PM", "3/5/19 12:00 PM", "100", "1", "2", "3"));
        result.Add(new Task("9", "7", "Draft preliminary software specifications", "3/5/19 1:00 PM", "3/8/19 12:00 PM", "100", "1", "2", "3"));
        result.Add(new Task("10", "7", "Develop preliminary budget", "3/8/19 1:00 PM", "3/12/19 12:00 PM", "100", "1", "2", "2"));
        result.Add(new Task("11", "7", "Review software specifications/budget with team", "3/12/19 1:00 PM", "3/12/19 5:00 PM", "100", "1", "2", "2,3"));
        result.Add(new Task("12", "7", "Incorporate feedback on software specifications", "3/13/19 8:00 AM", "3/13/19 5:00 PM", "70", "1", "2", "3"));
        result.Add(new Task("13", "7", "Develop delivery timeline", "3/14/19 8:00 AM", "3/14/19 5:00 PM", "0", "1", "2", "2"));
        result.Add(new Task("14", "7", "Obtain approvals to proceed (concept, timeline, budget)", "3/15/19 8:00 AM", "3/15/19 12:00 PM", "0", "1", "2", "1,2"));
        result.Add(new Task("15", "7", "Secure required resources", "3/15/19 1:00 PM", "3/18/19 12:00 PM", "0", "1", "2", "2"));
        result.Add(new Task("16", "7", "Analysis complete", "3/18/19 12:00 PM", "3/18/19 12:00 PM", "0", "0", "2", ""));
        result.Add(new Task("17", "0", "Design", "3/18/19 1:00 PM", "4/5/19 5:00 PM", "80", "1", "1", ""));
        result.Add(new Task("18", "17", "Review preliminary software specifications", "3/18/19 1:00 PM", "3/20/19 12:00 PM", "100", "1", "2", "3"));
        result.Add(new Task("19", "17", "Develop functional specifications", "3/20/19 1:00 PM", "3/27/19 12:00 PM", "100", "1", "2", "3"));
        result.Add(new Task("20", "17", "Develop prototype based on functional specifications", "3/27/19 1:00 PM", "4/2/19 12:00 PM", "100", "1", "2", "3"));
        result.Add(new Task("21", "17", "Review functional specifications", "4/2/19 1:00 PM", "4/4/19 12:00 PM", "30", "1", "2", "1"));
        result.Add(new Task("22", "17", "Incorporate feedback into functional specifications", "4/4/19 1:00 PM", "4/5/19 12:00 PM", "0", "1", "2", "1"));
        result.Add(new Task("23", "17", "Obtain approval to proceed", "4/5/19 1:00 PM", "4/5/19 5:00 PM", "0", "1", "2", "1,2"));
        result.Add(new Task("24", "17", "Design complete", "4/5/19 5:00 PM", "4/5/19 5:00 PM", "0", "0", "2", ""));
        result.Add(new Task("25", "0", "Development", "4/8/19 8:00 AM", "5/7/19 3:00 PM", "42", "1", "1", ""));
        result.Add(new Task("26", "25", "Review functional specifications", "4/8/19 8:00 AM", "4/8/19 5:00 PM", "100", "1", "2", "4"));
        result.Add(new Task("27", "25", "Identify modular/tiered design parameters", "4/9/19 8:00 AM", "4/9/19 5:00 PM", "100", "1", "2", "4"));
        result.Add(new Task("28", "25", "Assign development staff", "4/10/19 8:00 AM", "4/10/19 5:00 PM", "100", "1", "2", "4"));
        result.Add(new Task("29", "25", "Develop code", "4/11/19 8:00 AM", "5/1/19 5:00 PM", "49", "1", "2", "4"));
        result.Add(new Task("30", "25", "Developer testing (primary debugging)", "4/16/19 3:00 PM", "5/7/19 3:00 PM", "24", "1", "2", "4"));
        result.Add(new Task("31", "25", "Development complete", "5/7/19 3:00 PM", "5/7/19 3:00 PM", "0", "0", "2", ""));
        result.Add(new Task("32", "0", "Testing", "4/8/19 8:00 AM", "6/13/19 3:00 PM", "23", "1", "1", ""));
        result.Add(new Task("33", "32", "Develop unit test plans using product specifications", "4/8/19 8:00 AM", "4/11/19 5:00 PM", "100", "1", "2", "5"));
        result.Add(new Task("34", "32", "Develop integration test plans using product specifications", "4/8/19 8:00 AM", "4/11/19 5:00 PM", "100", "1", "2", "5"));
        result.Add(new Task("35", "32", "Unit Testing", "5/7/19 3:00 PM", "5/28/19 3:00 PM", "0", "1", "2", ""));
        result.Add(new Task("36", "35", "Review modular code", "5/7/19 3:00 PM", "5/14/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("37", "35", "Test component modules to product specifications", "5/14/19 3:00 PM", "5/16/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("38", "35", "Identify anomalies to product specifications", "5/16/19 3:00 PM", "5/21/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("39", "35", "Modify code", "5/21/19 3:00 PM", "5/24/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("40", "35", "Re-test modified code", "5/24/19 3:00 PM", "5/28/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("41", "35", "Unit testing complete", "5/28/19 3:00 PM", "5/28/19 3:00 PM", "0", "0", "3", ""));
        result.Add(new Task("42", "32", "Integration Testing", "5/28/19 3:00 PM", "6/13/19 3:00 PM", "0", "1", "2", ""));
        result.Add(new Task("43", "42", "Test module integration", "5/28/19 3:00 PM", "6/4/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("44", "42", "Identify anomalies to specifications", "6/4/19 3:00 PM", "6/6/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("45", "42", "Modify code", "6/6/19 3:00 PM", "6/11/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("46", "42", "Re-test modified code", "6/11/19 3:00 PM", "6/13/19 3:00 PM", "0", "1", "3", "5"));
        result.Add(new Task("47", "42", "Integration testing complete", "6/13/19 3:00 PM", "6/13/19 3:00 PM", "0", "0", "3", ""));
        result.Add(new Task("48", "0", "Training", "4/8/19 8:00 AM", "6/10/19 3:00 PM", "25", "1", "1", ""));
        result.Add(new Task("49", "48", "Develop training specifications for end users", "4/8/19 8:00 AM", "4/10/19 5:00 PM", "100", "1", "2", "6"));
        result.Add(new Task("50", "48", "Develop training specifications for helpdesk support staff", "4/8/19 8:00 AM", "4/10/19 5:00 PM", "100", "1", "2", "6"));
        result.Add(new Task("51", "48", "Identify training delivery methodology (computer based training, classroom, etc.)", "4/8/19 8:00 AM", "4/9/19 5:00 PM", "100", "1", "2", "6"));
        result.Add(new Task("52", "48", "Develop training materials", "5/7/19 3:00 PM", "5/28/19 3:00 PM", "0", "1", "2", "6"));
        result.Add(new Task("53", "48", "Conduct training usability study", "5/28/19 3:00 PM", "6/3/19 3:00 PM", "0", "1", "2", "6"));
        result.Add(new Task("54", "48", "Finalize training materials", "6/3/19 3:00 PM", "6/6/19 3:00 PM", "0", "1", "2", "6"));
        result.Add(new Task("55", "48", "Develop training delivery mechanism", "6/6/19 3:00 PM", "6/10/19 3:00 PM", "0", "1", "2", "6"));
        result.Add(new Task("56", "48", "Training materials complete", "6/10/19 3:00 PM", "6/10/19 3:00 PM", "0", "0", "2", ""));
        result.Add(new Task("57", "0", "Documentation", "4/8/19 8:00 AM", "5/20/19 12:00 PM", "0", "1", "1", ""));
        result.Add(new Task("58", "57", "Develop Help specification", "4/8/19 8:00 AM", "4/8/19 5:00 PM", "80", "1", "2", "7"));
        result.Add(new Task("59", "57", "Develop Help system", "4/22/19 1:00 PM", "5/13/19 12:00 PM", "0", "1", "2", "7"));
        result.Add(new Task("60", "57", "Review Help documentation", "5/13/19 1:00 PM", "5/16/19 12:00 PM", "0", "1", "2", "7"));
        result.Add(new Task("61", "57", "Incorporate Help documentation feedback", "5/16/19 1:00 PM", "5/20/19 12:00 PM", "0", "1", "2", "7"));
        result.Add(new Task("62", "57", "Develop user manuals specifications", "4/8/19 8:00 AM", "4/9/19 5:00 PM", "65", "1", "2", "7"));
        result.Add(new Task("63", "57", "Develop user manuals", "4/22/19 1:00 PM", "5/13/19 12:00 PM", "0", "1", "2", "7"));
        result.Add(new Task("64", "57", "Review all user documentation", "5/13/19 1:00 PM", "5/15/19 12:00 PM", "0", "1", "2", "7"));
        result.Add(new Task("65", "57", "Incorporate user documentation feedback", "5/15/19 1:00 PM", "5/17/19 12:00 PM", "0", "1", "2", "7"));
        result.Add(new Task("66", "57", "Documentation complete", "5/20/19 12:00 PM", "5/20/19 12:00 PM", "0", "0", "2", ""));
        result.Add(new Task("67", "0", "Pilot", "3/18/19 1:00 PM", "6/24/19 3:00 PM", "22", "1", "1", ""));
        result.Add(new Task("68", "67", "Identify test group", "3/18/19 1:00 PM", "3/19/19 12:00 PM", "100", "1", "2", "2"));
        result.Add(new Task("69", "67", "Develop software delivery mechanism", "3/19/19 1:00 PM", "3/20/19 12:00 PM", "100", "1", "2", ""));
        result.Add(new Task("70", "67", "Install/deploy software", "6/13/19 3:00 PM", "6/14/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("71", "67", "Obtain user feedback", "6/14/19 3:00 PM", "6/21/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("72", "67", "Evaluate testing information", "6/21/19 3:00 PM", "6/24/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("73", "67", "Pilot complete", "6/24/19 3:00 PM", "6/24/19 3:00 PM", "0", "0", "2", ""));
        result.Add(new Task("74", "0", "Deployment", "6/24/19 3:00 PM", "7/1/19 3:00 PM", "0", "1", "1", ""));
        result.Add(new Task("75", "74", "Determine final deployment strategy", "6/24/19 3:00 PM", "6/25/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("76", "74", "Develop deployment methodology", "6/25/19 3:00 PM", "6/26/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("77", "74", "Secure deployment resources", "6/26/19 3:00 PM", "6/27/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("78", "74", "Train support staff", "6/27/19 3:00 PM", "6/28/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("79", "74", "Deploy software", "6/28/19 3:00 PM", "7/1/19 3:00 PM", "0", "1", "2", "8"));
        result.Add(new Task("80", "74", "Deployment complete", "7/1/19 3:00 PM", "7/1/19 3:00 PM", "0", "0", "2", ""));
        result.Add(new Task("81", "0", "Post Implementation Review", "7/1/19 3:00 PM", "7/4/19 3:00 PM", "0", "1", "1", ""));
        result.Add(new Task("82", "81", "Document lessons learned", "7/1/19 3:00 PM", "7/2/19 3:00 PM", "0", "1", "2", "2"));
        result.Add(new Task("83", "81", "Distribute to team members", "7/2/19 3:00 PM", "7/3/19 3:00 PM", "0", "1", "2", "2"));
        result.Add(new Task("84", "81", "Create software maintenance team", "7/3/19 3:00 PM", "7/4/19 3:00 PM", "0", "1", "2", "2"));
        result.Add(new Task("85", "81", "Post implementation review complete", "7/4/19 3:00 PM", "7/4/19 3:00 PM", "0", "0", "2", ""));
        result.Add(new Task("86", "0", "Software development template complete", "7/4/19 3:00 PM", "7/4/19 3:00 PM", "0", "0", "1", ""));

        return result;
    }
    static List<Dependency> CreateDependencies() {
        var result = new List<Dependency>();
        int uniqueID = 0;
        foreach (Task task in Tasks) {
            if (task.ParentID.HasValue) {
                result.Add(new Dependency() { DependencyID = uniqueID++, Type = 0, ParentID = task.ID - 1, DependentID = task.ID });
            }
        }
        return result;
    }
    static List<TaskResource> CreateResources() {
        var result = new List<TaskResource>();
        result.Add(new TaskResource() { ResourceID = 1, Name = "Management" });
        result.Add(new TaskResource() { ResourceID = 2, Name = "Project Manager" });
        result.Add(new TaskResource() { ResourceID = 3, Name = "Analyst" });
        result.Add(new TaskResource() { ResourceID = 4, Name = "Developer" });
        result.Add(new TaskResource() { ResourceID = 5, Name = "Testers" });
        result.Add(new TaskResource() { ResourceID = 6, Name = "Trainers" });
        result.Add(new TaskResource() { ResourceID = 7, Name = "Technical Communicators" });
        result.Add(new TaskResource() { ResourceID = 8, Name = "Deployment Team" });
        return result;
    }
    static List<ResourceAssignment> CreateResourceAssignments() {
        var result = new List<ResourceAssignment>();
        int uniqueID = 0;
        foreach (Task task in Tasks) {
            if (!string.IsNullOrEmpty(task.Employees)) {
                string[] empIDs = task.Employees.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < empIDs.Length; i++)
                    result.Add(new ResourceAssignment() { ResourceAssignmentID = uniqueID++, TaskID = task.ID, ResourceID = Convert.ToInt32(empIDs[i]) });
            }
        }
        return result;
    }
}
