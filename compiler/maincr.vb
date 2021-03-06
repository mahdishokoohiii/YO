﻿Module maincr
    Const BYPASSFLOW As Boolean = True
    Sub main(ByVal argsval() As String)
        Try
            init_class_data()
            If BYPASSFLOW Then
                cli.init_cli(False)
                cflowtester.lex_dir(conrex.APPDIR & "\myapp\")
                Console.ReadLine()
                Return
            End If
            If argsval.Length = 0 Then
                cli.init_cli(True)
                Console.ReadLine()
                Return
            End If
        Catch ex As Exception
            dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, Nothing, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub init_class_data()
        conserr.init_error_struct()
        tokenhared.init()
        init_essential_files()
        initcommondatatype.init_common_data_type()
        specificdustrcommand.init()
        ciltoken.init_cil_instruction()
    End Sub

    Sub init_essential_files()
        initessentialfiles.add_path(conrex.APPDIR & "\ilasm.exe")
        initessentialfiles.add_path(conrex.APPDIR & "\fusion.dll")
    End Sub
End Module
