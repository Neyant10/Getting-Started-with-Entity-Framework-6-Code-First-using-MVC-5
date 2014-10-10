@ModelType IEnumerable(Of ContosoUniversity.Models.Course)
@Code
    ViewData("Title") = "Course"
End Code

<h2>@ViewData("Title")</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.CourseID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Credits)
        </th>
        <th>
            Department
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CourseID)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Title)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Credits)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Department.Name)
            </td>


            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.CourseID}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.CourseID}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.CourseID})
            </td>
        </tr>
    Next

</table>
