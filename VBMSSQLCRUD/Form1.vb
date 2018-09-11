Imports System.Data.SqlClient
Public Class Form1
    Public conn As New SqlConnection("Data Source=ALLMANKIND\MSSQLSERVER8; Database=db_vbcrud; Integrated Security=True")
    Public adapter As New SqlDataAdapter
    Dim ds As DataSet
    Dim currentid As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRecords()
    End Sub

    Public Sub GetRecords()
        ds = New DataSet
        adapter = New SqlDataAdapter("select * from tbl_names", conn)
        adapter.Fill(ds, "tbl_names")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_names"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("insert into tbl_names (firstname, lastname) VALUES " &
                                     "('" & TextBox1.Text & "','" & TextBox2.Text & "')", conn)
        adapter.Fill(ds, "tbl_names")
        TextBox1.Clear()
        TextBox2.Clear()
        GetRecords()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()

        ds = New DataSet
        adapter = New SqlDataAdapter("delete from tbl_names where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_names")
        GetRecords()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()

        TextBox1.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(2, i).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("update tbl_names set firstname = '" & TextBox1.Text &
                                     "', lastname = '" & TextBox2.Text &
                                     "' where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_names")
        GetRecords()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
End Class
