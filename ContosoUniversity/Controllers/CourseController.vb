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
    Public Class CourseController
        Inherits System.Web.Mvc.Controller

        Private db As New SchoolContext

        ' GET: Course
        Function Index() As ActionResult
            Dim courses = db.Courses.Include(Function(c) c.Department)
            Return View(courses.ToList())
        End Function

        ' GET: Course/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim course As Course = db.Courses.Find(id)
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            Return View(course)
        End Function

        ' GET: Course/Create
        Function Create() As ActionResult
            ViewBag.DepartmentID = New SelectList(db.Departments, "DepartmentID", "Name")
            Return View()
        End Function

        ' POST: Course/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="CourseID,Title,Credits,DepartmentID")> ByVal course As Course) As ActionResult
            If ModelState.IsValid Then
                db.Courses.Add(course)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.DepartmentID = New SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID)
            Return View(course)
        End Function

        ' GET: Course/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim course As Course = db.Courses.Find(id)
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            ViewBag.DepartmentID = New SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID)
            Return View(course)
        End Function

        ' POST: Course/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="CourseID,Title,Credits,DepartmentID")> ByVal course As Course) As ActionResult
            If ModelState.IsValid Then
                db.Entry(course).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.DepartmentID = New SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID)
            Return View(course)
        End Function

        ' GET: Course/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim course As Course = db.Courses.Find(id)
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            Return View(course)
        End Function

        ' POST: Course/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim course As Course = db.Courses.Find(id)
            db.Courses.Remove(course)
            db.SaveChanges()
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
