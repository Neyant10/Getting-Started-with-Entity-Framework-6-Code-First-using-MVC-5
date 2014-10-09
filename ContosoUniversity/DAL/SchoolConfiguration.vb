Imports System.Data.Entity
Imports System.Data.Entity.SqlServer

Namespace DAL
    Public Class SchoolConfiguration
        Inherits DbConfiguration

        Public Sub New()
            SetExecutionStrategy("System.Data.SqlClient", Function() New SqlAzureExecutionStrategy)
        End Sub

    End Class

End Namespace