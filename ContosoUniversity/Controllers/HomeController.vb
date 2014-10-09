Imports ContosoUniversity.DAL
Imports ContosoUniversity.ViewModels

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As SchoolContext = New SchoolContext

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        Dim data As IQueryable(Of EnrollmentDateGroup) = From student In db.Students
                                                         Group student By student.EnrollmentDate Into Count()
                                                         Select New EnrollmentDateGroup With {.EnrollmentDate = EnrollmentDate, .StudentCount = Count}

        Return View(data.ToList)
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
