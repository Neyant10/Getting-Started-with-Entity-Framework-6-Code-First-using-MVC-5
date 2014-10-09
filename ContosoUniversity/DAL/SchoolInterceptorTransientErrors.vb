Imports ContosoUniversity.Logging
Imports System.Data.Entity.Infrastructure.Interception
Imports System.Data.SqlClient
Imports System.Reflection

Namespace DAL
    Public Class SchoolInterceptorTransientErrors
        Inherits DbCommandInterceptor

        Private _counter As Integer = 0
        Private _logger As ILogger = New Logger

        Public Overrides Sub ReaderExecuting(command As Common.DbCommand, interceptionContext As DbCommandInterceptionContext(Of Common.DbDataReader))
            Dim throwTransientErrors As Boolean = False
            If command.Parameters.Count > 0 AndAlso command.Parameters(0).Value.ToString = "Throw" Then
                throwTransientErrors = True
                command.Parameters(0).Value = "an"
                command.Parameters(1).Value = "an"
            End If
            If throwTransientErrors AndAlso _counter > 4 Then
                _logger.Information("Returning transient error for command {0}", command.CommandText)
                _counter += 1
                interceptionContext.Exception = CreateDummySqlException()
            End If
            MyBase.ReaderExecuting(command, interceptionContext)
        End Sub

        Private Function CreateDummySqlException() As Exception
            Dim sqlErrorNumber = 20
            Dim sqlErrorCtor = GetType(SqlError).GetConstructors(BindingFlags.Instance Or BindingFlags.NonPublic).Where(Function(c) c.GetParameters.Count = 7).Single
            Dim sqlError = sqlErrorCtor.Invoke(New Object() {sqlErrorNumber, CByte(0), CByte(0), "", "", "", 1})

            Dim errorCollection = Activator.CreateInstance(GetType(SqlErrorCollection), True)
            Dim addMethod = GetType(SqlErrorCollection).GetMethod("Add", BindingFlags.Instance Or BindingFlags.NonPublic)
            addMethod.Invoke(errorCollection, New Object() {sqlError})

            Dim sqlExceptionCtor = GetType(SqlException).GetConstructors(BindingFlags.Instance Or BindingFlags.NonPublic).Where(Function(c) c.GetParameters.Count = 4).Single
            Dim sqlException = CType(sqlExceptionCtor.Invoke(New Object() {"Dummy", errorCollection, Nothing, Guid.NewGuid}), SqlException)

            Return sqlException
        End Function

    End Class
End Namespace