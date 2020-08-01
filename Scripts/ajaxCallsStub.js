Dis = [
     {
        DiscountsId : 1000,
        AirportName: "ELAL",
        FromCity: "JFK",
        ToCity: "TLV",
        StartAt: 2017,
        EndAt: 2018,
        Discount: 15
         
    },
    {
        DiscountsId: 1001,
        AirportName: "ELAL",
        FromCity: "JFK",
        ToCity: "TLV",
        StartAt: 2017,
        EndAt: 2018,
        Discount: 15

    },
    {
        DiscountsId: 1002,
        AirportName: "ELAL",
        FromCity: "JFK",
        ToCity: "TLV",
        StartAt: 2017,
        EndAt: 2018,
        Discount: 15

    }
     
];


function ajaxCall(method, api, data, successCB, errorCB) {
    //$.ajax({
    //    type: method,
    //    url: api,
    //    data: data,
    //    cache: false,
    //    contentType: "application/json",
    //    dataType: "json",
    //    success: successCB,
    //    error: errorCB
    //});

    if (method == "GET" && api == "../api/Manager") {
        successCB(Dis);
        return;
    }

    else if (method == "PUT" && api == "../api/Manager") {
        let discountdata = JSON.parse(data);
        for (var i = 0; i < Dis.length; i++) {
            if (Dis[i].DiscountsId == discountdata.DiscountsId) {
                Dis[i] = discountdata;
                
                successCB(Dis);
                return;
            }
        }

        errorCB("did not manage to update the DB");
    }


    else if (method == "POST" && api == "../api/Manager") {
        let discountdata = JSON.parse(data);
        discountdata.DiscountsId = getMaxId(Dis) + 1;
        Dis.push(discountdata);
        successCB(Dis);
        //errorCB("did not manage to insert the new car into the DB");
    }

    else if (method == "DELETE") {
        splitArr = api.split('/');
        let id = splitArr[splitArr.length - 1];
        temp = [];
        index = 0;
        for (var i = 0; i < Dis.length; i++) {
            if (parseInt(Dis[i].id) != id) {
                temp[index] = Dis[i];
                index++;
            }
        }
        Dis = temp;
        successCB(Dis);
    }


}

function getMaxId(discountdata){
    let max = 0;
    for (var i = 0; i < discountdata.length; i++) {
        if (discountdata[i].DiscountsId > max)
            max = discountdata[i].Dis;
    }
    return max;
}
function successCB(data) {
    ajaxCallz("POST", "../api/Manager", JSON.stringify(data), postAPSuccessCB, postAPerrorCB);
    
}
function ajaxCallz(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB
    });
}
function postAPSuccessCB() {
    ajaxCallz("GET", "../api/Manager", "", getAPSuccessCB, getAPerrorCB);
}

function getAPSuccessCB(data) {
    Dis = data;
}