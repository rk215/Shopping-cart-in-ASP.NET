Imports System.Data.SqlClient
Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("testConnectionString").ConnectionString)
    Dim cmd As SqlCommand
    Dim ad As SqlDataAdapter
    Dim ds As New DataSet
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'FOR INSERTING ALL INFORMATION TO PRODUCT TABLE.

        Dim path As String
        path = Server.MapPath("Images/")
        path = path + FileUpload1.FileName
        FileUpload1.SaveAs(path)
        path = "Images/" + FileUpload1.PostedFile.FileName

        'STORE IMAGE IN FOLLOWING FORMAT. "FOLDERNAME/IMAGENAME.EXTENTsION.

        cmd = New SqlCommand("insert into products values(@nm,@desc,@price,@img)", con)
        cmd.Parameters.AddWithValue("@img", path)
        cmd.Parameters.AddWithValue("@nm", TextBox1.Text)
        cmd.Parameters.AddWithValue("@desc", TextBox2.Text)
        cmd.Parameters.AddWithValue("@price", TextBox3.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        Response.Write("added")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class
