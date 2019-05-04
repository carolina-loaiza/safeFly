'use strict';

function cSeat() {

    this.service = "seat";
    this.ctrlActions = new ControlActions();
    this.columns = "Id,SeatNumber,FlyNumber,SeatClass,Status";
    const selectSeatClass = document.querySelector('#sltSeatClass');
    const selectStatus = document.querySelector('#sltStatus');
    document.getElementById('divStatus').style.visibility = 'hidden';

    this.Create = function () {
        let seatClass = selectSeatClass.value;
        let status = selectStatus.value;

        document.getElementById('txtSeatClass').value = seatClass;
        document.getElementById('txtStatus').value = status;

        var seatData = {};
        seatData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, seatData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        let seatClass = selectSeatClass.value;
        let status = selectStatus.value;

        document.getElementById('txtSeatClass').value = seatClass;
        document.getElementById('txtStatus').value = status;

        var seatData = {};
        seatData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, seatData);
        //Refresca la tabla
        this.ReloadTable();
        //sessionStorage.removeItem('seatData');
        window.location.href = '/Dashboard/listSeat';
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById('divStatus').style.visibility = 'visible';
    }
}

$(document).ready(function () {

    var data = JSON.parse(sessionStorage.getItem('seatData'));

    if (data == null) {
        document.getElementById('btnCreate').style.visibility = 'visible';
        document.getElementById('btnUpdate').style.visibility = 'hidden';
    } else {
        document.getElementById('btnUpdate').style.visibility = 'visible';
        document.getElementById('btnCreate').style.visibility = 'hidden';
    }
    var vseat = new cSeat();
    vseat.BindFields(data);
    sessionStorage.removeItem('seatData');

});