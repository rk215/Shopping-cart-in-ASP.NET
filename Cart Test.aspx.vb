Imports System.Data.SqlClient
Imports System.Data
Partial Class Cart_Test
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("testConnectionString").ConnectionString)
    Dim cmd As SqlCommand
    Dim ad As SqlDataAdapter
    Dim ds As New DataSet


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'LOAD ALL DATA IN GRIDVIEW.

            bind()

        End If
    End Sub
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit

        GridView1.EditIndex = -1
        bind()


    End Sub
    Protected Sub bind()
        'METHOD TO BIND GRIDVIEW.
        cmd = New SqlCommand("select * from cart", con)
        con.Open()
        cmd.ExecuteNonQuery()
        ad = New SqlDataAdapter(cmd)
        ad.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataSourceID = ""
        GridView1.DataBind()
        con.Close()

    End Sub
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing

        'SET NEW EDITINDEX AS GRIDVIEW INDEX FOR PERFORMING EDITING OPERATION.
        GridView1.EditIndex = e.NewEditIndex
        'CALL BIND() TO BIND GRIDVIEW.
        bind()

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Dim i As Integer = MsgBox("Are you want to delete records", vbYesNo, "Confirmation")

        'YES WILL RETURN 6 , NO WILL RETURN 7
        If i = 6 Then
            'FIND THE LABEL ID IN ITEM TEMPLATE OF GRIDVIEW.
            Dim lbid As Label = DirectCast(GridView1.Rows(e.RowIndex).FindControl("Itemlbid"), Label)

            'DELETE THE RECORD .
            cmd = New SqlCommand("delete from cart where id=@id", con)
            cmd.Parameters.AddWithValue("@id", lbid.Text)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            'DISABLE EDIT MODE BY PASSING NAGETIVE VALUE.
            GridView1.EditIndex = -1
            'CALL BIND() TO BIND GRIDVIEW.
            bind()

        End If


    End Sub
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating

        'FIND ALL REQUIRED CONTROL FOR MAKING UPDATE THE PRICE,QTY BASED ON UNIQUE ID.
        Dim ids As Label = DirectCast(GridView1.Rows(e.RowIndex).FindControl("Editlbid"), Label)
        Dim price As Label = DirectCast(GridView1.Rows(e.RowIndex).FindControl("Editlbprice"), Label)
        Dim qty As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DropDownList1"), DropDownList)

        'MANUALLY SET THE PRICE VALUE TO LOCAL PR VARIABLE.
        '-----------------------SET INDEX AND PRICE FOR PRODUCT--------------------


        Dim pr As Integer
        'WE COMPARE THE DATABASE ID COLUMN VALUE WITH GRIDVIEW ID COLUMN.
        If ids.Text = 1 Then
            'MEANS WHO'S ID IS 1 WE PASS PRICE AS 10000
            pr = 10000
        End If

        If ids.Text = 3 Then
            'MEANS WHO'S ID IS 3 WE PASS PRICE AS 20000
            pr = 20000
        End If

        If ids.Text = 2 Then
            'MEANS WHO'S ID IS 2 WE PASS PRICE AS 40000
            pr = 40000
        End If

        If ids.Text = 4 Then
            'MEANS WHO'S ID IS 4 WE PASS PRICE AS 15000
            pr = 15000
        End If

        If ids.Text = 1004 Then
            'MEANS WHO'S ID IS 5 WE PASS PRICE AS 52000
            pr = 52000
        End If

'-----------------------END OF SETING ID'S AND PRICE FOR PRODUCT-----------------------

        'SIMPLY UPDATE THE RECORD.

        cmd = New SqlCommand("update cart set price=@price,qty=@qty where id=@id", con)
        cmd.Parameters.AddWithValue("@price", qty.SelectedValue * pr)

        cmd.Parameters.AddWithValue("@qty", qty.Text)
        cmd.Parameters.AddWithValue("@id", ids.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        ' Reset THE EDITINDEX TO -1 (DISABLE EDIT TEMPLATE).
        GridView1.EditIndex = -1
        'BIND ALL RECORDS BY CALLING BIND METHOD.
        bind()




    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'FOR REDIRECT THE PAGE TO PRODUCTPAGE(HOME PAGE).
        Response.Redirect("ProductPage.aspx")
    End Sub

    'CALCULATING THE TOTAL PRICE.
    Dim totalprice As Integer = 0
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound

        'CHECK HOW MANY DATAROW IS AVAILABLE
        If e.Row.RowType = DataControlRowType.DataRow Then

            'RETURN ALL PRICE COLUMN VALUE OF DATAITEM(DATASET) AND INCREMENT THE TOTALPRICE VALUE EACH TIME TILL END OF DATAROW.
            totalprice += CInt(DataBinder.Eval(e.Row.DataItem, "price"))

        ElseIf e.Row.RowType = DataControlRowType.Footer
            'BIT OF STYLING
            e.Row.Cells(5).Style.Add("font-size", "18px")
            e.Row.Cells(5).Style.Add("font-style", "italic")
            e.Row.Cells(5).Style.Add("color", "#54565c")
            'DISPLAY MESSAGE OF AT CELL NUMBER 5.
            e.Row.Cells(5).Text = "cart total:"
            'BIT OF STYLING
            e.Row.Cells(6).Style.Add("font-size", "20px")
            e.Row.Cells(6).Style.Add("color", "#666666")
            'PASS TOTAL PRICE VALUE TO CELL NUMBER 6 .
            e.Row.Cells(6).Text = totalprice.ToString
        End If

    End Sub

End Class
