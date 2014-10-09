﻿@Model IEnumerable(of ContosoUniversity.ViewModels.EnrollmentDateGroup)
@Code
    ViewData("Title") = "Student Body Statistics"
End Code

<h2>@ViewData("Title")</h2>


<table>
    <tr>
        <th>
            Enrollment Date
        </th>
        <th>
            Students
        </th>
    </tr>

    @For Each item As ContosoUniversity.ViewModels.EnrollmentDateGroup In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EnrollmentDate)
        </td>
        <td>
            @item.StudentCount
        </td>
    </tr>
    Next
</table>