'use strict';

function vSeat() {

    this.tblSeatId = "tblSeats";
    this.service = "seat";
    this.ctrlActions = new ControlActions();
    this.columns = "Id,SeatNumber,FlyNumber,SeatClass,Status";


    this.SetInformation = function () {
        window.location.href = '/Dashboard/createSeat';
    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblSeatId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblSeatId, true);
    }

    this.Create = function () {
        var seatData = {};
        seatData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, seatData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Delete = function () {

        var seatData = {};
        seatData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, seatData);
        Swal.fire({
            title: 'Desactivación correcta',
            text: 'El asiento se desactivo correctamente',
            type: 'sucess',
            confirmButtonText: 'Ok'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        sessionStorage.setItem('seatData', JSON.stringify(data));
    }


}

//ON DOCUMENT READY
$(document).ready(function () {

    var vseat = new vSeat();
    vseat.RetrieveAll();

});