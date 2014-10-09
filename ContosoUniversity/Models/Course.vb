Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models
    Public Class Course
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        Public Property CourseID As Integer
        Public Property Title As String
        Public Property Credits As String
        Public Overridable Property Enrollments As ICollection(Of Enrollment)
    End Class

End Namespace