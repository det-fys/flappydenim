﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Tento kód byl generován nástrojem.
'     Verze modulu runtime:4.0.30319.42000
'
'     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
'     dojde-li k novému generování kódu.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    'POZNÁMKA: Neměňte přímo tento soubor, protože se generuje automaticky.  Pokud chcete provést změny,
    ' nebo pokud dojde v tomto souboru k chybám sestavení, jděte do návrháře projektu
    ' (přejděte na vlastnosti projektu, nebo dvakrát klikněte na uzel Můj projekt v
    ' průzkumníku řešení), a proveďte změny v kartě Aplikace.
    '
    Partial Friend Class MyApplication
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = false
            Me.EnableVisualStyles = true
            Me.SaveMySettingsOnExit = true
            Me.ShutDownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.flappydenim.frmMain
        End Sub
    End Class
End Namespace