Imports System.Data.SqlClient
Imports System.Data
Partial Class Details
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("testConnectionString").ConnectionString)
    Dim cmd As SqlCommand
    Dim ad As SqlDataAdapter
    Dim ds As New DataSet
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'FIND ALL CONTROL VALUE OF GRIDVIEW FOR STORE THAT VALUE IN CART TABLE.

        Dim lbid As Label = DirectCast(DetailsView1.FindControl("lbid"), Label)
        Dim lbnm As Label = DirectCast(DetailsView1.FindControl("Lbname"), Label)
        Dim lbdesc As Label = DirectCast(DetailsView1.FindControl("Lbdesc"), Label)
        Dim lbprice As Label = DirectCast(DetailsView1.FindControl("Lbprice"), Label)
        Dim img As Image = DirectCast(DetailsView1.FindControl("Image1"), Image)

        'CREATE COOKIE VARIABLE FOR STORING VALUE WHICH WAS FOUND IN DETAILSVIEW CONTRL 
        'COOKIE NAME IS CART.
        Dim cartcookie As New HttpCookie("cart")
        cartcookie.Values.Add("price", lbprice.Text)
        cartcookie.Values.Add("lb", lbid.Text)
        cartcookie.Values.Add("nm", lbnm.Text)
        cartcookie.Values.Add("desc", lbdesc.Text)
        cartcookie.Values.Add("img", img.ImageUrl)
        cartcookie.Values.Add("qty", 1)
        'SET EXPIRE TIME OF COOKIE.
        cartcookie.Expires = DateTime.Now.AddDays(2)
        'STORE ALL VALUE IN COOKIE BY COOKIE OBJECT.
        Response.Cookies.Add(cartcookie)



        'CHECK WETHER THE PRODUCT IS STORED IN CART TABLE OR NOT.

        cmd = New SqlCommand("select * from cart where id=" + lbid.Text, con)
        con.Open()
        cmd.ExecuteNonQuery()
        Using dr As SqlDataReader = cmd.ExecuteReader()
            If dr.HasRows Then
                Label1.Text = "Already Added to cart"

            Else
                dr.Close()
                'MEANS IT'S NEW PRODUCT SO WE HAVE TO INSET INTO CART TABLE.
                cmd = New SqlCommand("insert into cart values(@id,@nm,@desc,@price,@img,@qty)", con)
                cmd.Parameters.AddWithValue("@id", lbid.Text)
                cmd.Parameters.AddWithValue("@qty", 1)
                cmd.Parameters.AddWithValue("@price", lbprice.Text)
                cmd.Parameters.AddWithValue("@desc", lbdesc.Text)
                cmd.Parameters.AddWithValue("@img", img.ImageUrl)
                cmd.Parameters.AddWithValue("@nm", lbnm.Text)
                cmd.ExecuteNonQuery()
                con.Close()
                Label1.Text = "Product is Added to Cart"
            End If
        End Using

    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'REDIRECT USER TO CART.ASPX PAGE.
        Response.Redirect("Cart Test.aspx")
    End Sub

End Class
