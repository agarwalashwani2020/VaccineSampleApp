function Home() {

    this.getAllStates = function () {
        $.ajax(
            {
                url: '/Home/GetAllStates',
                type: 'Get',
                dataType: 'json',
                success: function (response) {
                    let arr = [];

                    arr.push(`<option value='' disabled selected>--Select State--</option>`);

                    response.forEach(function (item) {
                        arr.push(`<option value='${item.state_id}'>${item.state_name}</option>`);
                    });
                    $("#ddlStates").html(arr.join(""));
                }
            })
    }


    this.getAllDistricts = function (stateId) {
        $.ajax(
            {
                url: '/Home/GetDistrictByStateId',
                type: 'Get',
                data: { stateId },
                dataType: 'json',
                success: function (response) {
                    
                    let arr = [];
                    arr.push(`<option value='' disabled selected>--Select District--</option>`);
                    response.districts.forEach(function (item) {
                        arr.push(`<option value='${item.district_id}'>${item.district_name}</option>`);
                    });
                    $("#ddlDistrict").html(arr.join(""));
                }
            })
    };

    this.getCalendarByDistrict = function (districtId, date) {
        $.ajax(
            {
                url: '/Home/GetCalendarByDistrict',
                type: 'Get',
                data: { districtId, date },
                dataType: 'json',
                success: function (response)
                {
                    let arr = [];
                    //let arrHeaders = [];
                    console.table(response);

                    //response.forEach(function (item) {
                    //    item.sessions.forEach(function (sess) {
                    //        arrHeaders.push(`<th>${sess.date}</th>`);
                    //    })
                    //});
                        

                    response.forEach(function (item) {
                        console.log(`<tr><td>${item.name}</td></tr>`);
                        //item.sessions.forEach(function (sess) {
                        //    arrHeaders.push(`<th>${sess.date}</th>`);
                        //})
                        arr.push(`
                                <tr>
                                    <td>
                                        <div>${item.name}</div>
                                        <div style='color:gray;font-size:8pt;width:200px;'>${item.address}</div>
                                        <div style='color:gray;font-size:8pt;'>${item.district_name}, ${item.center_id}</div>
                                        <div style='color:gray;font-size:8pt;'>${item.state_name}</div>
                                    </td>

                                    <td>

                                    <div style='display: flex;border-style: solid;margin: 5px 5px 5px 5px;'>
                                        <div id="wrapper">
                                          <div class="block">Dose1</div>
                                          <div class="block">${item.sessions[0].available_capacity_dose1}</div>
                                        </div>&nbsp;
                                        <div id="wrapper">
                                          <div style='background-color:green;color: white;font-size: xx-large;' class="block">${item.sessions[0].available_capacity}</div>
                                        </div>&nbsp;
                                        <div id="wrapper">
                                          <div class="block">Dose2</div>
                                          <div class="block">${item.sessions[0].available_capacity_dose2}</div>
                                        </div>
                                    </div>
                                    <div style='text-align:center;'>${item.sessions[0].vaccine}</div>
                                    <div style='text-align:center;color:red;'>${item.sessions[0].min_age_limit}+</div>
                                    </td>

                                </tr>`);

                    });
                    //$("#example > thead>tr").html(arrHeaders.join(''));
                    $("#example > tbody").html(arr.join(''));

                   


                    //$('#example').append(`<tr>'${response.name}</tr>`);
                    
                }
            })

        $('#example').DataTable();
    }
}

$(document).ready(function () {
    var home = new Home();

    
   // var data = $('#example').DataTable().rows.data();

    //console.log('tble--', data);

    home.getAllStates();

    $("#ddlStates").on("change", function (e) {
        let stateId = $(this).val();
        home.getAllDistricts(stateId);
    });

    $("#ddlDistrict").on("change", function (e) {
        let districtId = $(this).val();
        home.getCalendarByDistrict(districtId, "21-07-2021");
    });

    


    


    //var dataObject = eval(`
    //[
    //{
    //"COLUMNS":
    //    [
    //        {
    //            "title": "NAME"
    //        },
    //        {
    //            "title": "COUNTY"
    //        }
    //    ],

    //    "DATA":
    //      [
    //        [
    //            "John Doe","Fresno"
    //        ],
    //        [
    //            "Billy","Fresno"
    //        ],
    //        [
    //            "Tom","Kern"
    //        ],
    //        [
    //            "King Smith","Kings"
    //        ]
    //      ]
    //}
    //]`);
    //var columns = [];
    //$('#example').dataTable({
    //    "data": dataObject[0].DATA,
    //    "columns": dataObject[0].COLUMNS
    //});


        //$('#example').DataTable({
        //    ajax: {
        //        "data":
        //            [
                    
        //                "Tiger Nixon",
        //                "System Architect",
        //                "Edinburgh",
        //                "5421",
        //                "2011/04/25",
        //                "$320,800"                    
        //            ]
        //        }
        //});

});