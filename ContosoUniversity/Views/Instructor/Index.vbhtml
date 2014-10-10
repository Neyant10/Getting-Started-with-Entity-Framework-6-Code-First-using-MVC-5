@ModelType ContosoUniversity.ViewModels.InstructorIndexData
@Code
    ViewData("Title") = "Instructors"
End Code

<h2>ViewData("Title")</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            Last Name
        </th>
        <th>
            First Name
        </th>
        <th>
            Hire Date
        </th>
        <th>
            Office
        </th>
        <th></th>
    </tr>

    @For Each item In Model.Instructors
        Dim selectedRow As String = ""
        If item.ID = ViewBag.InstructorID Then
            selectedRow = "success"
        End If
        @<tr class="@selectedRow">
            <td>
                @Html.DisplayFor(Function(modelItem) item.LastName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FirstMidName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.HireDate)
            </td>
            <td>
                @If item.OfficeAssignment IsNot Nothing Then
                    @item.OfficeAssignment.Location
                End If
            </td>
            <td>
                @Html.ActionLink("Select", "Index", New With {.id = item.ID}) |
                @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
            </td>
        </tr>
    Next

</table>
