Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports ContosoUniversity.DAL
Imports ContosoUniversity.Models

Namespace Controllers
    Public Class StudentController
        Inherits System.Web.Mvc.Controller

        Private db As New SchoolContext

        ' GET: Student
        Function Index(sortOrder As String) As ActionResult
            ViewBag.NameSortParam = If(String.IsNullOrEmpty(sortOrder), "name_desc", "")
            ViewBag.DateSortParam = If(sortOrder = "Date", "date_desc", "Date")

            Dim students = From s In db.Students
                           Select s

            Select Case sortOrder
                Case "name_desc"
                    students = students.OrderByDescending(Function(s) s.LastName)
                Case "Date"
                    students = students.OrderBy(Function(s) s.EnrollmentDate)
                Case "date_desc"
                    students = students.OrderByDescending(Function(s) s.EnrollmentDate)
                Case Else
                    students = students.OrderBy(Function(s) s.LastName)
            End Select
            Return View(students.ToList())
        End Function

        ' GET: Student/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim student As Student = db.Students.Find(id)
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function

        ' GET: Student/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Student/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="LastName,FirstMidName,EnrollmentDate")> ByVal student As Student) As ActionResult
            Try
                If ModelState.IsValid Then
                    db.Students.Add(student)
                    db.SaveChanges()
                    Return RedirectToAction("Index")
                End If
            Catch dex As DataException
                Debug.WriteLine(dex.ToString)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your network administrator.")
            End Try

            Return View(student)
        End Function

        ' GET: Student/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim student As Student = db.Students.Find(id)
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function

        ' POST: Student/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,LastName,FirstMidName,EnrollmentDate")> ByVal student As Student) As ActionResult
            Try
                If ModelState.IsValid Then
                    db.Entry(student).State = EntityState.Modified
                    db.SaveChanges()
                    Return RedirectToAction("Index")
                End If
            Catch dex As DataException
                Debug.WriteLine(dex.ToString)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.")
            End Try
            Return View(student)
        End Function

        ' GET: Student/Delete/5
        Function Delete(ByVal id As Integer?, Optional saveChangesError As Boolean? = False) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            If saveChangesError.GetValueOrDefault Then
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator."
            End If
            Dim student As Student = db.Students.Find(id)
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function

        ' POST: Student/Delete/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Delete(ByVal id As Integer) As ActionResult
            Try
                Dim student As Student = db.Students.Find(id)
                db.Students.Remove(student)
                db.SaveChanges()
            Catch dex As DataException
                Return RedirectToAction("Delete", New With {.id = id, .saveChangesError = True})
            End Try
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
