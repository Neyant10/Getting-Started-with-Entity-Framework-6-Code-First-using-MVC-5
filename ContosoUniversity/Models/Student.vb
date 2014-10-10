Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models
    Public Class Student
        Public Property ID As Integer

        <Display(Name:="Last Name")>
        <StringLength(50)>
        <Required>
        Public Property LastName As String

        <Display(Name:="First Name")>
        <Column("FirstName")>
        <StringLength(50, ErrorMessage:="First name cannot be longer than 50 characters")>
        Public Property FirstMidName As String

        <Display(Name:="Enrollment Date")>
        <DataType(DataType.Date)>
        <DisplayFormat(DataFormatString:="{0:d}", ApplyFormatInEditMode:=True)>
        Public Property EnrollmentDate As DateTime

        <Display(Name:="Full Name")>
        Public ReadOnly Property FullName
            Get
                Return LastName + ", " + FirstMidName
            End Get
        End Property
        Public Overridable Property Enrollments As ICollection(Of Enrollment)

    End Class
End Namespace

