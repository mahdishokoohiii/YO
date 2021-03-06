﻿Public Class conserr
    Enum errortype
        DIRNOTFOUND
        YOFILENOTFOUND
        TYPEERRORNUMERIC
        RUNTIMEERROR
        IDENTIFIERUNKNOWN
        STRINGDUENDWITH
        STRINGCOENDWITH
        IDENTIFIEREXPECTED
        FUNCOPBRACKETEXPECTED
        BLOCKOPENEXPECTED
        SYNTAXERROR
        MISSINGESSENTIALFILES
        DECLARINGERROR
        TYPENOTFOUND
        ERRORINCONVERT
        EXPLICITCONVERSION
        CONSTANTNUMOUTOFRANGE
        CILCOMMANDSENDWITH
        CILCOMMANDSAUTH
        CILLAZYERROR
        ATTRIBUTECLASSERROR
        ATTRIBUTEPROPERTYERROR
        ATTRIBUTESTRUCTERROR
        ATTRIBUTEDISABLED
        ASSIGNCONVERT
    End Enum

    Enum errorpriority
        IGNORE
        [STOP]
    End Enum
    Structure errorstruct
        Dim title As String
        Dim text As String
        Dim err As errortype
        Dim priority As errorpriority
    End Structure

    Public Shared err() As errorstruct
    Public Shared Sub set_new_error(errtype As errortype, errpriority As errorpriority, title As String, text As String)
        Static Dim indexarray As Int16 = 0
        Array.Resize(err, indexarray + 1)
        err(indexarray) = New errorstruct
        err(indexarray).err = errtype
        err(indexarray).priority = errpriority
        err(indexarray).title = title.ToUpper
        err(indexarray).text = text
        indexarray += 1
        Return
    End Sub

    Public Shared Sub init_error_struct()
        set_new_error(errortype.DIRNOTFOUND, errorpriority.STOP, "Directory not found", "Folder containing '.yo' files not found.")
        set_new_error(errortype.YOFILENOTFOUND, errorpriority.STOP, "YO file not found", "Project files [.yo] not found.")
        set_new_error(errortype.TYPEERRORNUMERIC, errorpriority.STOP, "Unknown numeric format", "Unknown numeric format found during code analysis.")
        set_new_error(errortype.RUNTIMEERROR, errorpriority.STOP, "Runtime error", "An unknown error occurred while running.")
        set_new_error(errortype.IDENTIFIERUNKNOWN, errorpriority.STOP, "Identifier unknown", "Identifier validation is ambiguous.
An identifier can contain numbers, letters, and '_'.
An identifier cannot start with a number.")
        set_new_error(errortype.STRINGDUENDWITH, errorpriority.STOP, "String constant error", "String constants must end with a double quote ("").")
        set_new_error(errortype.STRINGCOENDWITH, errorpriority.STOP, "String constant error", "String constants must end with a single quote (').")
        set_new_error(errortype.IDENTIFIEREXPECTED, errorpriority.STOP, "Critical error", "Identifier expected.")
        set_new_error(errortype.FUNCOPBRACKETEXPECTED, errorpriority.STOP, "Critical error", "Method arguments must be enclosed in parentheses.")
        set_new_error(errortype.FUNCOPBRACKETEXPECTED, errorpriority.STOP, "Critical error", "Expected '{’ ,to start a block of code.")
        set_new_error(errortype.FUNCOPBRACKETEXPECTED, errorpriority.STOP, "Critical error", "Syntax error.")
        set_new_error(errortype.MISSINGESSENTIALFILES, errorpriority.STOP, "Missing essential files", "Some software files were not found.
You can reinstall the software or email us.")
        set_new_error(errortype.DECLARINGERROR, errorpriority.STOP, "Declaring error", "This local variable is already declared in the current block.")
        set_new_error(errortype.TYPENOTFOUND, errorpriority.STOP, "Identifier unknown", "'{0}' is not declared. It may be inaccessible due to its protection level.")
        set_new_error(errortype.ERRORINCONVERT, errorpriority.STOP, "Assignment error", "Constant value '{0}' cannot be converted to a '{1}'.")
        set_new_error(errortype.EXPLICITCONVERSION, errorpriority.STOP, "Explicit conversion error", "Cannot implicitly convert type '{0}' to '{1}'.")
        set_new_error(errortype.CONSTANTNUMOUTOFRANGE, errorpriority.STOP, "Constant out of range", "'{0}' - The numeric constant is out of the data range. MAX = '{1}'  -   MIN = '{2}'")
        set_new_error(errortype.CILCOMMANDSENDWITH, errorpriority.STOP, "Cil commands error", "CIL block codes must end with a (>).")
        set_new_error(errortype.CILCOMMANDSAUTH, errorpriority.STOP, "Cil commands error", "CIL - Code block validation error.")
        set_new_error(errortype.CILLAZYERROR, errorpriority.STOP, "Cil commands error", "Intermediate grammar for injection is not valid.")
        set_new_error(errortype.ATTRIBUTECLASSERROR, errorpriority.STOP, "Attribute error", " '{0}' - This collection was not found.")
        set_new_error(errortype.ATTRIBUTEPROPERTYERROR, errorpriority.STOP, "Attribute error", " '{0}' - This property was not found.")
        set_new_error(errortype.ATTRIBUTESTRUCTERROR, errorpriority.STOP, "Attribute error", "The structure of the attribute is unknown (note that the structure has no spaces and characters like ("") or (').")
        set_new_error(errortype.ATTRIBUTEDISABLED, errorpriority.STOP, "Attribute error", "[{0}] - Access to this feature is disabled, enable it with feature {1} if needed.")
        set_new_error(errortype.ASSIGNCONVERT, errorpriority.STOP, "Assignment error", "'{0}' - Cannot be assignment to [type] -> '{1}'.")

    End Sub
End Class
