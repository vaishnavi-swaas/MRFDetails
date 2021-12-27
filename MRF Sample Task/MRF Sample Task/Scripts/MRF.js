
//function UpdateReqStatus(ID, ReqStatus) {
//    var ans = true;
   
//    if (ReqStatus == 3) {
//        ans = confirm("Are you sure you want to reject this Record?");
//    }
//    if (ans) {
//        $.ajax({
//            url: "/MRF/UpdateRequestStatus",
//            data: { Email: Email, Password: Password },
//            type: "GET",
//            contentType: "application/json;charset=UTF-8",
//            dataType: "json",
//            success: function (result) {
               
//                loadData();
                
//            },
//            error: function (errormessage) {
//                alert(errormessage.responseText);
//            }
//        });
//    }
//}

function Add() {

    var addObj = {
        id: $('#id').val(),
        PositionName: $('#PositionName').val(),
        Created_By: $('#MRF_Created_By').val(), 
        MRF_Created_Date: $('#MRF_Created_Date').val(),
        Position_to_be_filled_before: $('#Position_to_be_filled_before').val(),
        Vacancy_For: $('input[name="radiovacancy"]:checked').val(),
        Vacancy_Type: $('input[name="vacancy"]:checked').val(),
        TerritoryHQ: $('#TerritoryHQ').val(),
        DivisionName: $('#DivisionName').val(),
        Min_Yrs: $('#Min_yrs').val(),
        Max_yrs: $('#Max_yrs').val(),
        MaxCTC: $('#MaxCTC').val(),
        MinCTC: $('#MinCTC').val(),
        Additional_Requirement: $('#Additional_Requirement').val(),
        

    };

    $.ajax({
        url: "/MRF/Add",
        data: JSON.stringify(addObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data != null || data == 1) {
                $('#result').html('Record Saved Successfully!');
                
            }
            else {
                alert('Error in save!'); 
            }

        }

    });
}
function Edit() {
    window.location="/Details/Details"
}

function getbyID(id) {
    alert(id);
    $.ajax({
        url: "/Details/GetbyID/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.id);
            $('#PositionName').val(result.PositionName);
            $('#MRF_Created_By').val(result.Created_By);
            var date = result.MRF_Created_Date;
            var nowdate = new Date(parseInt(date.substr(6)));
            $('#MRF_Created_Date').val(nowdate.toISOString().substring(0, 10));
            var beforedate = result.Position_to_be_filled_before;
            var Positiontobefilledbefore = new Date(parseInt(beforedate.substr(6)));
            $('#Position_to_be_filled_before').val(Positiontobefilledbefore.toISOString().substring(0, 10));
            $('input:radio[id="Fielduser"][value=' + result.Vacancy_For + ']').attr('checked', true)
            $('input:radio[id="Vacancy Type"][value=' + result.Vacancy_Type + ']').attr('checked', true)
            $('#TerritoryHQ').val(result.TerritoryHQ);
            $('#DivisionName').val(result.DivisionName);
            $('#Min_Yrs').val(result.Min_Yrs);
            $('#Max_yrs').val(result.Max_yrs);
            $('#MinCTC').val(result.MinCTC);
            $('#MaxCTC').val(result.MaxCTC);
            $('#Additional_Requirement').val(result.Additional_Requirement);






            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;

}

function EditMRF(id) {



    $.ajax({
        url: "/User/GetbyID/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.id);
            $('#PositionName').val(result.PositionName);
            $('#MRF_Created_By').val(result.Created_By);
            var date = result.MRF_Created_Date;
            var nowdate = new Date(parseInt(date.substr(6)));
            $('#MRF_Created_Date').val(nowdate.toISOString().substring(0, 10));
            var beforedate = result.Position_to_be_filled_before;
            var Positiontobefilledbefore = new Date(parseInt(beforedate.substr(6)));
            $('#Position_to_be_filled_before').val(Positiontobefilledbefore.toISOString().substring(0, 10));
            $('input:radio[id="Fielduser"][value=' + result.Vacancy_For + ']').attr('checked', true)
            $('input:radio[id="Vacancy Type"][value=' + result.Vacancy_Type + ']').attr('checked', true)
            $('#TerritoryHQ').val(result.TerritoryHQ);
            $('#DivisionName').val(result.DivisionName);
            $('#Min_Yrs').val(result.Min_Yrs);
            $('#Max_yrs').val(result.Max_yrs);
            $('#MinCTC').val(result.MinCTC);
            $('#MaxCTC').val(result.MaxCTC);
            $('#Additional_Requirement').val(result.Additional_Requirement);

            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;

}