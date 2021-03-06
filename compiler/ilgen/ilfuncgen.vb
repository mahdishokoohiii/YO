﻿Public Class ilfuncgen

    Private grabentrypoint As Boolean = False
    Private ilcollection As ilformat.ildata
    Private yoclassdt As tknformat._class
    Private _ilmethods(0) As ilformat._ilmethodcollection

    Public Sub New(ilcol As ilformat.ildata, yoclass As tknformat._class)
        ilcollection = ilcol
        yoclassdt = yoclass
        _ilmethods(0) = New ilformat._ilmethodcollection
    End Sub

    Public Function gen() As ilformat._ilmethodcollection()
        For index = 0 To yoclassdt.methods.Length - 1
            Dim _ilmethodslen As Integer = _ilmethods.Length
            Dim imethod As Int16 = _ilmethodslen - 1
            If _ilmethodslen <> 0 Then
                Array.Resize(_ilmethods, _ilmethodslen + 1)
            End If
            func_ilforamtter(yoclassdt.methods(index), imethod)
        Next
        Array.Resize(_ilmethods, _ilmethods.Length - 1)
        Return _ilmethods
    End Function


    Public Sub func_ilforamtter(yomethod As tknformat._method, ilmethodsindex As Integer)
        'Check name rules ...
        'Check uniq names
        _ilmethods(ilmethodsindex).name = yomethod.name
        If yomethod.name.ToLower = "main" Then
            If grabentrypoint = False Then
                _ilmethods(ilmethodsindex).entrypoint = True
                grabentrypoint = True
            Else
                'When two entry points 
                'set error
            End If
        End If

        _ilmethods(ilmethodsindex).accessible = ilformat._accessiblemethod.PUBLIC
        _ilmethods(ilmethodsindex).returntype = "[void]" 'yomethod.returntype

        Dim iltrans As New iltranscore(yomethod)
        iltrans.gen_transpile_code(_ilmethods(ilmethodsindex))
        ' _ilmethods(ilmethodsindex).codes = New ArrayList
        '_ilmethods(ilmethodsindex).codes.Add("ldstr ""Hello From YOLang""")
        '_ilmethods(ilmethodsindex).codes.Add("call void [mscorlib]System.Console::WriteLine(string)")
        ' _ilmethods(ilmethodsindex).codes.Add("ret")
    End Sub
End Class
