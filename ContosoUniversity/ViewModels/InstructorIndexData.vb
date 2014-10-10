Imports ContosoUniversity.Models

Namespace ViewModels
    Public Class InstructorIndexData
        Public Property Instructors As ICollection(Of Instructor)
        Public Property Courses As ICollection(Of Course)
        Public Property Enrollments As ICollection(Of Enrollment)
    End Class
End Namespace