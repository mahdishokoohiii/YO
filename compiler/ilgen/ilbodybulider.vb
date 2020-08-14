﻿Public Class ilbodybulider

    Public ildt As ilformat.ildata

    Private msilsource As String
    Public ReadOnly Property source() As String
        Get
            Return msilsource
        End Get
    End Property
    Public Sub New(ilclassdata As ilformat.ildata)
        ildt = ilclassdata
    End Sub

    Public Function conv_to_msil() As String
        For index = 0 To ildt.assemblyextern.Length - 1
            add_assembly(ildt.assemblyextern(index))
        Next

        imp_module("YO_Main")
        newline()

        For index = 0 To ildt.ilmethod.Length - 1
            newline()
            imp_func(ildt.ilmethod(index))
        Next

        newline()
        add_en_block()

        Return source
    End Function


    Public Sub imp_func(funcdt As ilformat._ilmethodcollection)
        Dim headfuncdt As String = ".method static"
        If funcdt.accessible = ilformat._accessiblemethod.PUBLIC Then
            headfuncdt &= " public "
        Else
            headfuncdt &= " private "
        End If

        If funcdt.returntype = "[void]" Then
            headfuncdt &= "void"
        Else
            'other types
        End If

        headfuncdt &= Space(1) & funcdt.name & "()"
        headfuncdt &= " cil managed"

        add_il_code(headfuncdt)
        add_st_block()

        If funcdt.entrypoint Then
            add_il_code(".entrypoint")
        End If

        imp_body(funcdt)

        add_en_block()
    End Sub

    Private Sub imp_body(funcdt As ilformat._ilmethodcollection)
        For index = 0 To funcdt.codes.Count - 1
            add_il_code(funcdt.codes(index))
        Next
    End Sub
    Private Sub imp_module(name As String)
        'check name
        add_il_code(".class private auto ansi sealed " & name)
        add_st_block()
    End Sub

    Public Sub add_st_block()
        add_il_code("{")
    End Sub
    Public Sub add_en_block()
        add_il_code("}")
    End Sub

    Public Sub newline()
        add_il_code("")
    End Sub
    Public Sub add_assembly(assemblydt As ilformat._ilassemblyextern)
        'check uniq assembly
        'check names
        If assemblydt.isextern Then
            add_il_code(".assembly extern " & assemblydt.name & assemblydt.assemblyproperty)
        Else
            add_il_code(".assembly " & assemblydt.name & assemblydt.assemblyproperty)
        End If
    End Sub
    Public Sub add_il_code(code As String)
        msilsource &= vbCrLf & code
    End Sub

End Class