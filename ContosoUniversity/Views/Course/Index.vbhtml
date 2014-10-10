@ModelType IEnumerable(Of ContosoUniversity.Models.Course)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Department.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Credits)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Department.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Credits)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.CourseID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.CourseID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.CourseID })
        </td>
    </tr>
Next

</table>
