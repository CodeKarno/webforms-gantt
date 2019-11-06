<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ASPxGantt.DataUpdate.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGantt.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGantt" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>DataUpdate example. Try to edit and save.</h3>
            <dx:ASPxGantt ID="ASPxGantt1" runat="server" TasksDataSourceID="taskDataSource" DependenciesDataSourceID="dependencyDataSource"
                ResourceAssignmentsDataSourceID="resourceAssignmentDataSource" ResourcesDataSourceID="resourceDataSource" Height="900px"
                OnDataUpdate="ASPxGantt1_DataUpdate">
                <SettingsGanttView ShowResources="true" />
                <SettingsTaskList Width="300"></SettingsTaskList>
                <Mappings>
                    <Task Start="StartDate" End="EndDate" ID="ID" ParentID="ParentID" Progress="PercentComplete" Title="Subject" />
                    <Dependency DependencyType="Type" ID="DependencyID" PredecessorID="ParentID" SuccessorID="DependentID" />
                    <Resource ID="ResourceID" Name="Name" />
                    <ResourceAssignment ID="ResourceAssignmentID" ResourceID="ResourceID" TaskID="TaskID" />
                </Mappings>
                <SettingsEditing Enabled="true"
                    AllowDependencyDelete="true" AllowDependencyInsert="true" AllowResourceAssignmentDelete="true" AllowResourceAssignmentInsert="true" AllowResourceDelete="true"
                    AllowResourceInsert="true" AllowResourceUpdate="true" AllowTaskDelete="true" AllowTaskUpdate="true" AllowTaskInsert="true" />
            </dx:ASPxGantt>
          
            <asp:ObjectDataSource ID="taskDataSource" runat="server"
                DataObjectTypeName="Task" SelectMethod="GetTasks"
                TypeName="ProjectDataContext"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="dependencyDataSource" runat="server"
                DataObjectTypeName="Dependency" SelectMethod="GetDependencies"
                TypeName="ProjectDataContext"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="resourceDataSource" runat="server"
                DataObjectTypeName="TaskResource" SelectMethod="GetResources"
                TypeName="ProjectDataContext"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="resourceAssignmentDataSource" runat="server"
                DataObjectTypeName="ResourceAssignment" SelectMethod="GetResourceAssignments"
                TypeName="ProjectDataContext"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
