Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models
    Public Class Department
        Public Property DepartmentID As Integer

        <StringLength(50, MinimumLength:=3)>
        Public Property Name As String

        <DataType(DataType.Currency)>
        <Column(TypeName:="money")>
        Public Property Budget As Decimal

        <DataType(DataType.Date)>
        <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
        <Display(name:="Start Date")>
        Public Property StartDate As DateTime

        Public Property InstructorID As Integer?

        Public Overridable Property Administrator As Instructor

        Public Overridable Property Courses As ICollection(Of Course)

    End Class
End Namespace