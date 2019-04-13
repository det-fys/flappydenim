Module prikazy
    Function prikaz(id As Integer) As String
        Select Case id
            Case 0 : Return "-censored-"
            Case 1 : Return "-censored-"
            Case 2 : Return "DFLAG"
            Case 3 : Return "DFTX"
            Case 4 : Return "DFINFO"
            Case 5 : Return "DFTS"
            Case 6 : Return "DFCR"
            Case 7 : Return "-censored-"
            Case 8 : Return "-censored"
            Case 9 : Return "-censored"
            Case 10 : Return "-censored-"
            Case 11 : Return "DFDEF"
        End Select

        Return ""
    End Function
End Module
