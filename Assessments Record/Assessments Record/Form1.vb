Public Class frmAssessmentRecord

    'Declare Array
    Dim strArrName() As String
    Dim intArrICASS() As Integer
    Dim intArrISAT() As Integer
    Dim intCount As Integer

    Private Sub frmAssessmentRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Prevent error if arrarys are empty
        lstDisplay.Enabled = False
    End Sub

    Private Function CalcAverage(ByVal intIndex As Integer) As Integer
        'Calculate a students average mark
        Dim intCalcAverage As Integer
        intCalcAverage = CInt((intArrICASS(intIndex) + intArrISAT(intIndex)) / 2)

        Return intCalcAverage
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Check for empty textbox
        If txtName.Text = " " Then
            Beep()
            MessageBox.Show("Enter a Name", "Entry Error")
            txtName.Focus()
            Exit Sub
        End If

        'Re-dim arrays everytime an element is add
        'Preserve - keeps data elements that is already in the array
        ReDim Preserve strArrName(intCount)
        ReDim Preserve intArrICASS(intCount)
        ReDim Preserve intArrISAT(intCount)

        'Assign the contentd of the Name textbox to the array
        strArrName(intCount) = txtName.Text

        'Check for valid numeric input
        'Assign the contents of the ICASS textbox to the array
        If IsNumeric(txtICASS.Text) Then
            intArrICASS(intCount) = CInt(txtICASS.Text)
        Else
            Beep()
            MessageBox.Show("Enter a valid ICASS mark", "Entry Error")
            txtICASS.Clear()
            txtICASS.Focus()
            Exit Sub
        End If

        'Assign the contents of the ISAT textbox to the array
        If IsNumeric(txtISAT.Text) Then
            intArrISAT(intCount) = CInt(txtISAT.Text)
        Else
            Beep()
            MessageBox.Show("Enter a vaid ISAT mark", "Entry Error")
            txtISAT.Clear()
            txtISAT.Focus()
            Exit Sub
        End If

        intCount = intCount + 1

        'Reset all controls on the form
        txtName.Clear()
        txtICASS.Clear()
        txtISAT.Clear()
        txtName.Focus()


        If btnDisplay.Enabled = False Then
            btnDisplay.Enabled = True
        End If

    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        'Display data in the listbox
        'Calculate the Average for each student
        'Calculate the Class Average
        Dim i As Integer
        Dim intAverage As Integer = 0
        Dim intTotal As Integer = 0
        Dim sngClassAverage As Single = 0

        lstDisplay.Items.Clear()
        lstDisplay.Items.Add(" ")
        lstDisplay.Items.Add("Name: ".PadRight(21) &
                                             "ICASS: ".PadLeft(6) &
                                             "ISAT: ".PadLeft(5) & "Avg: ".PadLeft(5))
        lstDisplay.Items.Add(" ")

        For i = 0 To UBound(strArrName)
            'Call function to calculate Average mark for each student
            intAverage = CalcAverage(i)

            'Total averages returned by the function
            intTotal = intTotal + intAverage

            'Display Name, ICASS , ISAT marks and calculated average for each student
            lstDisplay.Items.Add(strArrName(i).PadRight(20) &
                                 intArrICASS(i).ToString.PadLeft(6) &
                                 intArrISAT(i).ToString.PadLeft(5) &
                                 intAverage.ToString.PadLeft(5))

        Next

        'Calculate and display the class Average
        sngClassAverage = CSng(intTotal / intCount)
        lstDisplay.Items.Add(" ")
        lstDisplay.Items.Add("The Class Average is :" & sngClassAverage.ToString("N2"))

        'Move the cursor to the Name textbox
        txtName.Focus()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear ListBox and set focus to Name textbox
        lstDisplay.Items.Clear()
        txtName.Focus()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Close the form
        Me.Close()

    End Sub
End Class
