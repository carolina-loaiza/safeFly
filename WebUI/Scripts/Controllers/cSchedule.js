'use strict';

function cSchedule() {

    this.service = "schedule";
    this.ctrlActions = new ControlActions();
    this.columns = "Id,FlyNumber,Aproovement,Gate,Destiny,Departure,DepartureDate,ArriveDate";

    const selectAproovement = document.querySelector('#sltAproovement');
    const selectFlyNumber = document.querySelector('#sltFlyNumber');
    const selectGate = document.querySelector('#sltGate');
    const selectDeparture = document.querySelector('#sltDeparture');
    //document.getElementById('divStatus').style.visibility = 'hidden';

    this.Create = function () {

        let nid = 0;
        nid = Math.floor(Math.random() * (100000 - 1)) + 1;

        let sAproovement = selectAproovement.value;
        let sFlyNumber = selectFlyNumber.value;
        let sGate = selectGate.value;
        let sDeparture = selectDeparture.value;

        document.getElementById('txtId').value = nid;
        document.getElementById('txtAproovement').value = sAproovement;
        document.getElementById('txtFlyNumber').value = sFlyNumber;
        document.getElementById('txtGate').value = sGate;
        document.getElementById('txtDeparture').value = sDeparture;

        var seatData = {};
        seatData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, seatData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        let sAproovement = selectAproovement.value;
        let sFlyNumber = selectFlyNumber.value;
        let sGate = selectGate.value;
        let sDeparture = selectDeparture.value;

        document.getElementById('txtAproovement').value = sAproovement;
        document.getElementById('txtFlyNumber').value = sFlyNumber;
        document.getElementById('txtGate').value = sGate;
        document.getElementById('txtDeparture').value = sDeparture;

        var seatData = {};
        seatData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, seatData);
        //Refresca la tabla
        this.ReloadTable();
        //sessionStorage.removeItem('seatData');
        window.location.href = '/Dashboard/listSchedule';
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById('divStatus').style.visibility = 'visible';
    }

    this.GetGates = function () {
        let service = "gates";

        this.ctrlActions.GetToSelect(service, function (listGateResponse, success) {

            const listGate = listGateResponse[1];
            if (success) {
                let selectGate = document.querySelector('#sltGate');

                for (let i = 0; i < listGate.length; i++) {
                    let nuevaOpcion = new Option(listGate[i]['GateCode']);
                    nuevaOpcion.value = listGate[i]['GateCode'];
                    selectGate.appendChild(nuevaOpcion);
                }

            }


        });

    }


    this.GetFlight = function () {
        let service = "flight";

        this.ctrlActions.GetToSelect(service, function (listFlightResponse, success) {

            const listFlight = listFlightResponse[1];
            if (success) {
                let selectFlight = document.querySelector('#sltFlight');

                for (let i = 0; i < listFlight.length; i++) {
                    let nuevaOpcion = new Option(listFlight[i]['FlyNumber']);
                    nuevaOpcion.value = listFlight[i]['FlyNumber'];
                    selectFlight.appendChild(nuevaOpcion);
                }

            }


        });

    }

    this.GetDeparture = function () {
        let service = "Airport";

        this.ctrlActions.GetToSelect(service, function (listAirportResponse, success) {

            const listAirport = listAirportResponse[1];
            if (success) {
                let selectAirport = document.querySelector('#sltDeparture');

                for (let i = 0; i < listAirport.length; i++) {
                    let nuevaOpcion = new Option(listAirport[i]['NameAirport']);
                    nuevaOpcion.value = listAirport[i]['NameAirport'];
                    selectAirport.appendChild(nuevaOpcion);
                }

            }


        });
    }
}

$(document).ready(function () {

    var data = JSON.parse(sessionStorage.getItem('scheduleData'));

    if (data == null) {
        document.getElementById('btnCreate').style.visibility = 'visible';
        document.getElementById('btnUpdate').style.visibility = 'hidden';
    } else {
        document.getElementById('btnUpdate').style.visibility = 'visible';
        document.getElementById('btnCreate').style.visibility = 'hidden';
    }
    var cschedule = new cSchedule();
    cschedule.GetFlight();
    cschedule.GetDeparture();
    cschedule.GetGates();
    cschedule.BindFields(data);
    sessionStorage.removeItem('scheduleData');

});