﻿ <%@ Control Language="C#" AutoEventWireup="true" CodeFile="Components.ascx.cs" Inherits="RockWeb.Blocks.Administration.Components" %>

<asp:UpdatePanel runat="server">
<ContentTemplate>

    <Rock:ModalAlert ID="mdAlert" runat="server" />

    <asp:Panel ID="pnlList" runat="server" Visible="true" >
        
        <h4><asp:Literal ID="lTitle" runat="server" /></h4>
        <Rock:Grid ID="rGrid" runat="server" EmptyDataText="No Components Found" OnRowSelected="rGrid_Edit">
            <Columns>
                <Rock:ReorderField />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <Rock:BoolField DataField="IsActive" HeaderText="Active" />
                <asp:TemplateField>
                    <HeaderStyle CssClass="span1" />
                    <ItemStyle HorizontalAlign="Center"/>
                    <ItemTemplate>
                        <a id="aSecure" runat="server" class="btn btn-mini" height="500px"><i class="icon-lock"></i></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </Rock:Grid>

    </asp:Panel>

    <asp:Panel ID="pnlDetails" runat="server" Visible="false" CssClass="admin-details">
        
        <asp:ValidationSummary runat="server" CssClass="alert alert-error" />

        <fieldset>
            <legend><asp:Literal ID="lProperties" runat="server"></asp:Literal></legend>
            <asp:PlaceHolder ID="phProperties" runat="server"></asp:PlaceHolder>
        </fieldset>

        <div class="actions">
            <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" onclick="btnSave_Click" />
            <asp:LinkButton id="btnCancel" runat="server" Text="Cancel" CssClass="btn" CausesValidation="false" OnClick="btnCancel_Click" />
        </div>

    </asp:Panel>

</ContentTemplate>
</asp:UpdatePanel>
