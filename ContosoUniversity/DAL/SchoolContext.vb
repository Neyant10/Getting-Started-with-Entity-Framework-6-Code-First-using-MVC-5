Imports System.Data.Entity
Imports ContosoUniversity.Models
Imports System.Data.Entity.ModelConfiguration.Conventions

Namespace DAL
    Public Class SchoolContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("SchoolContext")
        End Sub

        Public Property Students As DbSet(Of Student)
        Public Property Enrollments As DbSet(Of Enrollment)
        Public Property Courses As DbSet(Of Course)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        End Sub
    End Class

End Namespace
