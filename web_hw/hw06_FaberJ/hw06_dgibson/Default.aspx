<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hw06_dgibson.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW 06 - Patient Management System</title>
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2>HW 6 - James Faber</h2>
        <h3>Patient Management System, <a href="hw6_gradeReport.xlsx">Grade Report</a>, <a href="hw6_timeLog.xlsx">Time Log</a></h3>

        <hr />

        <p><strong>Patients</strong></p>
        <asp:GridView ID="gvPatients" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="PatientID" DataSourceID="dsPatients" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvPatients_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="PatientID" HeaderText="PatientID" InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
		</asp:GridView>
		<asp:SqlDataSource ID="dsPatients" runat="server" ConnectionString="<%$ ConnectionStrings:patientsConnectionString %>" DeleteCommand="DELETE FROM [Patients] WHERE [PatientID] = ?" InsertCommand="INSERT INTO [Patients] ([LastName], [FirstName], [Address]) VALUES (?, ?, ?)" ProviderName="<%$ ConnectionStrings:patientsConnectionString.ProviderName %>" SelectCommand="SELECT [PatientID], [LastName], [FirstName], [Address] FROM [Patients]" UpdateCommand="UPDATE [Patients] SET [LastName] = ?, [FirstName] = ?, [Address] = ? WHERE [PatientID] = ?">
            <DeleteParameters>
                <asp:Parameter Name="PatientID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="PatientID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
		<asp:Label ID="lblDeletePatientFailure" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:Button runat="server" Text="Add Patient" ID="btnAddPatient" OnClick="btnAddPatient_Click" />
&nbsp;Last Name
        <asp:TextBox ID="txtLName" runat="server" Width="75px"></asp:TextBox>
&nbsp;First Name
        <asp:TextBox ID="txtFName" runat="server" Width="75px"></asp:TextBox>
&nbsp;Address
        <asp:TextBox ID="txtAddress" runat="server" Width="150px"></asp:TextBox>
        <br />
        <p>
            Total charges for selected patient:
            <asp:Label ID="lblTotalCharges" runat="server" Font-Bold="True" 
                ForeColor="Red" Text="Put total charges here"></asp:Label>
            <br />
        </p>
        <p>
            <strong>Visits - </strong>
            <asp:Label ID="lblPatient" runat="server" 
                Text="Put Selected Patient Name Here: LName, FName" Font-Bold="True" 
                ForeColor="Red"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="gvVisits" runat="server" DataSourceID="dsVisits" DataKeyNames ="VisitID" OnSelectedIndexChanged="gvVisits_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                </Columns>
			</asp:GridView>
			<asp:SqlDataSource ID="dsVisits" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT [VisitID], [VisitDate], [Charge], [Notes] FROM [Visits] WHERE ([PatientID] = ?)" DeleteCommand="DELETE FROM [Visits] WHERE [VisitID] = ?" InsertCommand="INSERT INTO [Visits] ([VisitDate], [Charge], [Notes]) VALUES (?, ?, ?)" UpdateCommand="UPDATE [Visits] SET [VisitDate] = ?, [Charge] = ?, [Notes] = ? WHERE [VisitID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="VisitID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="VisitDate" Type="DateTime" />
                    <asp:Parameter Name="Charge" Type="Decimal" />
                    <asp:Parameter Name="Notes" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvPatients" Name="PatientID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="VisitDate" Type="DateTime" />
                    <asp:Parameter Name="Charge" Type="Decimal" />
                    <asp:Parameter Name="Notes" Type="String" />
                    <asp:Parameter Name="VisitID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
			<asp:Label ID="lblDeleteVisitFailure" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        </p>
        <p>
        <asp:Button ID="btnAddVisit" runat="server" Text="Add Visit" OnClick="btnAddVisit_Click" />
            &nbsp;Date
        <asp:TextBox ID="txtDate" runat="server" Width="75px"></asp:TextBox>
            &nbsp;Charge
        <asp:TextBox ID="txtCharge" runat="server" Width="75px"></asp:TextBox>
            &nbsp;Notes
        <asp:TextBox ID="txtNotes" runat="server" Width="150px"></asp:TextBox>
        </p>
        <p>
            <strong>Prescriptions - </strong>
            <asp:Label ID="lblVisitDate" runat="server" Text="Put Selected Visit Date Here" 
                Font-Bold="True" ForeColor="Red"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="gvPrescriptions" runat="server" AutoGenerateColumns="False" DataKeyNames="PrescriptionID" DataSourceID="dsPrescriptions">
                <Columns>
                    <asp:BoundField DataField="PrescriptionID" HeaderText="PrescriptionID" InsertVisible="False" ReadOnly="True" SortExpression="PrescriptionID" />
                    <asp:BoundField DataField="DrugName" HeaderText="DrugName" SortExpression="DrugName" />
                    <asp:BoundField DataField="Instructions" HeaderText="Instructions" SortExpression="Instructions" />
                </Columns>
			</asp:GridView>
            <asp:SqlDataSource ID="dsPrescriptions" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Prescriptions] WHERE [PrescriptionID] = ?" InsertCommand="INSERT INTO [Prescriptions] ([PrescriptionID], [DrugName], [Instructions]) VALUES (?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [PrescriptionID], [DrugName], [Instructions] FROM [Prescriptions] WHERE ([VisitID] = @VisitID)" UpdateCommand="UPDATE [Prescriptions] SET [DrugName] = ?, [Instructions] = ? WHERE [PrescriptionID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="PrescriptionID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PrescriptionID" Type="Int32" />
                    <asp:Parameter Name="DrugName" Type="String" />
                    <asp:Parameter Name="Instructions" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvVisits" Name="VisitID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="DrugName" Type="String" />
                    <asp:Parameter Name="Instructions" Type="String" />
                    <asp:Parameter Name="PrescriptionID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </p>
        <p>
        <asp:Button ID="btnAddPrescriptions" runat="server" Text="Add Prescription" />
            &nbsp;Drug Name
        <asp:TextBox ID="txtDrugName" runat="server" Width="75px"></asp:TextBox>
            &nbsp;Instructions
        <asp:TextBox ID="txtInstructions" runat="server" Width="170px"></asp:TextBox>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="txtMsg" runat="server" Height="259px" TextMode="MultiLine" Width="698px"></asp:TextBox>
		</p>

       <hr />

        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        </div>
    </form>
</body>

</html>
