
Partial Class ProductPage
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        'PASS GRIDVIEW SELECTED VALUE IN THE FORM OF QUERY STRING TO PRODUCTDETAILS PAGE.
        Response.Redirect("Details.aspx?id=" + Convert.ToString(GridView1.SelectedValue))

    End Sub
End Class
