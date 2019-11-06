<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ASPxGantt.CustomJSProperties.aspx.cs" Inherits="ASPxGantt_CustomJSProperties" %>

<%@ Register Assembly="DevExpress.Web.ASPxGantt.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGantt" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function onEndCallback(s, e) {
            if (s.cpProgressUpdated) {
                alert("Progress on task has been changed. It is " + s.cpProgressUpdated + "% now");
                delete s.cpProgressUpdated;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>CustomJSProperties - Progress Changed handling example. Try to change a task progress to see the effect.</h3>
            <dx:ASPxGantt ID="ASPxGantt1" runat="server" TasksDataSourceID="taskDataSource"
                OnCustomJSProperties="ASPxGantt1_CustomJSProperties" Height="900px"
                OnDataUpdate="ASPxGantt1_DataUpdate">
                <ClientSideEvents EndCallback="onEndCallback" />
                <SettingsTaskList Width="300"></SettingsTaskList>
                <Mappings>
                    <Task Start="StartDate" End="EndDate" ID="ID" ParentID="ParentID" Progress="PercentComplete" Title="Subject" />
                </Mappings>
                <SettingsEditing Enabled="true" AllowTaskUpdate="true" />
            </dx:ASPxGantt>

            <%-- required markup:
                 <dx:ASPxGantt ID="ASPxGantt1" runat="server" TasksDataSourceID="taskDataSource"
                OnCustomJSProperties="ASPxGantt1_CustomJSProperties"
                OnDataUpdate="ASPxGantt1_DataUpdate">
                <ClientSideEvents EndCallback="onEndCallback" />
                <Mappings>
                    <Task Start="StartDate" End="EndDate" ID="ID" ParentID="ParentID" Progress="PercentComplete" Title="Subject" />
                </Mappings>
                <SettingsEditing Enabled="true" AllowTaskUpdate="true" />
            </dx:ASPxGantt>
                
                
            --%>
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
                DataObjectTypeName="TaskResourceAssignment" SelectMethod="GetResourceAssignments"
                TypeName="ProjectDataContext"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
