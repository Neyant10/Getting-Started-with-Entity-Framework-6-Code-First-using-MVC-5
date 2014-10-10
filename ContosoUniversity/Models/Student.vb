Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Namespace Models
    Public Class Student
        Public Property ID As Integer

        <DisplayName("Last Name")>
        <StringLength(50)>
        Public Property LastName As String

        <DisplayName("First Name")>
        <StringLength(50, ErrorMessage:="First name cannot be longer than 50 characters")>
        Public Property FirstMidName As String

        <DisplayName("Enrollment Date")>
        <DataType(DataType.Date)>
        <DisplayFormat(DataFormatString:="{0:d}", ApplyFormatInEditMode:=True)>
        Public Property EnrollmentDate As DateTime

        Public Overridable Property Enrollments As ICollection(Of Enrollment)

    End Class
End Namespace

