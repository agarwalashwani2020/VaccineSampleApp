function Home() {

    this.getAllStates = function () {
        $.ajax(
            {
                url: '/Home/GetAllStates',
                type: 'Get',
                dataType: 'json',
                success: function (response) {
                    let arr = [];
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
                success: function (response) {
                    console.log('testdata--', response);
                }
            })
    }
}

$(document).ready(function () {
    var home = new Home();

    home.getAllStates();

    $("#ddlStates").on("change", function (e) {
        let stateId = $(this).val();
        home.getAllDistricts(stateId);
    });

    $("#ddlDistrict").on("change", function (e) {
        let districtId = $(this).val();
        home.getCalendarByDistrict(districtId, "21-07-2021");
    });

    $('#example').DataTable();

});